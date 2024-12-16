using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

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

        private const int WS_EX_LAYERED = 0x80000;
        private const int LWA_COLORKEY = 0x1;
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
                BaseAddress = new Uri(Properties.Settings.Default.ApiEndpoint)
            };
            // set json content type for all requests
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            InitializeComponent();
            LangButton.BackColor = Color.Transparent;
            customButton1.BackColor = Color.Transparent;
            button1.BackColor = Color.Transparent;
            button2.BackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            UpdateLangButton(Properties.Settings.Default.Lang);
            customButton1.SpriteSheet = Properties.Resources.Bitmap208;
            button1.SpriteSheet = Properties.Resources.Bitmap232;
            button2.SpriteSheet = Properties.Resources.Bitmap231;
            button3.SpriteSheet = Properties.Resources.Bitmap210;
            int style = NativeMethods.GetWindowLong(this.Handle, -20);
            NativeMethods.SetWindowLong(this.Handle, -20, style | WS_EX_LAYERED);
            // Set the green color as transparent
            uint greenColorKey = (uint)ColorTranslator.ToWin32(Color.FromArgb(0, 255, 0));
            SetLayeredWindowAttributes(this.Handle, greenColorKey, 0, LWA_COLORKEY);
            //this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.ClientSize = new System.Drawing.Size(1127, 659);
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
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // Ensure transparency is applied after form is displayed
            uint greenColorKey = (uint)ColorTranslator.ToWin32(Color.FromArgb(0, 255, 0));
            SetLayeredWindowAttributes(this.Handle, greenColorKey, 0, LWA_COLORKEY);
        }

        private List<string> fileList = new List<string>();
        private async Task DownloadFiles()
        {
            // make temp folder to store files if it doesn't exist
            if (!Directory.Exists("temp"))
            {
                Directory.CreateDirectory("temp");
                // directory should be hidden
                //File.SetAttributes("temp", File.GetAttributes("temp") | FileAttributes.Hidden);
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

            Notify("Initializing...");
            //await TaskHelper.ExecuteWithRetryAsync(InitializeLauncher, (int retries, string message) => { Notify("Error ocurred, retrying..."); });
            Notify("Ready to play");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "D:\\Descargas\\074\\Ultimate\\GrandFantasia.exe";
            startInfo.Arguments = "EasyFun";
            startInfo.WorkingDirectory = "D:\\Descargas\\074\\Ultimate";
            Process.Start(startInfo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Open Form2 as a dialog
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ScanFiles();
        }

        private void Notify(string message)
        {
            StatusLabel.Text = message;
        }

        private void StatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            //close the app
            Application.Exit();
        }

        private void LangButton_Click(object sender, EventArgs e)
        {
            LanguageSelector langSelector = new LanguageSelector();
            langSelector.LanguageSelected += UpdateLangButton;
            langSelector.ShowDialog();
        }
    }
}
