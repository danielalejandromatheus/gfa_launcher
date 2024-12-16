namespace GFA_Launcher
{
    partial class LanguageSelector
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bindingSource = new BindingSource();
            Language = new ComboBox();
            label5 = new Label();
            button5 = new Button();
            SuspendLayout();
            // 
            // Language
            // 
            Language.DataBindings.Add(new Binding("SelectedValue", bindingSource, "Language", true, DataSourceUpdateMode.OnPropertyChanged));
            Language.DisplayMember = "Display";
            Language.DropDownStyle = ComboBoxStyle.DropDownList;
            Language.FormattingEnabled = true;
            Language.Location = new Point(243, 14);
            Language.Margin = new Padding(4, 5, 4, 5);
            Language.Name = "Language";
            Language.Size = new Size(244, 33);
            Language.TabIndex = 31;
            Language.ValueMember = "Value";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(7, 19);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(89, 25);
            label5.TabIndex = 30;
            label5.Text = "Language";
            // 
            // button5
            // 
            button5.Location = new Point(380, 57);
            button5.Margin = new Padding(4, 5, 4, 5);
            button5.Name = "button5";
            button5.Size = new Size(107, 38);
            button5.TabIndex = 32;
            button5.Text = "Save";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // LanguageSelector
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 107);
            Controls.Add(button5);
            Controls.Add(Language);
            Controls.Add(label5);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "LanguageSelector";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Select Language";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private BindingSource bindingSource;
        private ComboBox Language;
        private Label label5;
        private Button button5;
    }
}