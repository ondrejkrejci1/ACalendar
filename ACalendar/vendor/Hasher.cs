using System.Security.Cryptography;
using System.Text;

namespace ACalendar.vendor
{
    /// <summary>
    /// Provides methods for computing cryptographic hash values.
    /// </summary>
    public class Hasher
    {
        /// <summary>
        /// Computes the SHA-256 hash of the specified input string and returns it as a lowercase hexadecimal string.
        /// </summary>
        /// <param name="rawData">The input string to hash.</param>
        /// <returns>A lowercase hexadecimal string representation of the SHA-256 hash.</returns>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="rawData"/> is null.</exception>
        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));

                return builder.ToString();
            }
        }
    }
}
