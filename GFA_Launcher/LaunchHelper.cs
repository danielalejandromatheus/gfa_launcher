using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GFA_Launcher
{
    public class LaunchHelper
    {
        public static string GetLang()
        {
            string path = String.Empty;
            using (FileStream fs = new FileStream("GrandFantasia.exe", FileMode.Open, FileAccess.Read))
            {
                fs.Seek(0x8C2A71 + 1, SeekOrigin.Begin);
                byte[] buffer = new byte[14];
                fs.Read(buffer, 0, 14);
                path = Encoding.Default.GetString(buffer);
                switch (path)
                {
                    case "data\\Trans_ESP":
                        return "ES";
                    case "data\\Transl_PT":
                        return "PT";
                    case "data\\Translate":
                    default:
                        return "US";
                }
            }
        }
        public static void LaunchGame(string username)
        {

            ProcessStartInfo startInfo = new ProcessStartInfo();
            AccountManager accountManager = new AccountManager();
            var account = accountManager.GetCurrentAccount(username);

            startInfo.FileName = "GrandFantasia.exe";
            startInfo.Arguments = "EasyFun";

            if (account != null)
            {
                // Secret to md5
                MD5 md5 = MD5.Create();
                // Convert the input string to a byte array and compute the hash
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(account.Secret));

                // Convert the byte array to a hexadecimal string
                StringBuilder hashStringBuilder = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hashStringBuilder.Append(b.ToString("x2")); // Format as hexadecimal
                }

                startInfo.Arguments += $" -a {account.Username} -p {hashStringBuilder.ToString()}";
            }
            string dllPath = "AwknCore.dll";
            Process? process = Process.Start(startInfo);
            if (process == null)
            {
                throw new InvalidOperationException("Failed to start process.");
            }
            DllInjector.InjectDLL(process.Id, dllPath);
            Application.Exit();
        }
    }
}
