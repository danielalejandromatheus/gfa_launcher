using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GFA_Launcher
{
    public static class EncryptionHelper
    {
        public static byte[] Encrypt(string plainText)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = KeyManager.LoadAndUnprotectKey();
                aes.GenerateIV();
                byte[] iv = aes.IV;
                using (var encryptor = aes.CreateEncryptor())
                using (var ms = new MemoryStream())
                {
                    ms.Write(iv, 0, iv.Length);
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                        cs.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cs.FlushFinalBlock();
                        return ms.ToArray();
                    }
                }
            }
        }
        public static string DecryptData(string encryptedDataBase64)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = KeyManager.LoadAndUnprotectKey();
                byte[] encryptedData = Convert.FromBase64String(encryptedDataBase64);
                using (var ms = new MemoryStream(encryptedData))
                {
                    // Read the IV
                    byte[] iv = new byte[16];
                    ms.Read(iv, 0, iv.Length);
                    aes.IV = iv;

                    using (var decryptor = aes.CreateDecryptor())
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    using (var resultStream = new MemoryStream())
                    {
                        cs.CopyTo(resultStream);
                        return System.Text.Encoding.UTF8.GetString(resultStream.ToArray());
                    }
                }
            }
        }
    }
}
