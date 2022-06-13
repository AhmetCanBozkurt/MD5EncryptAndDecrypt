using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD5Crtpre
{
    public class SaltGenerator
    {
        public string GenerateNewPassword()
        {
            char[] cr = "0123456789abcdefghijklmnopqrstuvwxyz!^/()}][{+%&$½#£>|".ToCharArray();
            string result = string.Empty;

            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                result += cr[r.Next(0, cr.Length - 1)].ToString();
            }

            return result;
        }
    }
}
