using System.Windows.Forms;

namespace GFA_Launcher
{
    partial class Form2
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
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            DynamicVideoSetting = new CheckBox();
            bindingSource = new BindingSource(components);
            ScreenFrequency = new ComboBox();
            label16 = new Label();
            FpsLockValue = new ComboBox();
            label12 = new Label();
            SceneTexture = new ComboBox();
            label11 = new Label();
            label10 = new Label();
            ShadowLevel = new ComboBox();
            label9 = new Label();
            DepthOfField = new ComboBox();
            CharacterTexture = new ComboBox();
            label8 = new Label();
            ScreenSize = new ComboBox();
            label7 = new Label();
            ShadowType = new TrackBar();
            label6 = new Label();
            ViewRange = new TrackBar();
            label4 = new Label();
            CharacterEffectNum = new TrackBar();
            label2 = new Label();
            ViewCharacterRange = new TrackBar();
            PPMonochrome = new CheckBox();
            PPSepia = new CheckBox();
            IsWindowedMode = new CheckBox();
            label3 = new Label();
            HighSettingsBtn = new Button();
            MediumSettingsBtn = new Button();
            LowSettingsBtn = new Button();
            label1 = new Label();
            tabPage2 = new TabPage();
            SoundMute = new CheckBox();
            BGMType = new ComboBox();
            label15 = new Label();
            SoundValoume = new TrackBar();
            label14 = new Label();
            BGMValoume = new TrackBar();
            label13 = new Label();
            tabPage3 = new TabPage();
            groupBox1 = new GroupBox();
            AutoLoginBox = new ComboBox();
            label19 = new Label();
            Remove = new Button();
            LoginButton = new Button();
            label18 = new Label();
            button1 = new Button();
            label17 = new Label();
            PasswordField = new TextBox();
            AccountField = new TextBox();
            AccountsBox = new ListBox();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShadowType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ViewRange).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CharacterEffectNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ViewCharacterRange).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SoundValoume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BGMValoume).BeginInit();
            tabPage3.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(19, 13);
            tabControl1.Margin = new Padding(4, 5, 4, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(493, 873);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(DynamicVideoSetting);
            tabPage1.Controls.Add(ScreenFrequency);
            tabPage1.Controls.Add(label16);
            tabPage1.Controls.Add(FpsLockValue);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(SceneTexture);
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(ShadowLevel);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(DepthOfField);
            tabPage1.Controls.Add(CharacterTexture);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(ScreenSize);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(ShadowType);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(ViewRange);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(CharacterEffectNum);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(ViewCharacterRange);
            tabPage1.Controls.Add(PPMonochrome);
            tabPage1.Controls.Add(PPSepia);
            tabPage1.Controls.Add(IsWindowedMode);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(HighSettingsBtn);
            tabPage1.Controls.Add(MediumSettingsBtn);
            tabPage1.Controls.Add(LowSettingsBtn);
            tabPage1.Controls.Add(label1);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Margin = new Padding(4, 5, 4, 5);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 5, 4, 5);
            tabPage1.Size = new Size(485, 835);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Video";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // DynamicVideoSetting
            // 
            DynamicVideoSetting.AutoSize = true;
            DynamicVideoSetting.DataBindings.Add(new Binding("Checked", bindingSource, "DynamicVideoSetting", true));
            DynamicVideoSetting.Location = new Point(236, 95);
            DynamicVideoSetting.Margin = new Padding(4, 5, 4, 5);
            DynamicVideoSetting.Name = "DynamicVideoSetting";
            DynamicVideoSetting.Size = new Size(192, 29);
            DynamicVideoSetting.TabIndex = 31;
            DynamicVideoSetting.Text = "Arena Optimization";
            DynamicVideoSetting.UseVisualStyleBackColor = true;
            // 
            // ScreenFrequency
            // 
            ScreenFrequency.DataBindings.Add(new Binding("SelectedItem", bindingSource, "ScreenFrequency", true));
            ScreenFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
            ScreenFrequency.FormattingEnabled = true;
            ScreenFrequency.Location = new Point(236, 768);
            ScreenFrequency.Margin = new Padding(4, 5, 4, 5);
            ScreenFrequency.Name = "ScreenFrequency";
            ScreenFrequency.Size = new Size(235, 33);
            ScreenFrequency.TabIndex = 30;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(9, 773);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(150, 25);
            label16.TabIndex = 29;
            label16.Text = "Screen Frequency";
            // 
            // FpsLockValue
            // 
            FpsLockValue.DataBindings.Add(new Binding("SelectedItem", bindingSource, "FpsLockValue", true));
            FpsLockValue.DropDownStyle = ComboBoxStyle.DropDownList;
            FpsLockValue.FormattingEnabled = true;
            FpsLockValue.Location = new Point(236, 720);
            FpsLockValue.Margin = new Padding(4, 5, 4, 5);
            FpsLockValue.Name = "FpsLockValue";
            FpsLockValue.Size = new Size(235, 33);
            FpsLockValue.TabIndex = 28;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(9, 725);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(74, 25);
            label12.TabIndex = 27;
            label12.Text = "FPS cap";
            // 
            // SceneTexture
            // 
            SceneTexture.DataBindings.Add(new Binding("SelectedValue", bindingSource, "SceneTexture", true));
            SceneTexture.DisplayMember = "Display";
            SceneTexture.DropDownStyle = ComboBoxStyle.DropDownList;
            SceneTexture.FormattingEnabled = true;
            SceneTexture.Location = new Point(236, 672);
            SceneTexture.Margin = new Padding(4, 5, 4, 5);
            SceneTexture.Name = "SceneTexture";
            SceneTexture.Size = new Size(235, 33);
            SceneTexture.TabIndex = 26;
            SceneTexture.ValueMember = "Value";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(9, 677);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(75, 25);
            label11.TabIndex = 25;
            label11.Text = "Textures";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(9, 628);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(84, 25);
            label10.TabIndex = 24;
            label10.Text = "Shadows";
            // 
            // ShadowLevel
            // 
            ShadowLevel.DataBindings.Add(new Binding("SelectedValue", bindingSource, "ShadowLevel", true, DataSourceUpdateMode.OnPropertyChanged));
            ShadowLevel.DisplayMember = "Display";
            ShadowLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            ShadowLevel.Location = new Point(236, 623);
            ShadowLevel.Margin = new Padding(4, 5, 4, 5);
            ShadowLevel.Name = "ShadowLevel";
            ShadowLevel.Size = new Size(235, 33);
            ShadowLevel.TabIndex = 23;
            ShadowLevel.ValueMember = "Value";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(9, 580);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(42, 25);
            label9.TabIndex = 22;
            label9.Text = "Blur";
            // 
            // DepthOfField
            // 
            DepthOfField.DataBindings.Add(new Binding("SelectedValue", bindingSource, "DepthOfField", true));
            DepthOfField.DisplayMember = "Display";
            DepthOfField.DropDownStyle = ComboBoxStyle.DropDownList;
            DepthOfField.FormattingEnabled = true;
            DepthOfField.Location = new Point(236, 575);
            DepthOfField.Margin = new Padding(4, 5, 4, 5);
            DepthOfField.Name = "DepthOfField";
            DepthOfField.Size = new Size(235, 33);
            DepthOfField.TabIndex = 21;
            DepthOfField.ValueMember = "Value";
            // 
            // CharacterTexture
            // 
            CharacterTexture.DataBindings.Add(new Binding("SelectedValue", bindingSource, "CharacterTexture", true));
            CharacterTexture.DisplayMember = "Display";
            CharacterTexture.DropDownStyle = ComboBoxStyle.DropDownList;
            CharacterTexture.FormattingEnabled = true;
            CharacterTexture.Location = new Point(236, 527);
            CharacterTexture.Margin = new Padding(4, 5, 4, 5);
            CharacterTexture.Name = "CharacterTexture";
            CharacterTexture.Size = new Size(235, 33);
            CharacterTexture.TabIndex = 20;
            CharacterTexture.ValueMember = "Value";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(9, 532);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(71, 25);
            label8.TabIndex = 19;
            label8.Text = "Models";
            // 
            // ScreenSize
            // 
            ScreenSize.DataBindings.Add(new Binding("SelectedItem", bindingSource, "ScreenSize", true));
            ScreenSize.DropDownStyle = ComboBoxStyle.DropDownList;
            ScreenSize.FormattingEnabled = true;
            ScreenSize.Location = new Point(236, 478);
            ScreenSize.Margin = new Padding(4, 5, 4, 5);
            ScreenSize.Name = "ScreenSize";
            ScreenSize.Size = new Size(235, 33);
            ScreenSize.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 483);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(95, 25);
            label7.TabIndex = 17;
            label7.Text = "Resolution";
            // 
            // ShadowType
            // 
            ShadowType.DataBindings.Add(new Binding("Value", bindingSource, "ShadowType", true));
            ShadowType.Location = new Point(236, 377);
            ShadowType.Margin = new Padding(4, 5, 4, 5);
            ShadowType.Maximum = 5;
            ShadowType.Minimum = 1;
            ShadowType.Name = "ShadowType";
            ShadowType.Size = new Size(237, 69);
            ShadowType.TabIndex = 16;
            ShadowType.TickStyle = TickStyle.Both;
            ShadowType.Value = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 398);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(118, 25);
            label6.TabIndex = 15;
            label6.Text = "Shadow Type";
            // 
            // ViewRange
            // 
            ViewRange.DataBindings.Add(new Binding("Value", bindingSource, "ViewRange", true));
            ViewRange.Location = new Point(236, 292);
            ViewRange.Margin = new Padding(4, 5, 4, 5);
            ViewRange.Maximum = 5;
            ViewRange.Minimum = 1;
            ViewRange.Name = "ViewRange";
            ViewRange.Size = new Size(237, 69);
            ViewRange.TabIndex = 14;
            ViewRange.TickStyle = TickStyle.Both;
            ViewRange.Value = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 317);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(104, 25);
            label4.TabIndex = 13;
            label4.Text = "View Range";
            // 
            // CharacterEffectNum
            // 
            CharacterEffectNum.DataBindings.Add(new Binding("Value", bindingSource, "CharacterEffectNum", true));
            CharacterEffectNum.Location = new Point(236, 207);
            CharacterEffectNum.Margin = new Padding(4, 5, 4, 5);
            CharacterEffectNum.Maximum = 25;
            CharacterEffectNum.Minimum = 1;
            CharacterEffectNum.Name = "CharacterEffectNum";
            CharacterEffectNum.Size = new Size(237, 69);
            CharacterEffectNum.TabIndex = 12;
            CharacterEffectNum.TickStyle = TickStyle.Both;
            CharacterEffectNum.Value = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 230);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(135, 25);
            label2.TabIndex = 11;
            label2.Text = "Character Effect";
            // 
            // ViewCharacterRange
            // 
            ViewCharacterRange.DataBindings.Add(new Binding("Value", bindingSource, "ViewCharacterRange", true));
            ViewCharacterRange.Location = new Point(236, 122);
            ViewCharacterRange.Margin = new Padding(4, 5, 4, 5);
            ViewCharacterRange.Maximum = 40;
            ViewCharacterRange.Minimum = 1;
            ViewCharacterRange.Name = "ViewCharacterRange";
            ViewCharacterRange.Size = new Size(237, 69);
            ViewCharacterRange.TabIndex = 10;
            ViewCharacterRange.TickStyle = TickStyle.Both;
            ViewCharacterRange.Value = 1;
            // 
            // PPMonochrome
            // 
            PPMonochrome.AutoSize = true;
            PPMonochrome.DataBindings.Add(new Binding("Checked", bindingSource, "PPMonochrome", true));
            PPMonochrome.Location = new Point(236, 53);
            PPMonochrome.Margin = new Padding(4, 5, 4, 5);
            PPMonochrome.Name = "PPMonochrome";
            PPMonochrome.Size = new Size(85, 29);
            PPMonochrome.TabIndex = 9;
            PPMonochrome.Text = "Death";
            PPMonochrome.UseVisualStyleBackColor = true;
            // 
            // PPSepia
            // 
            PPSepia.AutoSize = true;
            PPSepia.DataBindings.Add(new Binding("Checked", bindingSource, "PPSepia", true));
            PPSepia.Location = new Point(9, 53);
            PPSepia.Margin = new Padding(4, 5, 4, 5);
            PPSepia.Name = "PPSepia";
            PPSepia.Size = new Size(89, 29);
            PPSepia.TabIndex = 8;
            PPSepia.Text = "Events";
            PPSepia.UseVisualStyleBackColor = true;
            // 
            // IsWindowedMode
            // 
            IsWindowedMode.AutoSize = true;
            IsWindowedMode.DataBindings.Add(new Binding("Checked", bindingSource, "IsWindowedMode", true));
            IsWindowedMode.Location = new Point(9, 95);
            IsWindowedMode.Margin = new Padding(4, 5, 4, 5);
            IsWindowedMode.Name = "IsWindowedMode";
            IsWindowedMode.Size = new Size(176, 29);
            IsWindowedMode.TabIndex = 7;
            IsWindowedMode.Text = "Windowed Mode";
            IsWindowedMode.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 147);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(86, 25);
            label3.TabIndex = 6;
            label3.Text = "Character";
            // 
            // HighSettingsBtn
            // 
            HighSettingsBtn.Location = new Point(407, 5);
            HighSettingsBtn.Margin = new Padding(4, 5, 4, 5);
            HighSettingsBtn.Name = "HighSettingsBtn";
            HighSettingsBtn.Size = new Size(66, 38);
            HighSettingsBtn.TabIndex = 3;
            HighSettingsBtn.Text = "High";
            HighSettingsBtn.UseVisualStyleBackColor = true;
            HighSettingsBtn.Click += button3_Click;
            // 
            // MediumSettingsBtn
            // 
            MediumSettingsBtn.Location = new Point(310, 5);
            MediumSettingsBtn.Margin = new Padding(4, 5, 4, 5);
            MediumSettingsBtn.Name = "MediumSettingsBtn";
            MediumSettingsBtn.Size = new Size(89, 38);
            MediumSettingsBtn.TabIndex = 2;
            MediumSettingsBtn.Text = "Medium";
            MediumSettingsBtn.UseVisualStyleBackColor = true;
            MediumSettingsBtn.Click += button2_Click;
            // 
            // LowSettingsBtn
            // 
            LowSettingsBtn.Location = new Point(236, 5);
            LowSettingsBtn.Margin = new Padding(4, 5, 4, 5);
            LowSettingsBtn.Name = "LowSettingsBtn";
            LowSettingsBtn.Size = new Size(66, 38);
            LowSettingsBtn.TabIndex = 1;
            LowSettingsBtn.Text = "Low";
            LowSettingsBtn.UseVisualStyleBackColor = true;
            LowSettingsBtn.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 12);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(68, 25);
            label1.TabIndex = 0;
            label1.Text = "Quality";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(SoundMute);
            tabPage2.Controls.Add(BGMType);
            tabPage2.Controls.Add(label15);
            tabPage2.Controls.Add(SoundValoume);
            tabPage2.Controls.Add(label14);
            tabPage2.Controls.Add(BGMValoume);
            tabPage2.Controls.Add(label13);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Margin = new Padding(4, 5, 4, 5);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4, 5, 4, 5);
            tabPage2.Size = new Size(485, 835);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Sound";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // SoundMute
            // 
            SoundMute.AutoSize = true;
            SoundMute.DataBindings.Add(new Binding("Checked", bindingSource, "SoundMute", true));
            SoundMute.Location = new Point(9, 172);
            SoundMute.Margin = new Padding(4, 5, 4, 5);
            SoundMute.Name = "SoundMute";
            SoundMute.Size = new Size(98, 29);
            SoundMute.TabIndex = 35;
            SoundMute.Text = "Muted?";
            SoundMute.UseVisualStyleBackColor = true;
            // 
            // BGMType
            // 
            BGMType.DataBindings.Add(new Binding("SelectedValue", bindingSource, "BGMType", true));
            BGMType.DisplayMember = "Display";
            BGMType.DropDownStyle = ComboBoxStyle.DropDownList;
            BGMType.FormattingEnabled = true;
            BGMType.Location = new Point(236, 122);
            BGMType.Margin = new Padding(4, 5, 4, 5);
            BGMType.Name = "BGMType";
            BGMType.Size = new Size(235, 33);
            BGMType.TabIndex = 34;
            BGMType.ValueMember = "Value";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(9, 127);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(96, 25);
            label15.TabIndex = 33;
            label15.Text = "Play Mode";
            // 
            // SoundValoume
            // 
            SoundValoume.BackColor = Color.FromArgb(249, 249, 249);
            SoundValoume.DataBindings.Add(new Binding("Value", bindingSource, "SoundValoume", true));
            SoundValoume.Location = new Point(236, 68);
            SoundValoume.Margin = new Padding(4, 5, 4, 5);
            SoundValoume.Maximum = 100;
            SoundValoume.Name = "SoundValoume";
            SoundValoume.Size = new Size(237, 69);
            SoundValoume.TabIndex = 32;
            SoundValoume.TickStyle = TickStyle.None;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(9, 68);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(60, 25);
            label14.TabIndex = 31;
            label14.Text = "Audio";
            // 
            // BGMValoume
            // 
            BGMValoume.BackColor = Color.FromArgb(249, 249, 249);
            BGMValoume.DataBindings.Add(new Binding("Value", bindingSource, "BGMValoume", true));
            BGMValoume.Location = new Point(236, 10);
            BGMValoume.Margin = new Padding(4, 5, 4, 5);
            BGMValoume.Maximum = 100;
            BGMValoume.Name = "BGMValoume";
            BGMValoume.Size = new Size(237, 69);
            BGMValoume.TabIndex = 30;
            BGMValoume.TickStyle = TickStyle.None;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(9, 10);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(50, 25);
            label13.TabIndex = 1;
            label13.Text = "BGM";
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(groupBox1);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(485, 835);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Extras";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(AutoLoginBox);
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(Remove);
            groupBox1.Controls.Add(LoginButton);
            groupBox1.Controls.Add(label18);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(PasswordField);
            groupBox1.Controls.Add(AccountField);
            groupBox1.Controls.Add(AccountsBox);
            groupBox1.Location = new Point(3, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(478, 400);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Account Management";
            // 
            // AutoLoginBox
            // 
            AutoLoginBox.DataBindings.Add(new Binding("SelectedValue", bindingSource, "AutoLogin", true));
            AutoLoginBox.DisplayMember = "Display";
            AutoLoginBox.DropDownStyle = ComboBoxStyle.DropDownList;
            AutoLoginBox.FormattingEnabled = true;
            AutoLoginBox.Location = new Point(6, 354);
            AutoLoginBox.Name = "AutoLoginBox";
            AutoLoginBox.Size = new Size(466, 33);
            AutoLoginBox.TabIndex = 3;
            AutoLoginBox.ValueMember = "Value";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(6, 326);
            label19.Name = "label19";
            label19.Size = new Size(100, 25);
            label19.TabIndex = 8;
            label19.Text = "Auto Login";
            // 
            // Remove
            // 
            Remove.Location = new Point(242, 192);
            Remove.Name = "Remove";
            Remove.Size = new Size(230, 34);
            Remove.TabIndex = 7;
            Remove.Text = "Remove";
            Remove.UseVisualStyleBackColor = true;
            Remove.Click += Remove_Click;
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(6, 192);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(230, 34);
            LoginButton.TabIndex = 6;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(249, 224);
            label18.Name = "label18";
            label18.Size = new Size(87, 25);
            label18.TabIndex = 4;
            label18.Text = "Password";
            // 
            // button1
            // 
            button1.Location = new Point(6, 289);
            button1.Name = "button1";
            button1.Size = new Size(466, 34);
            button1.TabIndex = 5;
            button1.Text = "Add Account";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(6, 224);
            label17.Name = "label17";
            label17.Size = new Size(77, 25);
            label17.TabIndex = 3;
            label17.Text = "Account";
            // 
            // PasswordField
            // 
            PasswordField.BorderStyle = BorderStyle.FixedSingle;
            PasswordField.Location = new Point(242, 252);
            PasswordField.Name = "PasswordField";
            PasswordField.PasswordChar = '*';
            PasswordField.Size = new Size(230, 31);
            PasswordField.TabIndex = 2;
            // 
            // AccountField
            // 
            AccountField.BorderStyle = BorderStyle.FixedSingle;
            AccountField.Location = new Point(6, 252);
            AccountField.Name = "AccountField";
            AccountField.Size = new Size(230, 31);
            AccountField.TabIndex = 1;
            // 
            // AccountsBox
            // 
            AccountsBox.DisplayMember = "Username";
            AccountsBox.FormattingEnabled = true;
            AccountsBox.ItemHeight = 25;
            AccountsBox.Location = new Point(6, 32);
            AccountsBox.Name = "AccountsBox";
            AccountsBox.Size = new Size(466, 154);
            AccountsBox.TabIndex = 0;
            AccountsBox.MouseDoubleClick += AccountsBox_MouseDoubleClick;
            // 
            // button4
            // 
            button4.Location = new Point(23, 896);
            button4.Margin = new Padding(4, 5, 4, 5);
            button4.Name = "button4";
            button4.Size = new Size(107, 38);
            button4.TabIndex = 7;
            button4.Text = "Cancel";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(287, 896);
            button5.Margin = new Padding(4, 5, 4, 5);
            button5.Name = "button5";
            button5.Size = new Size(107, 38);
            button5.TabIndex = 8;
            button5.Text = "Save";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(403, 896);
            button6.Margin = new Padding(4, 5, 4, 5);
            button6.Name = "button6";
            button6.Size = new Size(107, 38);
            button6.TabIndex = 9;
            button6.Text = "Default";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(529, 950);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form2";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuration";
            Load += Form2_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)ShadowType).EndInit();
            ((System.ComponentModel.ISupportInitialize)ViewRange).EndInit();
            ((System.ComponentModel.ISupportInitialize)CharacterEffectNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)ViewCharacterRange).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SoundValoume).EndInit();
            ((System.ComponentModel.ISupportInitialize)BGMValoume).EndInit();
            tabPage3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource bindingSource;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Label label1;
        private Button LowSettingsBtn;
        private Button MediumSettingsBtn;
        private Button HighSettingsBtn;
        private Label label3;
        private Button button4;
        private Button button5;
        private CheckBox IsWindowedMode;
        private Button button6;
        private CheckBox PPMonochrome;
        private CheckBox PPSepia;
        private TrackBar ViewCharacterRange;
        private TrackBar ViewRange;
        private Label label4;
        private TrackBar CharacterEffectNum;
        private Label label2;
        private Label label7;
        private TrackBar ShadowType;
        private Label label6;
        private Label label9;
        private ComboBox DepthOfField;
        private ComboBox CharacterTexture;
        private Label label8;
        private ComboBox ScreenSize;
        private ComboBox SceneTexture;
        private Label label11;
        private Label label10;
        private ComboBox ShadowLevel;
        private ComboBox FpsLockValue;
        private Label label12;
        private Label label13;
        private CheckBox SoundMute;
        private ComboBox BGMType;
        private Label label15;
        private TrackBar SoundValoume;
        private Label label14;
        private TrackBar BGMValoume;
        private CheckBox DynamicVideoSetting;
        private ComboBox ScreenFrequency;
        private Label label16;
        private TabPage tabPage3;
        private GroupBox groupBox1;
        private Label label18;
        private Label label17;
        private TextBox PasswordField;
        private TextBox AccountField;
        private ListBox AccountsBox;
        private ContextMenuStrip contextMenuStrip1;
        private Button button1;
        private Button LoginButton;
        private Button Remove;
        private ComboBox AutoLoginBox;
        private Label label19;
    }
}