using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;

namespace GFA_Launcher
{
    public partial class Launcher : Form
    {
        HttpClient client = new HttpClient();
        public Launcher()
        {
            client.BaseAddress = new Uri("http://localhost:8080/");
            InitializeComponent();
        }
        private List<string> fileList = new List<string>();
        private Task DownloadFiles()
        {
            // make temp folder to store files if it doesn't exist
            if (!Directory.Exists("temp"))
            {
                Directory.CreateDirectory("temp");
            }
            return Task.Run(() =>
            {
                foreach(string file in fileList){
                // download file using httpclient

                    client.GetStreamAsync(file).Result.CopyTo(File.OpenWrite("temp/"+file));
                    // TODO: add progress bar while downloading
                    // TODO: add error handling
                    if(File.Exists("temp/" + file))
                    {
                        //TODO: package the file as soon as it is downloaded
                        File.Delete("temp/" + file);
                    }
                }
            });
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
        private void ScanFiles()
        {
            // Get a list of the files to scan in the current manifest
            string[] lines = File.ReadAllLines("manifest.txt");
            //List<string> files = new List<string>();
            // Excl8de the first line which is the version
            foreach (string line in lines.Skip(1)) {
                string[] parts = line.Split(':');
                string fileName = parts[0];
                string hash = parts[1];
                string size = parts[2];
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
                DownloadFiles().Wait();
            }
            else
            {
                //TODO notify everything OK!
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Download manifest.txt from the server
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:8080/");
            HttpResponseMessage response = client.GetAsync("getServerVersion").Result;
            if (response != null) {
                string result = response.Content.ReadAsStringAsync().Result;
                var serverVersion = JObject.Parse(result)["version"];
                if (serverVersion != null) {
                    string[] currentLines = File.ReadAllLines("manifest.txt");
                    string currentVersion = currentLines[0];
                    if (serverVersion.ToString() != currentVersion)
                    {
                        // If the version is different, download the new manifest.txt and replace it
                        HttpResponseMessage manifestMessage = client.GetAsync("getManifest").Result;
                        if (manifestMessage != null)
                        {
                            //this will download a .txt file from the server, we should then write it to disk
                            string manifestResult = manifestMessage.Content.ReadAsStringAsync().Result;
                            if (manifestResult != null)
                            {
                                File.WriteAllText("manifest.txt", manifestResult);
                                //MessageBox.Show("New version available, updating...");
                                ScanFiles();
                            }
                        }
                    }
                }
            }
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
    }
}
