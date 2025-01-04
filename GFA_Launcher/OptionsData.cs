
using System.ComponentModel;
using System.Text;
using IniParser;
using IniParser.Model;
namespace GFA_Launcher
{
    public class OptionsData : INotifyPropertyChanged
    {
        private IniData iniDictionary = new IniData();
        private int fullScreenMode; //0 = Windowed, 1 = Fullscreen
        public int FullScreenMode
        {
            get { return fullScreenMode; }
            set
            {
                fullScreenMode = value;
                OnPropertyChanged(nameof(FullScreenMode));
                OnPropertyChanged(nameof(IsWindowedMode));
            }
        }
        public bool IsWindowedMode
        {
            get => FullScreenMode != 1;
            set => FullScreenMode = value ? 0 : 1;
        }
        private string screenSize; // 
        public string ScreenSize
        {
            get { return screenSize; }
            set
            {
                screenSize = value;
                OnPropertyChanged(nameof(ScreenSize));
            }
        }
        private int viewCharacterRange; // 1 ~ 40
        public int ViewCharacterRange
        {
            get { return viewCharacterRange; }
            set
            {
                viewCharacterRange = value;
                OnPropertyChanged(nameof(ViewCharacterRange));
            }
        }
        private int viewRange; // 1 ~ 5
        public int ViewRange
        {
            get { return viewRange; }
            set
            {
                viewRange = value;
                OnPropertyChanged(nameof(ViewRange));
            }
        }
        private int characterEffectNum; // 1 ~ 25
        public int CharacterEffectNum
        {
            get { return characterEffectNum; }
            set
            {
                characterEffectNum = value;
                OnPropertyChanged(nameof(CharacterEffectNum));
            }
        }
        private string shadowLevel; //1 ~ 3
        public string ShadowLevel
        {
            get { return shadowLevel; }
            set
            {
                shadowLevel = value;
                OnPropertyChanged(nameof(ShadowLevel));
            }
        }
        private int shadowType; // 1 ~ 5
        public int ShadowType
        {
            get { return shadowType; }
            set
            {
                shadowType = value;
                OnPropertyChanged(nameof(ShadowType));
            }
        }
        private string sceneTexture; // 0 / 1
        public string SceneTexture
        {
            get { return sceneTexture; }
            set
            {
                sceneTexture = value;
                OnPropertyChanged(nameof(SceneTexture));
            }
        }
        private string characterTexture; // 0 / 1
        public string CharacterTexture
        {
            get { return characterTexture; }
            set
            {
                characterTexture = value;
                OnPropertyChanged(nameof(CharacterTexture));
            }
        }
        private int pPMonochrome; // 0 / 1
        public bool PPMonochrome
        {
            get { return pPMonochrome == 1; }
            set
            {
                int tempValue = value ? 1 : 0;
                pPMonochrome = tempValue;
                OnPropertyChanged(nameof(PPMonochrome));
            }
        }
        private int pPSepia; // 0 / 1
        public bool PPSepia
        {
            get { return pPSepia == 1; }
            set
            {
                int tempValue = value ? 1 : 0;
                pPSepia = tempValue;
                OnPropertyChanged(nameof(PPSepia));
            }
        }
        private int dynamicVideoSetting; // 0 / 1
        public bool DynamicVideoSetting
        {
            get { return dynamicVideoSetting == 1; }
            set
            {
                int tempValue = value ? 1 : 0;
                dynamicVideoSetting = tempValue;
                OnPropertyChanged(nameof(DynamicVideoSetting));
            }
        }
        private string depthOfField; //0 / 1
        public string DepthOfField
        {
            get { return depthOfField; }
            set
            {
                depthOfField = value;
                OnPropertyChanged(nameof(DepthOfField));
            }
        }
        private string fpsLockValue; // 30 / 60 / 120
        public string FpsLockValue
        {
            get { return fpsLockValue; }
            set
            {
                fpsLockValue = value;
                OnPropertyChanged(nameof(FpsLockValue));
            }
        }
        private string screenFrequency; // 60 / 75 / 120 / 144 / 240 / 300
        public string ScreenFrequency
        {
            get { return screenFrequency; }
            set
            {
                screenFrequency = value;
                OnPropertyChanged(nameof(ScreenFrequency));
            }
        }
        private string bgmType; // 0 / 1 / 2
        public string BGMType
        {
            get { return bgmType; }
            set
            {
                bgmType = value;
                OnPropertyChanged(nameof(BGMType));
            }
        }
        private double bgmValoume; // 0 to 1
        public int BGMValoume
        {
            get => (int)Math.Round(bgmValoume * 100);
            set
            {
                bgmValoume = (double)value / 100;
                OnPropertyChanged(nameof(BGMValoume));
            }
        }
        private double soundValoume; // 0 to 1
        public int SoundValoume
        {
            //round then multiply by 100 then return integer
            //convert double to int
            get { return (int)Math.Round(soundValoume * 100); }
            set
            {
                soundValoume = (double)value / 100;
                OnPropertyChanged(nameof(SoundValoume));
            }
        }
        private int soundMute; // 0 / 1
        public bool SoundMute
        {
            get { return soundMute == 1; }
            set
            {
                int tempValue = value ? 1 : 0;
                soundMute = tempValue;
                OnPropertyChanged(nameof(SoundMute));
            }
        }
        private string language = string.Empty;
        public string Language
        {
            get { return language; }
            set
            {
                language = value;
                OnPropertyChanged(nameof(Language));
            }
        }
        private string autoLogin = string.Empty;
        public string AutoLogin
        {
            get { return autoLogin; }
            set
            {
                autoLogin = value;
                OnPropertyChanged(nameof(AutoLogin));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void loadIni()
        {
            var iniParser = new FileIniDataParser();
            iniParser.Parser.Configuration.NewLineStr = "\n";
            iniParser.Parser.Configuration.CommentString = "// ";
            iniParser.Parser.Configuration.AssigmentSpacer = "";
            iniDictionary = iniParser.ReadFile("client.ini");
            //TODO: check if dictionary is empty
            var options = iniDictionary["Option"];
            FullScreenMode = int.Parse(options["FullScreenMode"]);
            ScreenSize = options["ScreenWidth"] + "x" + options["ScreenHeight"];
            ViewCharacterRange = int.Parse(options["ViewCharacterRange"]);
            ViewRange = int.Parse(options["ViewRange"]);
            CharacterEffectNum = int.Parse(options["CharacterEffectNum"]);
            ShadowLevel = options["ShadowLevel"];
            ShadowType = int.Parse(options["ShadowType"]);
            SceneTexture = options["SceneTexture"];
            CharacterTexture = options["CharacterTexture"];
            PPMonochrome = int.Parse(options["PPMonochrome"]) == 1;
            PPSepia = int.Parse(options["PPSepia"]) == 1;
            DynamicVideoSetting = int.Parse(options["DynamicVideoSetting"]) == 1;
            DepthOfField = options["DepthOfField"];
            FpsLockValue = options["FpsLockValue"];
            ScreenFrequency = options["ScreenFrequency"];
            BGMType = options["BGMType"];
            BGMValoume = (int)Math.Round(double.Parse(options["BGMValoume"]) * 100);
            SoundValoume = (int)Math.Round(double.Parse(options["SoundValoume"]) * 100);
            SoundMute = int.Parse(options["SoundMute"]) == 1;
            Language = LaunchHelper.GetLang();
            AutoLogin = Properties.Settings.Default.CurrentUsername;
        }
        public void saveIni()
        {
            var iniParser = new FileIniDataParser();
            iniParser.Parser.Configuration.NewLineStr = "\n";
            iniParser.Parser.Configuration.CommentString = "// ";
            iniParser.Parser.Configuration.AssigmentSpacer = "";
            iniDictionary["Option"]["FullScreenMode"] = FullScreenMode.ToString();
            iniDictionary["Option"]["ScreenWidth"] = ScreenSize.Split('x')[0];
            iniDictionary["Option"]["ScreenHeight"] = ScreenSize.Split('x')[1];
            iniDictionary["Option"]["ViewCharacterRange"] = ViewCharacterRange.ToString();
            iniDictionary["Option"]["ViewRange"] = ViewRange.ToString();
            iniDictionary["Option"]["CharacterEffectNum"] = CharacterEffectNum.ToString();
            iniDictionary["Option"]["ShadowLevel"] = ShadowLevel;
            iniDictionary["Option"]["ShadowType"] = ShadowType.ToString();
            iniDictionary["Option"]["SceneTexture"] = SceneTexture;
            iniDictionary["Option"]["CharacterTexture"] = CharacterTexture;
            iniDictionary["Option"]["PPMonochrome"] = pPMonochrome.ToString();
            iniDictionary["Option"]["PPSepia"] = pPSepia.ToString();
            iniDictionary["Option"]["DynamicVideoSetting"] = dynamicVideoSetting.ToString();
            iniDictionary["Option"]["DepthOfField"] = DepthOfField;
            iniDictionary["Option"]["FpsLockValue"] = FpsLockValue;
            iniDictionary["Option"]["ScreenFrequency"] = ScreenFrequency;
            iniDictionary["Option"]["BGMType"] = BGMType;
            iniDictionary["Option"]["BGMValoume"] = bgmValoume.ToString();
            iniDictionary["Option"]["SoundValoume"] = soundValoume.ToString();
            iniDictionary["Option"]["SoundMute"] = soundMute.ToString();
            Properties.Settings.Default.CurrentUsername = AutoLogin;
            Properties.Settings.Default.Save();

            iniParser.WriteFile("client.ini", iniDictionary);
        }
        public List<string> fpsLockValueList;
        public List<string> screenFrequencyList;
        public List<string> screenSizeList;
        public List<Item> shadowLevelItems;
        public List<Item> sceneTextureItems;
        public List<Item> characterTextureItems;
        public List<Item> depthOfFieldList;
        public List<Item> bgmTypeItems;
        public List<Item> languageItems;
        public OptionsData()
        {

            ResolutionHelper resolutionHelper = new ResolutionHelper();
            fpsLockValueList = ["30", "60", "120"];
            screenFrequencyList = ["30", "60", "75", "144", "240", "300", "999"];
            screenSizeList = resolutionHelper.getAvailableResolutions();
            shadowLevelItems =
            [
                new Item{ Display="Low", Value = "1" },
                    new Item{ Display="Medium", Value = "2" },
                    new Item{ Display="High", Value = "3" },
                ];
            sceneTextureItems =
            [
                new Item{ Display="Normal", Value = "0" },
                    new Item{ Display="High", Value = "1" },
                ];
            characterTextureItems =
            [
                new Item{ Display="Normal", Value = "0" },
                    new Item{ Display="High", Value = "1" },
                ];
            depthOfFieldList =
            [
                new Item{ Display="None", Value = "0" },
                    new Item{ Display="Normal", Value = "1" },
                    new Item{ Display="High", Value = "3" },
                ];
            bgmTypeItems =
            [
                new Item{ Display="Default", Value = "0" },
                    new Item{ Display="BGM Loop", Value = "1" },
                    new Item{ Display="Audio Interval", Value = "2" },
                ];
            languageItems =
            [
                new Item{ Display="English", Value = "US" },
                    new Item{ Display="Español", Value = "ES" },
                    new Item{ Display="Português", Value = "PT" },
                ];
            fullScreenMode = 0;
            screenSize = "800x600";
            viewCharacterRange = 20;
            viewRange = 3;
            characterEffectNum = 13;
            shadowLevel = "2";
            shadowType = 3;
            sceneTexture = "1";
            characterTexture = "1";
            pPMonochrome = 1;
            pPSepia = 1;
            dynamicVideoSetting = 1;
            depthOfField = "0";
            fpsLockValue = "60";
            screenFrequency = "60";
            bgmType = "0";
            bgmValoume = 1;
            soundValoume = 1;
            soundMute = 0;
            //Default data, load from ini file
            try
            {
                loadIni();
            }
            catch (Exception)
            { Console.WriteLine("there was an error"); }
        }
    }
}
