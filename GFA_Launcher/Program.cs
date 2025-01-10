using System.Diagnostics;

namespace GFA_Launcher
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //if (!File.Exists("accountsKey.bin"))
            //{
            //    KeyManager.GenerateAndProtectKey();
            //}
            //string? currentExe = Environment.ProcessPath;
            //string currentExeDirectory = Path.GetDirectoryName(currentExe) ?? string.Empty;

            //// Path for the cloned executable
            //string clonePath = Path.Combine(currentExeDirectory, "_Launcher.exe");
            //if (args.Length == 0)
            //{
            //    // Copy itself to the temp path
            //    File.Copy(currentExe, clonePath, true);
            //    Process.Start(new ProcessStartInfo
            //    {
            //        FileName = clonePath,
            //        Arguments = "--NoReborn",
            //        UseShellExecute = false
            //    });
            //    Application.Exit();
            //}

            //if (args.Length > 0 && args[0] == "--NoReborn")
            //{
                //Proceed to initialize the app
                Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ApplicationConfiguration.Initialize();
                Application.Run(new Launcher());
            //}
        }
    }
}