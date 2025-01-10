using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
//using System.Windows.Forms.WebBrowser;
namespace GFA_Launcher
{
    public partial class Launcher : Form
    {
        HttpDownloader httpDownloader;
        HttpClient client;
        // Import SetLayeredWindowAttributes from user32.dll
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        internal static class NativeMethods
        {
            [DllImport("user32.dll", SetLastError = true)]
            public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        }
        //private System.Windows.Forms.Timer timer;
        //private int progressValue = 0;
        public Launcher()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("http://gfa.test/api/")
            };
            httpDownloader = new HttpDownloader("http://gfa.test/api/");
            manifest = new Dictionary<string, IdxItemModel>(); // Initialize the manifest dictionary
            // set json content type for all requests
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
            webBrowser = new WebBrowser();
            webBrowser.Location = new Point(320, 223);
            webBrowser.MinimumSize = new Size(20, 20);
            webBrowser.Name = "webBrowser";
            webBrowser.ScrollBarsEnabled = false;
            webBrowser.ClientSize = new Size(480, 300);
            webBrowser.Size = new Size(480, 300);
            webBrowser.TabIndex = 1;
            webBrowser.Url = new Uri("https://www.gfawakening.online/patch-notes.html", UriKind.Absolute);
            UpdateLangButton(LaunchHelper.GetLang());
            this.Controls.Add(webBrowser);
            //this.MouseDown += new MouseEventHandler(Form_MouseDown);
            EnableDragging(this);
            EnableDragging(StatusLabel);
            EnableDragging(OverallProgressBar);
            EnableDragging(SingleProgressBar);
            //timer = new System.Windows.Forms.Timer { Interval = 50 };

            //timer.Tick += Timer_Tick;
            //timer.Start();
        }
        //private void Timer_Tick(object sender, EventArgs e)
        //{
        //    // Increment progress
        //    progressValue += 1;
        //    if (progressValue > 100)
        //    {
        //        progressValue = 0; // Reset progress for a looped animation
        //    }

        //    SingleProgressBar.Progress = progressValue; // Update the progress bar
        //}
        private void EnableDragging(Control control)
        {
            control.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                }
            };
        }
        private void UpdateLangButton(string Lang)
        {
            switch (Lang)
            {
                case "US":
                    LangButton.SpriteSheet = Properties.Resources.ENG;
                    break;
                case "ES":
                    LangButton.SpriteSheet = Properties.Resources.ESP;
                    break;
                case "PT":
                    LangButton.SpriteSheet = Properties.Resources.BR;
                    break;
                default:
                    LangButton.SpriteSheet = Properties.Resources.ENG;
                    break;
            }
        }

        private void PatchGameOnLanguageSelected(string Lang)
        {
            List<long> offsets = new List<long>
            {
                0x8C00F5, 0x8C0B7D, 0x8C0BF5, 0x8C1841, 0x8C18A5, 0x8C1935,
                0x8C1975, 0x8C19D5, 0x8C1AB1, 0x8C1B5D, 0x8C1FF9, 0x8C2039,
                0x8C20D5, 0x8C21F1, 0x8C2231, 0x8C22C1, 0x8C2301, 0x8C2369,
                0x8C23A9, 0x8C243D, 0x8C24D1, 0x8C255D, 0x8C2595, 0x8C25D5,
                0x8C2611, 0x8C2651, 0x8C26AD, 0x8C26E9, 0x8C2745, 0x8C28DD,
                0x8C2929, 0x8C2959, 0x8C2995, 0x8C29D5, 0x8C2A19, 0x8C2A71
            };

            string defaultPath = "data\\Translate";
            string path = defaultPath;
            switch (Lang)
            {
                case "ES":
                    path = "data\\Trans_ESP";
                    break;
                case "PT":
                    path = "data\\Transl_PT";
                    break;
            }

            // Very important to keep the alternate paths the same exact length 
            // otherwise it results in an invalid path.
            if (path.Length != defaultPath.Length)
            {
                Notify($"Invalid language path ${path}...");
                return;
            }

            byte[] pathBytes = Encoding.UTF8.GetBytes(path);
            using (FileStream fs = new FileStream("GrandFantasia.exe", FileMode.Open, FileAccess.Write))
            {
                foreach (long offset in offsets)
                {
                    fs.Seek(offset + 1, SeekOrigin.Begin);
                    fs.Write(pathBytes, 0, pathBytes.Length);
                }
            }
            Notify($"Game language patched successfully.");
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private Dictionary<string, IdxItemModel> manifest;
        private async void DownloadLauncher(int size)
        {
            await httpDownloader.DownloadFileWithRetriesAsync("download/Launcher.exe", "Launcher.exe", size, (string message, int type) => { Notify(message, type); }, (double progress) => { SingleProgressBar.Progress = progress; });
            // Get the directory of the current executable
            string? currentExe = Environment.ProcessPath;
            string currentExeDirectory = Path.GetDirectoryName(currentExe) ?? string.Empty;

            // Start the cloned version with arguments
            Process.Start(new ProcessStartInfo
            {
                FileName = Path.Combine(currentExeDirectory, "Launcher.exe"),
                UseShellExecute = false
            });
            Application.Exit();
        }
        private async Task ScanFiles()
        {
            // This is a brief scan of the files in the manifest.txt file compared against pkg.idx
            // Get a list of the files to scan in the current manifest
            OverallProgressBar.Progress = 0;
            int idx = 0;
            string[] lines = File.ReadAllLines("manifest.txt");
            foreach (string line in lines.Skip(1))
            {
                SingleProgressBar.Progress = 0;
                string[] parts = line.Split(':');
                string file = parts[0];
                // filename is the last item in the string after the last slash
                string fileName = Path.GetFileName(file);
                // file path is the first item in the string before the last slash, if it is the same as the file name, then it is in the root directory
                string filePath = Path.GetDirectoryName(file);
                Notify($"Scanning {filePath}\\{fileName}...", 0);
                IdxItemModel item = new IdxItemModel
                {
                    file_name = fileName,
                    file_path = filePath,
                    size = int.Parse(parts[1]),
                    hashCRC = uint.Parse(parts[2]),
                    zsize = int.Parse(parts[3])
                };
                // if it returns null and the zsize is 0 it means we have to check manually here if it should be redownloaded, if not it means it'll be calculated in the packager script
                if (item.zsize == 0 && Path.Exists(Path.Combine(item.file_path, item.file_name)))
                {
                    int size = (int)new FileInfo(file).Length;
                    uint hashCRC = Rycrc.Crc32.Compute(File.ReadAllBytes(file));
                    if (hashCRC != item.hashCRC && size != item.size)
                    {
                        manifest[Path.Combine(item.file_path, item.file_name)] = item;
                    }
                }
                else
                {
                    manifest[Path.Combine(item.file_path, item.file_name)] = item;
                }
                SingleProgressBar.Progress = 100;
                idx++;
                double progress = ((double)idx / lines.Length) * 100;
                OverallProgressBar.Progress = progress;
                // TODO review logic later
            }
            await HandleUpdate();
        }
        private async Task HandleUpdate()
        {
            // First download uncompressed files if there is any, then remove them from the manifest so the packager does not have leftover data
            int idx = 0;
            OverallProgressBar.Progress = 0;
            var uncompressedFiles = manifest.Where(x => x.Value.zsize == 0).ToList();
            if (uncompressedFiles.Any())
            {
                foreach (var uncompressedFile in uncompressedFiles)
                {
                    if (uncompressedFile.Value.file_path != "\\" && uncompressedFile.Value.file_path != "" && !Directory.Exists(uncompressedFile.Value.file_path))
                    {
                        Directory.CreateDirectory(uncompressedFile.Value.file_path);
                    }
                    if (uncompressedFile.Key != "Launcher.exe")
                    {
                        await httpDownloader.DownloadFileWithRetriesAsync($"download/{uncompressedFile.Key}", uncompressedFile.Key, uncompressedFile.Value.zsize == 0 ? uncompressedFile.Value.size : uncompressedFile.Value.zsize, (string message, int type) => { Notify(message, type); }, (double progress) => { SingleProgressBar.Progress = progress; }, uncompressedFile.Key);
                    }
                    else
                    {
                        //DownloadLauncher(uncompressedFile.Value.size);
                    }
                    idx++;
                    double progress = ((double)idx / manifest.Count) * 100;
                    OverallProgressBar.Progress = progress;
                }
            }
            var compressedFiles = manifest.Where(x => x.Value.zsize > 0).ToDictionary();

            if (compressedFiles.Count > 0)
            {
                var packagedUpdater = new PackagedFileUpdater { FileCount = manifest.Count, FileIndex = idx };
                packagedUpdater.Notify += Notify;
                packagedUpdater.NotifyProgress += (double progress) => { SingleProgressBar.Progress = progress; };
                packagedUpdater.NotifyOverallProgress += (double progress) => { OverallProgressBar.Progress = progress; };
                await packagedUpdater.ScanAndUpdateFiles(compressedFiles, httpDownloader);
            }
        }
        private void ChangeActionsState(bool state)
        {
            LangButton.Enabled = state;
            LaunchButton.Enabled = state;
            OptionsButton.Enabled = state;
            ScanButton.Enabled = state;
        }
        private async void InitializeLauncher()
        {
            Notify("Initializing...");
            ChangeActionsState(false);
            OverallProgressBar.Progress = 100;
            while (true)
            {
                if (File.Exists("manifest.txt"))
                {
                    Notify("Checking manifest version", 1);
                    HttpResponseMessage response = await client.GetAsync("getManifestVersion");
                    if (response != null && response.StatusCode == HttpStatusCode.OK)
                    {
                        try
                        {
                            string result = await response.Content.ReadAsStringAsync();
                            var serverVersion = JObject.Parse(result)["version"];
                            if (serverVersion != null)
                            {
                                string[] currentLines = File.ReadAllLines("manifest.txt");
                                string currentVersion = currentLines[0];
                                if (serverVersion.ToString() == currentVersion)
                                {
                                    SingleProgressBar.Progress = 100;
                                    await ScanFiles();
                                    return;
                                }
                                else
                                {
                                    Notify("Manifest version mismatch, redownloading...", 1);
                                }
                            }
                        }
                        catch
                        {
                            Notify("Manifest is corrupted, redownloading...", 2);
                            File.Delete("manifest.txt");
                            Task.Delay(1000).Wait();
                            continue;
                        }
                    }
                    else
                    {
                        // Notify something went wrong, notify site is down and retry
                        Notify("Failed to get manifest version from server, retrying...", 2);
                        Task.Delay(1000).Wait();
                        continue;
                    }
                    // Download manifest.txt from the server
                    //HttpResponseMessage manifestMessage = await client.GetAsync("getManifestFile");
                    await httpDownloader.DownloadFileWithRetriesAsync("getManifestFile", "manifest.txt", 0, (string message, int type) => { Notify(message, type); }, (double progress) => { SingleProgressBar.Progress = progress; }, "manifest file");
                    await ScanFiles();
                    break;
                }
                else
                {
                    // Download manifest.txt from the server
                    await httpDownloader.DownloadFileWithRetriesAsync("getManifestFile", "manifest.txt", 0, (string message, int type) => { Notify(message, type); }, (double progress) => { SingleProgressBar.Progress = progress; }, "manifest file");
                    await ScanFiles();
                    break;
                }
            }
            ChangeActionsState(true);
            Notify("Ready to play");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeLauncher();
        }
        /**
         * @param message: The message to display in the status label
         * @param type: The type of message to display
         * 0: Information
         * 1: Download
         * 2: Error
         */
        private void Notify(string message, int type = -1)
        {
            switch (type)
            {
                case 0:
                    StatusLabel.ForeColor = Color.FromArgb(150, 190, 255);
                    break;
                case 1:
                    // Light green
                    StatusLabel.ForeColor = Color.FromArgb(180, 255, 200);
                    break;
                case 2:
                    // Light red
                    StatusLabel.ForeColor = Color.FromArgb(170, 0, 0);
                    break;
                default:
                    // Default to information
                    StatusLabel.ForeColor = Color.WhiteSmoke;
                    break;
            }
            StatusLabel.Text = message;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LangButton_Click(object sender, EventArgs e)
        {
            LanguageSelector langSelector = new LanguageSelector();
            langSelector.LanguageSelected += UpdateLangButton;
            langSelector.LanguageSelected += PatchGameOnLanguageSelected;
            langSelector.ShowDialog();
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            LaunchHelper.LaunchGame(Properties.Settings.Default.CurrentUsername);
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {

            OptionSelector optionDialog = new OptionSelector();
            optionDialog.ShowDialog();
        }

        private async void ScanButton_Click(object sender, EventArgs e)
        {
            await ScanFiles();
        }
    }
}
