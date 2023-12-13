using System;
using System.Security.Cryptography;

namespace LayoutBuilder.Utils
{
    public class SecretKeyGenerator
    {
        public string GenerateRandomKey() {
            int length = 256;
            byte[] keyBytes = new byte[length];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(keyBytes);
            }

            return Convert.ToBase64String(keyBytes);
        }
    }
}