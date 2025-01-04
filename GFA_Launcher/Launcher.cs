using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
//using System.Windows.Forms.WebBrowser;
namespace GFA_Launcher
{
    public partial class Launcher : Form
    {
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
        public Launcher()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri("http://gfa.test")
            };
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
            this.MouseDown += new MouseEventHandler(Form_MouseDown);

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

        private List<string> fileList = new List<string>();
        private async Task DownloadFiles()
        {
            // make temp folder to store files if it doesn't exist
            if (!Directory.Exists("temp"))
            {
                Directory.CreateDirectory("temp");
                File.SetAttributes("temp", File.GetAttributes("temp") | FileAttributes.Hidden);
            }
            foreach (string file in fileList)
            {
                // download file using httpclient
                Notify($"Downloading ${file}...");
                using (var response = await client.GetAsync("/download/" + file))
                {
                    response.EnsureSuccessStatusCode();
                    using (var fileStream = File.OpenWrite("temp/" + file))
                    {
                        await response.Content.CopyToAsync(fileStream);
                    }
                }
                // Downloading and append file name
                // TODO: add progress bar while downloading
                // TODO: add error handling
                /*
                if(File.Exists("temp/" + file))
                {
                    //TODO: package the file as soon as it is downloaded

                    File.Delete("temp/" + file);
                }*/
            }
        }
        private static string GetFileHash(string filePath)
        {
            using (SHA1 sha256 = SHA1.Create())
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                byte[] hashBytes = sha256.ComputeHash(fileStream);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
        private async void ScanFiles()
        {
            // Get a list of the files to scan in the current manifest
            string[] lines = File.ReadAllLines("manifest.txt");
            //List<string> files = new List<string>();
            // Excl8de the first line which is the version
            foreach (string line in lines.Skip(1))
            {
                string[] parts = line.Split(':');
                string fileName = parts[0];
                string hash = parts[1];
                string size = parts[2];
                // TODO: Get zsize as well for packaged files!

                Notify($"Scanning {fileName}...");
                // Check if the file exists
                if (!File.Exists(fileName))
                {
                    fileList.Add(fileName);
                }
                else
                {
                    // If the file exists, check if the hash is the same
                    string fileHash = GetFileHash(fileName);
                    if (fileHash != hash)
                    {
                        // If the hash is different, add the file to the download list
                        fileList.Add(fileName);
                    }
                }
                // TODO review logic later
            }
            // Download filelist after it's done scanning and there's files in the queue
            if (fileList.Count > 0)
            {
                await TaskHelper.ExecuteWithRetryAsync(DownloadFiles, (int retries, string message) => { Notify("Error ocurred, retrying..."); });
            }
            else
            {
                Notify("All files are up to date!");
            }
        }
        private async Task InitializeLauncher()
        {
            if (File.Exists("manifest.txt"))
            {
                HttpResponseMessage response = await client.GetAsync("getManifestVersion");
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    var serverVersion = JObject.Parse(result)["version"];
                    if (serverVersion != null)
                    {
                        string[] currentLines = File.ReadAllLines("manifest.txt");
                        string currentVersion = currentLines[0];
                        if (serverVersion.ToString() == currentVersion)
                        {
                            return;
                        }
                    }
                }
                else
                {
                    // Notify something went wrong, retry
                }
                // Download manifest.txt from the server
                HttpResponseMessage manifestMessage = await client.GetAsync("getManifestFile");
                if (manifestMessage != null && manifestMessage.StatusCode == HttpStatusCode.OK)
                {
                    //this will download a .txt file from the server, we should then write it to disk
                    string manifestResult = await manifestMessage.Content.ReadAsStringAsync();
                    if (manifestResult != null)
                    {
                        File.WriteAllText("manifest.txt", manifestResult);
                        // MessageBox.Show("New version available, updating...");
                        ScanFiles();
                    }
                }
                else
                {
                    // Handle error, retry
                }
            }
        }
        private async void Form1_Load(object sender, EventArgs e)
        {

            //Notify("Initializing...");
            //await TaskHelper.ExecuteWithRetryAsync(InitializeLauncher, (int retries, string message) => { Notify("Error ocurred, retrying..."); });
            Notify("Ready to play");
        }

        private void Notify(string message)
        {
            StatusLabel.Text = message;
        }

        private void StatusLabel_Click(object sender, EventArgs e)
        {

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

        private void ScanButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not available for BETA.");
            //ScanFiles();
        }
    }
}
