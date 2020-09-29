using IdentityServer.Storage.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography;
using System.Text;

namespace IdentityServer.Services
{
    public class CryptoGraphy : IPasswordHasher<ApplicationUser>
    {
        public string HashPassword(ApplicationUser user, string password)
        {
            SHA1 algorithm = SHA1.Create();
            byte[] data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hashedPassword = "";

            for (int i = 0; i < data.Length; i++)
            {
                hashedPassword += data[i].ToString("x2").ToUpperInvariant();
            }

            return hashedPassword;
        }

        public PasswordVerificationResult VerifyHashedPassword(ApplicationUser user, string hashedPassword, string providedPassword)
        {
            if (HashPassword(user, providedPassword).Equals(hashedPassword))
            {
                return PasswordVerificationResult.Success;
            }
            return PasswordVerificationResult.Failed;
        }
    }
}
