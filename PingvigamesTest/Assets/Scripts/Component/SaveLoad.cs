using UnityEngine;
using UnityEngine.Audio;

namespace Component
{
    public class SaveLoad : MonoBehaviour
    {
        private const string Music = "Music";
        private const string Sound = "Sound";
        private const float AudioOnValue = 0f;
        private const float AudioOffValue = -80f;
        public static SaveLoad Instance { get; private set; }
        public bool IsMusicOn { get; private set; }
        public bool IsSoundOn { get; private set; }

        [SerializeField] private AudioMixer _audioMixer;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            LoadAudioSettings();
        }

        public void SaveAudio(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
            PlayerPrefs.Save();
        }
        private void LoadAudioSettings()
        {
            IsMusicOn = LoadAudioSetting(Music, AudioOnValue, AudioOffValue);
            IsSoundOn = LoadAudioSetting(Sound, AudioOnValue, AudioOffValue);
        }

        private bool LoadAudioSetting(string key, float onValue, float offValue)
        {
            if (PlayerPrefs.HasKey(key))
            {
                bool isOn = PlayerPrefs.GetInt(key) == 1;
                _audioMixer.SetFloat(key, isOn ? onValue : offValue);
                return isOn;
            }
            return true;
        }
    }
}
