using PhotoGallery.Infrastructure.Services.Abstract;
using System;
using System.Security.Cryptography;
using System.Text;

namespace PhotoGallery.Infrastructure.Services
{
    public class EncryptionService :IEncryptionService
    {
        public string CreateSalt()
        {
            byte[] data = new byte[0x10];

            var cryptoServiceProvider = System.Security.Cryptography.RandomNumberGenerator.Create();
            cryptoServiceProvider.GetBytes(data);
            return Convert.ToBase64String(data);
        }

        public string EncryptPassword(string password, string salt)
        {
            using(var sha256 = SHA256.Create())
            {
                var saltedPassword = $"{salt}{password}";
                byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
                return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
            }
        }
    }
}
