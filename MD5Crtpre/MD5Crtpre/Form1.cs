using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MD5Crtpre
{
    public partial class Form1 : Form
    {
        MD5Entities1 database = new MD5Entities1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            dataGridView1.DataSource = database.Class1.ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class1 veri = new Class1();
            SaltGenerator salt = new SaltGenerator();

            string uretilenSalt = salt.GenerateNewPassword();

            veri.KullaniciName = textBox1.Text;
            veri.Sifre = Encrypt( textBox2.Text +uretilenSalt ); //textbox a girilen veri şifrelenerek kaydedilicek
            veri.Salt = uretilenSalt;

            database.Class1.Add(veri);
            database.SaveChanges();

            Listele();
        }

        string hash = "";
        string Encrypt(string text)
        {
            byte[] data = Encoding.Default.GetBytes(text);

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.Default.GetBytes(hash));

                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider()
                {
                    Key = keys,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                })
                {
                    ICryptoTransform transform = tripleDES.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Convert.ToBase64String(results, 0, results.Length);
                }

            }
        }

        string Descrypt(string text) // şifrelenmiş text gönderirilirse çözümlücek
        {
            byte[] data = Convert.FromBase64String(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.Default.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider()
                { Key = keys, Mode = CipherMode.ECB, Padding =PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDES.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Encoding.Default.GetString(results);
                 }

            } 
        }
        string sifre = string.Empty;
        string Salt = string.Empty;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        //    textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

             sifre = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
             Salt = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
          


          //  textBox2.Text = Descrypt(sifreliMetin); // şifreli metini çözerekten getiriyor
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kontrolHash =Encrypt(textBox2.Text+ Salt); //Kulalnıcı şifre giriyor bizde kullanıcının bilgisini Salt ile kontorl ediyoruz

            if (sifre== kontrolHash)
            {
                MessageBox.Show("Hashler eşleşmekte");
            }
        }
    }
}
