using System.Security.Cryptography;
using System.Text;

namespace OnlineShop.App.Helpers
{
    public static class HashHelper
    {
        public static (string, string) CreateHashWithSalt(string password)
        {
            var saltToBase = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            var toHash = Encoding.UTF8.GetBytes(password + saltToBase);
            using var sha = SHA256.Create();
            var hash = sha.ComputeHash(toHash);

            var builder = new StringBuilder();
            foreach (var t in hash)
            {
                builder.Append(t.ToString("x2"));
            }
            
            return (builder.ToString(), saltToBase);
        }
    }
}
