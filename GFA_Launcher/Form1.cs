using System.Diagnostics;

namespace GFA_Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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

        }
    }
}
