using System;
using Component;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class RestartButtonView : MonoBehaviour
    {
        private const string Main = "Main";
        [SerializeField] private Button _restartButton;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(OnRestartHandler);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(OnRestartHandler);
        }
        
        private void OnRestartHandler()
        {
            PreloaderPopupView.Instance.ShowPopup(() => SceneLoader.Instance.Load(Main, () => PreloaderPopupView.Instance.HidePopup()));
        }
    }
}
