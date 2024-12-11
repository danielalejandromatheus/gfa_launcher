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
            label1 = new Label();
            button1 = new Button();
            progressBar1 = new ProgressBar();
            progressBar2 = new ProgressBar();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(439, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(288, 47);
            label1.TabIndex = 0;
            label1.Text = "GFA Launcher";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(983, 687);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(143, 47);
            button1.TabIndex = 0;
            button1.Text = "Start";
            button1.Click += button1_Click;
            // 
            // progressBar1
            // 
            progressBar1.BackColor = SystemColors.Highlight;
            progressBar1.ForeColor = Color.Black;
            progressBar1.Location = new Point(14, 613);
            progressBar1.Margin = new Padding(4, 5, 4, 5);
            progressBar1.Name = "progressBar1";
            progressBar1.RightToLeft = RightToLeft.Yes;
            progressBar1.Size = new Size(1111, 27);
            progressBar1.Step = 1;
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 0;
            progressBar1.Value = 50;
            // 
            // progressBar2
            // 
            progressBar2.BackColor = SystemColors.Highlight;
            progressBar2.ForeColor = Color.Black;
            progressBar2.Location = new Point(14, 650);
            progressBar2.Margin = new Padding(4, 5, 4, 5);
            progressBar2.Name = "progressBar2";
            progressBar2.RightToLeft = RightToLeft.Yes;
            progressBar2.Size = new Size(1111, 27);
            progressBar2.Step = 1;
            progressBar2.Style = ProgressBarStyle.Continuous;
            progressBar2.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(831, 687);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(143, 47);
            button2.TabIndex = 1;
            button2.Text = "Options";
            button2.Click += button2_Click;
            // 
            // Launcher
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1140, 737);
            Controls.Add(button2);
            Controls.Add(progressBar2);
            Controls.Add(progressBar1);
            Controls.Add(button1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            Name = "Launcher";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Launcher";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private Button button2;
    }
}
