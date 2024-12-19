namespace GFA_Launcher
{
    partial class Launcher
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StatusLabel = new Label();
            SuspendLayout();
            // 
            // StatusLabel
            // 
            StatusLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StatusLabel.AutoSize = true;
            StatusLabel.BackColor = Color.Transparent;
            StatusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StatusLabel.ForeColor = Color.WhiteSmoke;
            StatusLabel.Location = new Point(495, 778);
            StatusLabel.MaximumSize = new Size(620, 40);
            StatusLabel.MinimumSize = new Size(620, 40);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(620, 40);
            StatusLabel.TabIndex = 0;
            StatusLabel.Text = "Placeholder";
            StatusLabel.Click += StatusLabel_Click;
            // 
            // Launcher
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Window;
            BackgroundImage = Properties.Resources.LauncherGFA;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1631, 954);
            Controls.Add(StatusLabel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(6, 8, 6, 8);
            MaximizeBox = false;
            Name = "Launcher";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Awakening Launcher";
            TransparencyKey = Color.Lime;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label StatusLabel;
        private CustomButton button3;
        private CustomButton button1;
        private CustomButton button2;
        private CustomButton customButton1;
        private CustomButton LangButton;
        private WebBrowser webBrowser;
    }
}
