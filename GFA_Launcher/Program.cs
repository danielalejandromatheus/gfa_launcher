using GFA_Launcher.Properties;

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
            Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!File.Exists(Settings.Default.KeyFilePath))
            {
                KeyManager.GenerateAndProtectKey();
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Launcher());
        }
    }
}