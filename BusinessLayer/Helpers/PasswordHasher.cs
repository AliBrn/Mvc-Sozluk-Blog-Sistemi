using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BusinessLayer.Helpers
{
    public class PasswordHasher
    {
        // Şifreyi hashlemek  ve  Girilen şifre hash ile uyuşuyor mu kontrol etmek

        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 10000;

        // HashPassword:Düz şifre alır, hashli string üretir.

        public static string HashPassword(string password)
        {
            byte[] salt = new byte[SaltSize];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);

                return Iterations + "." +
                       Convert.ToBase64String(salt) + "." +
                       Convert.ToBase64String(hash);
            }
        }
       
        // VerifyPassword:Kullanıcının girdiği düz şifre ile veritabanındaki hash'i karşılaştırır.

        public static bool VerifyPassword(string password, string storedHash)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(storedHash))
            {
                return false;
            }

            // Geriye dönük uyumluluk: Veritabanında düz metin olarak kayıtlıysa (örneğin 0001, 3333 gibi) doğrudan eşleştir
            if (password == storedHash)
            {
                return true;
            }

            string[] parts = storedHash.Split('.');

            // Eğer 3 parçalı PBKDF2 formatında değilse (nokta içermeyen eski şifre)
            if (parts.Length != 3)
            {
                return password == storedHash;
            }

            try
            {
                int iterations = int.Parse(parts[0]);
                byte[] salt = Convert.FromBase64String(parts[1]);
                byte[] expectedHash = Convert.FromBase64String(parts[2]);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
                {
                    byte[] actualHash = pbkdf2.GetBytes(expectedHash.Length);

                    return SlowEquals(actualHash, expectedHash);
                }
            }
            catch
            {
                // Format veya Base64 çözümleme hatası durumunda düz metin karşılaştırmasına geri dön
                return password == storedHash;
            }
        }

        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;

            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }

            return diff == 0;
        }
    }
}
