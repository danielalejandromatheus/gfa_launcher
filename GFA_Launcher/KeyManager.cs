using GFA_Launcher.Properties;
using System;
using System.IO;
using System.Security.Cryptography;
namespace GFA_Launcher
{
    public static class KeyManager
    {
        public static void GenerateAndProtectKey()
        {
            // Generate a 32-byte AES key
            var aesKey = new byte[32];

            RandomNumberGenerator.Fill(aesKey);

            // Protect the key using DPAPI
            var protectedKey = ProtectedData.Protect(aesKey, null, DataProtectionScope.CurrentUser);

            // Save the protected key to a file
            File.WriteAllBytes(Settings.Default.KeyFilePath, protectedKey);
            File.SetAttributes(Settings.Default.KeyFilePath, File.GetAttributes(Settings.Default.KeyFilePath) | FileAttributes.Hidden);

        }

        public static byte[] LoadAndUnprotectKey()
        {
            if (!File.Exists(Settings.Default.KeyFilePath))
                throw new FileNotFoundException("The encryption key file does not exist.");

            // Load the protected key from the file
            var protectedKey = File.ReadAllBytes(Settings.Default.KeyFilePath);

            // Unprotect the key
            return ProtectedData.Unprotect(protectedKey, null, DataProtectionScope.CurrentUser);
        }
    }
}