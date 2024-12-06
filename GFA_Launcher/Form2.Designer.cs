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
            optionsDataBindingSource = new BindingSource(components);
            label15 = new Label();
            SoundValoume = new TrackBar();
            label14 = new Label();
            BGMValoume = new TrackBar();
            label13 = new Label();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            label5 = new Label();
            Language = new ComboBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ShadowType).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ViewRange).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CharacterEffectNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ViewCharacterRange).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)optionsDataBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SoundValoume).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BGMValoume).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(13, 8);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(345, 524);
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
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(337, 496);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Video";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // DynamicVideoSetting
            // 
            DynamicVideoSetting.AutoSize = true;
            DynamicVideoSetting.DataBindings.Add(new Binding("Checked", bindingSource, "DynamicVideoSetting", true));
            DynamicVideoSetting.Location = new Point(165, 57);
            DynamicVideoSetting.Name = "DynamicVideoSetting";
            DynamicVideoSetting.Size = new Size(129, 19);
            DynamicVideoSetting.TabIndex = 31;
            DynamicVideoSetting.Text = "Arena Optimization";
            DynamicVideoSetting.UseVisualStyleBackColor = true;
            // 
            // ScreenFrequency
            // 
            ScreenFrequency.DataBindings.Add(new Binding("SelectedItem", bindingSource, "ScreenFrequency", true));
            ScreenFrequency.DropDownStyle = ComboBoxStyle.DropDownList;
            ScreenFrequency.FormattingEnabled = true;
            ScreenFrequency.Location = new Point(165, 461);
            ScreenFrequency.Name = "ScreenFrequency";
            ScreenFrequency.Size = new Size(166, 23);
            ScreenFrequency.TabIndex = 30;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 464);
            label16.Name = "label16";
            label16.Size = new Size(100, 15);
            label16.TabIndex = 29;
            label16.Text = "Screen Frequency";
            // 
            // FpsLockValue
            // 
            FpsLockValue.DataBindings.Add(new Binding("SelectedItem", bindingSource, "FpsLockValue", true));
            FpsLockValue.DropDownStyle = ComboBoxStyle.DropDownList;
            FpsLockValue.FormattingEnabled = true;
            FpsLockValue.Location = new Point(165, 432);
            FpsLockValue.Name = "FpsLockValue";
            FpsLockValue.Size = new Size(166, 23);
            FpsLockValue.TabIndex = 28;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(6, 435);
            label12.Name = "label12";
            label12.Size = new Size(48, 15);
            label12.TabIndex = 27;
            label12.Text = "FPS cap";
            // 
            // SceneTexture
            // 
            SceneTexture.DataBindings.Add(new Binding("SelectedValue", bindingSource, "SceneTexture", true));
            SceneTexture.DisplayMember = "Display";
            SceneTexture.DropDownStyle = ComboBoxStyle.DropDownList;
            SceneTexture.FormattingEnabled = true;
            SceneTexture.Location = new Point(165, 403);
            SceneTexture.Name = "SceneTexture";
            SceneTexture.Size = new Size(166, 23);
            SceneTexture.TabIndex = 26;
            SceneTexture.ValueMember = "Value";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(6, 406);
            label11.Name = "label11";
            label11.Size = new Size(50, 15);
            label11.TabIndex = 25;
            label11.Text = "Textures";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(6, 377);
            label10.Name = "label10";
            label10.Size = new Size(54, 15);
            label10.TabIndex = 24;
            label10.Text = "Shadows";
            // 
            // ShadowLevel
            // 
            ShadowLevel.DataBindings.Add(new Binding("SelectedValue", bindingSource, "ShadowLevel", true, DataSourceUpdateMode.OnPropertyChanged));
            ShadowLevel.DisplayMember = "Display";
            ShadowLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            ShadowLevel.Location = new Point(165, 374);
            ShadowLevel.Name = "ShadowLevel";
            ShadowLevel.Size = new Size(166, 23);
            ShadowLevel.TabIndex = 23;
            ShadowLevel.ValueMember = "Value";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 348);
            label9.Name = "label9";
            label9.Size = new Size(28, 15);
            label9.TabIndex = 22;
            label9.Text = "Blur";
            // 
            // DepthOfField
            // 
            DepthOfField.DataBindings.Add(new Binding("SelectedValue", bindingSource, "DepthOfField", true));
            DepthOfField.DisplayMember = "Display";
            DepthOfField.DropDownStyle = ComboBoxStyle.DropDownList;
            DepthOfField.FormattingEnabled = true;
            DepthOfField.Location = new Point(165, 345);
            DepthOfField.Name = "DepthOfField";
            DepthOfField.Size = new Size(166, 23);
            DepthOfField.TabIndex = 21;
            DepthOfField.ValueMember = "Value";
            // 
            // CharacterTexture
            // 
            CharacterTexture.DataBindings.Add(new Binding("SelectedValue", bindingSource, "CharacterTexture", true));
            CharacterTexture.DisplayMember = "Display";
            CharacterTexture.DropDownStyle = ComboBoxStyle.DropDownList;
            CharacterTexture.FormattingEnabled = true;
            CharacterTexture.Location = new Point(165, 316);
            CharacterTexture.Name = "CharacterTexture";
            CharacterTexture.Size = new Size(166, 23);
            CharacterTexture.TabIndex = 20;
            CharacterTexture.ValueMember = "Value";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 319);
            label8.Name = "label8";
            label8.Size = new Size(46, 15);
            label8.TabIndex = 19;
            label8.Text = "Models";
            // 
            // ScreenSize
            // 
            ScreenSize.DataBindings.Add(new Binding("SelectedItem", bindingSource, "ScreenSize", true));
            ScreenSize.DropDownStyle = ComboBoxStyle.DropDownList;
            ScreenSize.FormattingEnabled = true;
            ScreenSize.Location = new Point(165, 287);
            ScreenSize.Name = "ScreenSize";
            ScreenSize.Size = new Size(166, 23);
            ScreenSize.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 290);
            label7.Name = "label7";
            label7.Size = new Size(63, 15);
            label7.TabIndex = 17;
            label7.Text = "Resolution";
            // 
            // ShadowType
            // 
            ShadowType.DataBindings.Add(new Binding("Value", bindingSource, "ShadowType", true));
            ShadowType.Location = new Point(165, 226);
            ShadowType.Maximum = 5;
            ShadowType.Minimum = 1;
            ShadowType.Name = "ShadowType";
            ShadowType.Size = new Size(166, 45);
            ShadowType.TabIndex = 16;
            ShadowType.TickStyle = TickStyle.Both;
            ShadowType.Value = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 239);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 15;
            label6.Text = "Shadow Type";
            // 
            // ViewRange
            // 
            ViewRange.DataBindings.Add(new Binding("Value", bindingSource, "ViewRange", true));
            ViewRange.Location = new Point(165, 175);
            ViewRange.Maximum = 5;
            ViewRange.Minimum = 1;
            ViewRange.Name = "ViewRange";
            ViewRange.Size = new Size(166, 45);
            ViewRange.TabIndex = 14;
            ViewRange.TickStyle = TickStyle.Both;
            ViewRange.Value = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 190);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 13;
            label4.Text = "View Range";
            // 
            // CharacterEffectNum
            // 
            CharacterEffectNum.DataBindings.Add(new Binding("Value", bindingSource, "CharacterEffectNum", true));
            CharacterEffectNum.Location = new Point(165, 124);
            CharacterEffectNum.Maximum = 25;
            CharacterEffectNum.Minimum = 1;
            CharacterEffectNum.Name = "CharacterEffectNum";
            CharacterEffectNum.Size = new Size(166, 45);
            CharacterEffectNum.TabIndex = 12;
            CharacterEffectNum.TickStyle = TickStyle.Both;
            CharacterEffectNum.Value = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 138);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 11;
            label2.Text = "Character Effect";
            // 
            // ViewCharacterRange
            // 
            ViewCharacterRange.DataBindings.Add(new Binding("Value", bindingSource, "ViewCharacterRange", true));
            ViewCharacterRange.Location = new Point(165, 73);
            ViewCharacterRange.Maximum = 40;
            ViewCharacterRange.Minimum = 1;
            ViewCharacterRange.Name = "ViewCharacterRange";
            ViewCharacterRange.Size = new Size(166, 45);
            ViewCharacterRange.TabIndex = 10;
            ViewCharacterRange.TickStyle = TickStyle.Both;
            ViewCharacterRange.Value = 1;
            // 
            // PPMonochrome
            // 
            PPMonochrome.AutoSize = true;
            PPMonochrome.DataBindings.Add(new Binding("Checked", bindingSource, "PPMonochrome", true));
            PPMonochrome.Location = new Point(165, 32);
            PPMonochrome.Name = "PPMonochrome";
            PPMonochrome.Size = new Size(57, 19);
            PPMonochrome.TabIndex = 9;
            PPMonochrome.Text = "Death";
            PPMonochrome.UseVisualStyleBackColor = true;
            // 
            // PPSepia
            // 
            PPSepia.AutoSize = true;
            PPSepia.DataBindings.Add(new Binding("Checked", bindingSource, "PPSepia", true));
            PPSepia.Location = new Point(6, 32);
            PPSepia.Name = "PPSepia";
            PPSepia.Size = new Size(60, 19);
            PPSepia.TabIndex = 8;
            PPSepia.Text = "Events";
            PPSepia.UseVisualStyleBackColor = true;
            // 
            // IsWindowedMode
            // 
            IsWindowedMode.AutoSize = true;
            IsWindowedMode.DataBindings.Add(new Binding("Checked", bindingSource, "IsWindowedMode", true));
            IsWindowedMode.Location = new Point(6, 57);
            IsWindowedMode.Name = "IsWindowedMode";
            IsWindowedMode.Size = new Size(117, 19);
            IsWindowedMode.TabIndex = 7;
            IsWindowedMode.Text = "Windowed Mode";
            IsWindowedMode.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 88);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 6;
            label3.Text = "Character";
            // 
            // HighSettingsBtn
            // 
            HighSettingsBtn.Location = new Point(285, 3);
            HighSettingsBtn.Name = "HighSettingsBtn";
            HighSettingsBtn.Size = new Size(46, 23);
            HighSettingsBtn.TabIndex = 3;
            HighSettingsBtn.Text = "High";
            HighSettingsBtn.UseVisualStyleBackColor = true;
            HighSettingsBtn.Click += button3_Click;
            // 
            // MediumSettingsBtn
            // 
            MediumSettingsBtn.Location = new Point(217, 3);
            MediumSettingsBtn.Name = "MediumSettingsBtn";
            MediumSettingsBtn.Size = new Size(62, 23);
            MediumSettingsBtn.TabIndex = 2;
            MediumSettingsBtn.Text = "Medium";
            MediumSettingsBtn.UseVisualStyleBackColor = true;
            MediumSettingsBtn.Click += button2_Click;
            // 
            // LowSettingsBtn
            // 
            LowSettingsBtn.Location = new Point(165, 3);
            LowSettingsBtn.Name = "LowSettingsBtn";
            LowSettingsBtn.Size = new Size(46, 23);
            LowSettingsBtn.TabIndex = 1;
            LowSettingsBtn.Text = "Low";
            LowSettingsBtn.UseVisualStyleBackColor = true;
            LowSettingsBtn.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 7);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
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
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(337, 496);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Sound";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // SoundMute
            // 
            SoundMute.AutoSize = true;
            SoundMute.DataBindings.Add(new Binding("Checked", bindingSource, "SoundMute", true));
            SoundMute.Location = new Point(6, 103);
            SoundMute.Name = "SoundMute";
            SoundMute.Size = new Size(66, 19);
            SoundMute.TabIndex = 35;
            SoundMute.Text = "Muted?";
            SoundMute.UseVisualStyleBackColor = true;
            // 
            // BGMType
            // 
            BGMType.DataBindings.Add(new Binding("SelectedValue", bindingSource, "BGMType", true));
            BGMType.DropDownStyle = ComboBoxStyle.DropDownList;
            BGMType.FormattingEnabled = true;
            BGMType.Location = new Point(165, 73);
            BGMType.Name = "BGMType";
            BGMType.Size = new Size(166, 23);
            BGMType.TabIndex = 34;
            BGMType.DisplayMember = "Display";
            BGMType.ValueMember = "Value";
            // 
            // optionsDataBindingSource
            // 
            optionsDataBindingSource.DataSource = typeof(OptionsData);
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(6, 76);
            label15.Name = "label15";
            label15.Size = new Size(63, 15);
            label15.TabIndex = 33;
            label15.Text = "Play Mode";
            // 
            // SoundValoume
            // 
            SoundValoume.BackColor = Color.FromArgb(249, 249, 249);
            SoundValoume.DataBindings.Add(new Binding("Value", bindingSource, "SoundValoume", true));
            SoundValoume.Location = new Point(165, 41);
            SoundValoume.Maximum = 100;
            SoundValoume.Name = "SoundValoume";
            SoundValoume.Size = new Size(166, 45);
            SoundValoume.TabIndex = 32;
            SoundValoume.TickStyle = TickStyle.None;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(6, 41);
            label14.Name = "label14";
            label14.Size = new Size(39, 15);
            label14.TabIndex = 31;
            label14.Text = "Audio";
            // 
            // BGMValoume
            // 
            BGMValoume.BackColor = Color.FromArgb(249, 249, 249);
            BGMValoume.DataBindings.Add(new Binding("Value", bindingSource, "BGMValoume", true));
            BGMValoume.Location = new Point(165, 6);
            BGMValoume.Maximum = 100;
            BGMValoume.Name = "BGMValoume";
            BGMValoume.Size = new Size(166, 45);
            BGMValoume.TabIndex = 30;
            BGMValoume.TickStyle = TickStyle.None;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(6, 6);
            label13.Name = "label13";
            label13.Size = new Size(33, 15);
            label13.TabIndex = 1;
            label13.Text = "BGM";
            // 
            // button4
            // 
            button4.Location = new Point(13, 576);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 7;
            button4.Text = "Cancel";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(198, 576);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 8;
            button5.Text = "Save";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(279, 576);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 9;
            button6.Text = "Default";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 540);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 10;
            label5.Text = "Language";
            // 
            // Language
            // 
            Language.DisplayMember = "Display";
            Language.DropDownStyle = ComboBoxStyle.DropDownList;
            Language.FormattingEnabled = true;
            Language.Location = new Point(182, 537);
            Language.Name = "Language";
            Language.Size = new Size(172, 23);
            Language.TabIndex = 29;
            Language.ValueMember = "Value";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 607);
            Controls.Add(Language);
            Controls.Add(label5);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form2";
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
            ((System.ComponentModel.ISupportInitialize)optionsDataBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)SoundValoume).EndInit();
            ((System.ComponentModel.ISupportInitialize)BGMValoume).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Label label5;
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
        private ComboBox Language;
        private CheckBox SoundMute;
        private ComboBox BGMType;
        private Label label15;
        private TrackBar SoundValoume;
        private Label label14;
        private TrackBar BGMValoume;
        private CheckBox DynamicVideoSetting;
        private ComboBox ScreenFrequency;
        private Label label16;
        private BindingSource optionsDataBindingSource;
    }
}