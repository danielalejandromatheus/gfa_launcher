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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            StatusLabel = new Label();
            CloseButton = new CustomButton();
            LangButton = new CustomButton();
            ScanButton = new CustomButton();
            OptionsButton = new CustomButton();
            LaunchButton = new CustomButton();
            SuspendLayout();
            // 
            // StatusLabel
            // 
            StatusLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StatusLabel.AutoSize = true;
            StatusLabel.BackColor = Color.Transparent;
            StatusLabel.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StatusLabel.ForeColor = Color.WhiteSmoke;
            StatusLabel.Location = new Point(329, 538);
            StatusLabel.MaximumSize = new Size(620, 40);
            StatusLabel.MinimumSize = new Size(620, 40);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(620, 40);
            StatusLabel.TabIndex = 0;
            StatusLabel.Text = "Placeholder";
            StatusLabel.Click += StatusLabel_Click;
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(787, 171);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(26, 26);
            CloseButton.SpriteSheet = Properties.Resources.Bitmap208;
            CloseButton.TabIndex = 1;
            CloseButton.Text = "customButton1";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // LangButton
            // 
            LangButton.BackColor = Color.Transparent;
            LangButton.Location = new Point(808, 297);
            LangButton.Name = "LangButton";
            LangButton.Size = new Size(71, 71);
            LangButton.SpriteSheet = Properties.Resources.ENG;
            LangButton.TabIndex = 2;
            LangButton.UseVisualStyleBackColor = false;
            LangButton.Click += LangButton_Click;
            // 
            // ScanButton
            // 
            ScanButton.Location = new Point(924, 491);
            ScanButton.Name = "ScanButton";
            ScanButton.Size = new Size(71, 71);
            ScanButton.SpriteSheet = Properties.Resources.Bitmap210;
            ScanButton.TabIndex = 3;
            ScanButton.UseVisualStyleBackColor = true;
            ScanButton.Click += ScanButton_Click;
            // 
            // OptionsButton
            // 
            OptionsButton.Location = new Point(809, 534);
            OptionsButton.Name = "OptionsButton";
            OptionsButton.Size = new Size(71, 71);
            OptionsButton.SpriteSheet = Properties.Resources.Bitmap231;
            OptionsButton.TabIndex = 4;
            OptionsButton.UseVisualStyleBackColor = true;
            OptionsButton.Click += OptionsButton_Click;
            // 
            // LaunchButton
            // 
            LaunchButton.Location = new Point(828, 410);
            LaunchButton.Name = "LaunchButton";
            LaunchButton.Size = new Size(97, 97);
            LaunchButton.SpriteSheet = Properties.Resources.Bitmap232;
            LaunchButton.TabIndex = 5;
            LaunchButton.UseVisualStyleBackColor = true;
            LaunchButton.Click += LaunchButton_Click;
            // 
            // Launcher
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Lime;
            BackgroundImage = Properties.Resources.LauncherGFA;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1127, 659);
            Controls.Add(LaunchButton);
            Controls.Add(OptionsButton);
            Controls.Add(ScanButton);
            Controls.Add(LangButton);
            Controls.Add(CloseButton);
            Controls.Add(StatusLabel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(6, 8, 6, 8);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
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
        private WebBrowser webBrowser;
        private CustomButton CloseButton;
        private CustomButton LangButton;
        private CustomButton ScanButton;
        private CustomButton OptionsButton;
        private CustomButton LaunchButton;
    }
}
