using System.Security.Cryptography;
using System.Text;

namespace IFAVALIACAO.API.Domain.Extension
{
    public static class StringExtension
    {

        public static bool HasValue(this string value) => !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);

        public static string Encrypt(this string value)
        {
            var md5Hash = MD5.Create();

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}