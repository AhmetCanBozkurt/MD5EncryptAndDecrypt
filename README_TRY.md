# MD5 ve Salt ile Şifre Güvenliği

## Genel Bakış
Bu proje, kullanıcı şifrelerini güvenli bir şekilde yönetmek için aşağıdaki özellikleri uygular:

1. **MD5 ile Şifreleme**: Kullanıcı şifreleri, güvenli bir şekilde saklanmaları ve kolayca çözülmelerinin önlenmesi için MD5 algoritması ile şifrelenir.

2. **Salt Üretimi**: Şifreleme öncesinde basit bir `PasswordGenerator` aracı ile benzersiz bir "salt" üretilir ve şifreye eklenir. Bu yöntem, güvenliği artırır.

## Özellikler
- **MD5 Şifreleme**: Şifreyi hashlenmiş bir metin dizesine dönüştürür.
- **Salt Entegrasyonu**: Her bir şifre için dinamik olarak rastgele bir salt üretir ve hashleme işleminden önce ekler.
- **Artırılmış Güvenlik**: Hashleme sürecini daha dayanıklı ve yaygın saldırılara karşı dirençli hale getirir.

## Nasıl Çalışır?
1. **Salt Üretimi**:
   - `PasswordGenerator` kullanarak rastgele bir salt oluşturulur.

2. **Şifre ve Saltı Birleştirme**:
   - Kullanıcının çıplak şifresine oluşturulan salt eklenir.

3. **Birleşik Dizenin Hashlenmesi**:
   - MD5 algoritması kullanılarak birleştirilmiş şifre ve salt hashlenir.

4. **Hashlenmiş Şifre ve Saltı Depolama**:
   - Hashlenmiş şifre ve buna karşılık gelen salt, gelecekte doğrulama için veritabanında saklanır.

## Örnek İş Akışı
```plaintext
Kullanıcının Çıplak Şifresi: password123
Oluşturulan Salt: Xyz789
Birleşik Dize: password123Xyz789
MD5 Hash: e99a18c428cb38d5f260853678922e03

Veritabanında Saklanan:
- Hashlenmiş Şifre: e99a18c428cb38d5f260853678922e03
- Salt: Xyz789
```

## Avantajları
- **Rainbow Tables’a Karşı Koruma**: Benzersiz salt, iki kullanıcı aynı şifreyi kullansa bile hash değerlerinin farklı olmasını sağlar.
- **Artırılmış Şifre Güvenliği**: Salt ile hashleme, daha güvenli bir saklama mekanizması oluşturur.

## Gereksinimler
- .NET Framework (4.7.2 veya daha yüksek bir sürüm)
- Rastgele dizeler oluşturmak için bir kütüphane ("örneğin, `PasswordGenerator`)

## Kurulum ve Kullanım
1. Projeyi klonlayın:
   ```bash
   git clone <repository_url>
   ```
2. Projeyi Visual Studio’da açın.
3. Bağımlılıkları yükleyin.
4. Uygulamayı çalıştırın ve şifreleri güvenli bir şekilde hashlemek ve saklamak için talimatları izleyin.

## Notlar
- MD5 hızlı bir hashleme algoritmasıdır ancak modern uygulamalar için en güvenli seçenek değildir. Üretim sınıfındaki uygulamalar için SHA-256 veya bcrypt gibi daha güçlü algoritmaları kullanmayı düşünün.
- Salt’ların uzun ve benzersiz olması güvenliği en üst düzeye çıkarır.

## Gelecekteki İyileştirmeler
- Daha güvenli bir hashleme algoritmasına geçiş yapın.
- Kullanıcı güvenliği için şifre politikaları uygulayın.
- Şifreleme ve doğrulama süreçlerini doğrulamak için testler ekleyin.

## Lisans
Bu proje MIT Lisansı altında lisanslanmıştır. Daha fazla detay için LICENSE dosyasına bakın.

