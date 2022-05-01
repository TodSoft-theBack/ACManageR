using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ACManageR.ExtentionMethods
{
    public static class HashingMethods
    {
        public static string CreateSalt(int size)
        {
            var sp = new RNGCryptoServiceProvider();
            var buffer = new byte[size];
            sp.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }
        public static string Hash(string input, string salt)
        {
            var bytes = Encoding.UTF8.GetBytes(input + salt);
            var sha256String = new SHA1Managed();
            return Convert.ToBase64String(sha256String.ComputeHash(bytes));
        }
    }
}
