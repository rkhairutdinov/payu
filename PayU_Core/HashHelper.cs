using System;
using System.Security.Cryptography;
using System.Text;

namespace PayU_Core
{
    public static class HashHelper
    {
        public static string HashWithSignature (this string hashString, string signature)
        {
            var binaryHash = new HMACMD5(Encoding.UTF8.GetBytes(signature))
                .ComputeHash(Encoding.UTF8.GetBytes(hashString));
            
            var hash = BitConverter.ToString(binaryHash)
                .Replace("-", string.Empty)
                    .ToLowerInvariant();

            return hash;
        }

        private static string Compute(string data, string secret)
        {
            byte[] secretBytes = Encoding.UTF8.GetBytes(secret);
            var hmac = new HMACMD5(secretBytes);
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            byte[] computedHash = hmac.ComputeHash(dataBytes);
            //--------------------------------------------------
            var hash = new StringBuilder();
            for (var i = 0; i < computedHash.Length; i++)
            {
                hash.Append(computedHash[i].ToString("x2")); // hex format
            }

            return hash.ToString();
        }

        public static string ComputeSHA256(this string hashString, string secret)
        {
            byte[] secretBytes = Encoding.UTF8.GetBytes(secret);
            var hmac = new HMACSHA256(secretBytes);
            byte[] dataBytes = Encoding.UTF8.GetBytes(hashString);
            byte[] computedHash = hmac.ComputeHash(dataBytes);
            //--------------------------------------------------
            var hash = new StringBuilder();
            for (var i = 0; i < computedHash.Length; i++)
            {
                hash.Append(i.ToString("x2")); // hex format
            }

            return hash.ToString();
        }

        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}

