using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;

namespace GFA_Launcher
{
    public partial class LanguageSelector : Form
    {
        private OptionsData options;
        public LanguageSelector()
        {
            options = new OptionsData();
            InitializeComponent();
            bindingSource.DataSource = options;
            Language.DataSource = options.languageItems;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            options.saveIni();
            OnLanguageSelected(options.Language);
            this.Close();
        }

        // void callback function with string parameter
        public delegate void LanguageSelectedCallback(string language);
        public event LanguageSelectedCallback? LanguageSelected;

        protected virtual void OnLanguageSelected(string language)
        {
            LanguageSelected?.Invoke(language);
        }
    }
}
