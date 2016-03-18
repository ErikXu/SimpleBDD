using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SimpleBDD.Client
{
    public class DesCryptoUtil
    {
        private const string Key = "UN78mwoX";

        public string Encrypt(string plainText)
        {
            if (plainText == string.Empty)
            {
                return plainText;
            }

            using (var provider = new DESCryptoServiceProvider())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(plainText);
                provider.Key = Encoding.ASCII.GetBytes(Key);
                provider.IV = Encoding.ASCII.GetBytes(Key);
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, provider.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytes, 0, bytes.Length);
                        cryptoStream.FlushFinalBlock();
                    }
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        public string Decrypt(string encryptedText)
        {
            var bytes = Convert.FromBase64String(encryptedText);
            using (var provider = new DESCryptoServiceProvider())
            {
                provider.Key = Encoding.ASCII.GetBytes(Key);
                provider.IV = Encoding.ASCII.GetBytes(Key);
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, provider.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytes, 0, bytes.Length);
                        cryptoStream.FlushFinalBlock();
                    }
                    return Encoding.UTF8.GetString(memoryStream.ToArray());
                }
            }
        }
    }
}