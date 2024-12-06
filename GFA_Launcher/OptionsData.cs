
using System.ComponentModel;

namespace GFA_Launcher
{
    public class OptionsData : INotifyPropertyChanged
    {
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
            get => FullScreenMode == 1; 
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
        private int bgmValoume; // 0 to 1
        public int BGMValoume
        {
            get => (int)Math.Round((double)bgmValoume * 100);
            set
            {
                bgmValoume = value / 100;
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
                soundValoume = value / 100;
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

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
                new Item{ Display="Français", Value = "FR" },
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
            bgmValoume = 100;
            soundValoume = 100;
            soundMute = 0;
        }

        
    }
}
