using System.Net;

namespace GFA_Launcher
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!File.Exists("accountsKey.bin"))
            {
                KeyManager.GenerateAndProtectKey();
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Launcher());
        }
    }
}