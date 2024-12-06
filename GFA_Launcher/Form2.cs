using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GFA_Launcher
{

    // Structure of options
    public partial class Form2 : Form
    {
        OptionsData options;
        public Form2()
        {
            options = new OptionsData();
            InitializeComponent();
            bindingSource.DataSource = options;
            Language.DataSource = options.languageItems;
            ScreenSize.DataSource = options.screenSizeList;
            ShadowLevel.DataSource = options.shadowLevelItems;
            SceneTexture.DataSource = options.sceneTextureItems;
            CharacterTexture.DataSource = options.characterTextureItems;
            DepthOfField.DataSource = options.depthOfFieldList;
            BGMType.DataSource = options.bgmTypeItems;
            FpsLockValue.DataSource = options.fpsLockValueList;
            ScreenFrequency.DataSource = options.screenFrequencyList;
        }
        private void setLowSettings()
        {
            options.ViewCharacterRange = 1;
            options.ViewRange = 1;
            options.CharacterEffectNum = 1;
            options.ShadowLevel = "1";
            options.ShadowType = 1;
            options.SceneTexture = "0";
            options.CharacterTexture = "0";
            options.PPMonochrome = false;
            options.PPSepia = false;
            options.DynamicVideoSetting = true;
            options.DepthOfField = "0";
            options.FpsLockValue = "30";
            options.ScreenFrequency = "30";
        }
        private void setMediumSettings()
        {
            options.ViewCharacterRange = 20;
            options.ViewRange = 3;
            options.CharacterEffectNum = 13;
            options.ShadowLevel = "2";
            options.ShadowType = 3;
            options.SceneTexture = "1";
            options.CharacterTexture = "1";
            options.PPMonochrome = true;
            options.PPSepia = true;
            options.DynamicVideoSetting = true;
            options.DepthOfField = "1";
            options.FpsLockValue = "60";
            options.ScreenFrequency = "60";
        }
        private void setHighSettings()
        {
            options.ViewCharacterRange = 40;
            options.ViewRange = 5;
            options.CharacterEffectNum = 25;
            options.ShadowLevel = "3";
            options.ShadowType = 5;
            options.SceneTexture = "1";
            options.CharacterTexture = "1";
            options.PPMonochrome = true;
            options.PPSepia = true;
            options.DynamicVideoSetting = true;
            options.DepthOfField = "3";
            options.FpsLockValue = "120";
            options.ScreenFrequency = "120";
        }
        private void setDefaultSettings()
        {
            options.FullScreenMode = 0;
            options.ScreenSize = "800x600";
            options.ViewCharacterRange = 20;
            options.ViewRange = 3;
            options.CharacterEffectNum = 13;
            options.ShadowLevel = "2";
            options.ShadowType = 3;
            options.SceneTexture = "1";
            options.CharacterTexture = "1";
            options.PPMonochrome = true;
            options.PPSepia = true;
            options.DynamicVideoSetting = true;
            options.DepthOfField = "0";
            options.FpsLockValue = "60";
            options.ScreenFrequency = "60";
            options.BGMType = "0";
            options.BGMValoume = 100;
            options.SoundValoume = 100;
            options.SoundMute = false;
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            setLowSettings();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setMediumSettings();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setHighSettings();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            setDefaultSettings();
        }
    }
}
