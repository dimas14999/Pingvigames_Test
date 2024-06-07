using System;
using Component;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace View
{
    public class SettingsPopupView : BaseView
    {
        private const string Music = "Music";
        private const string Sound = "Sound";
        private const float AudioOnValue = 0f;
        private const float AudioOffValue = -80f;
        
        [SerializeField] private Button _closeButton;
        [SerializeField] private Toggle _musicToggle;
        [SerializeField] private Toggle _soundToggle;
        [SerializeField] private AudioMixer _audioMixer;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(() => HidePopup());
            _musicToggle.onValueChanged.AddListener(isOn => ToggleAudio(Music, isOn));
            _soundToggle.onValueChanged.AddListener(isOn => ToggleAudio(Sound, isOn));
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(() => HidePopup());
            _musicToggle.onValueChanged.RemoveListener(isOn => ToggleAudio(Music, isOn));
            _soundToggle.onValueChanged.RemoveListener(isOn => ToggleAudio(Sound, isOn));
        }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            _musicToggle.isOn = SaveLoad.Instance.IsMusicOn;
            _soundToggle.isOn = SaveLoad.Instance.IsSoundOn;
        }

        private void ToggleAudio(string parameterName, bool isOn)
        {
            _audioMixer.SetFloat(parameterName, isOn ? AudioOnValue : AudioOffValue);
            SaveLoad.Instance.SaveAudio(parameterName, isOn);
        }
    }
}
