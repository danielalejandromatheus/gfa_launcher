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
            button1 = new CustomButton();
            button2 = new CustomButton();
            button3 = new CustomButton();
            StatusLabel = new Label();
            customButton1 = new CustomButton();
            LangButton = new CustomButton();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(1197, 595);
            button1.Margin = new Padding(6, 8, 6, 8);
            button1.Name = "button1";
            button1.Size = new Size(142, 140);
            button1.SpriteSheet = null;
            button1.TabIndex = 0;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.Location = new Point(1337, 712);
            button2.Margin = new Padding(6, 8, 6, 8);
            button2.Name = "button2";
            button2.Size = new Size(101, 101);
            button2.SpriteSheet = null;
            button2.TabIndex = 1;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button3.BackColor = Color.Transparent;
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.Location = new Point(1169, 773);
            button3.Name = "button3";
            button3.Size = new Size(103, 104);
            button3.SpriteSheet = null;
            button3.TabIndex = 2;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
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
            // customButton1
            // 
            customButton1.Location = new Point(1142, 250);
            customButton1.Name = "customButton1";
            customButton1.Size = new Size(34, 34);
            customButton1.SpriteSheet = null;
            customButton1.TabIndex = 3;
            customButton1.UseVisualStyleBackColor = true;
            customButton1.Click += customButton1_Click;
            // 
            // LangButton
            // 
            LangButton.Location = new Point(1169, 429);
            LangButton.Name = "LangButton";
            LangButton.Size = new Size(103, 103);
            LangButton.SpriteSheet = null;
            LangButton.TabIndex = 4;
            LangButton.UseVisualStyleBackColor = true;
            LangButton.Click += LangButton_Click;
            // 
            // Launcher
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Window;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1631, 954);
            Controls.Add(LangButton);
            Controls.Add(customButton1);
            Controls.Add(StatusLabel);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
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
    }
}
