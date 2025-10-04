using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KinesiaLibrary
{
    public class CustomSecurity
    {
        public static string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string saltedPassword = password + salt;

                // will hash the saltedPassword into 256-bit hash
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                StringBuilder builder = new StringBuilder();

                // will converts each byte into its 2-digit lowercase hexadecimal form
                // Example: "4b227777d4dd1fc61c6f884f48641d02..."
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string GenerateSalt()
        {
            byte[] saltByes = new byte[16]; // will create a 16-byte array

            using (var random = RandomNumberGenerator.Create())
            {
                random.GetBytes(saltByes); // will fills it with cryptographically random values
            }

            // will convert bytes into a Base64 Str
            // Example: "bZf34Gv2aF+5QZz9q3bXyA=="
            return Convert.ToBase64String(saltByes);
        }
    }
}
