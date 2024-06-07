using System;
using Component;
using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class WelcomePopupView : BaseView
    {
        private const string Main = "Main";
        
        [SerializeField] private Button _nextButton;
        
        private void OnEnable()
        {
            _nextButton.onClick.AddListener(OnNextHandler);
        }
        
        private void OnDisable()
        {
            _nextButton.onClick.RemoveListener(OnNextHandler);
        }

        private void Start()
        {
            ShowPopup();
        }

        private void OnNextHandler()
        {
            HidePopup(ShowPreloaderPopup);
        }

        private void ShowPreloaderPopup()
        {
            //Лучше использовать DI
            PreloaderPopupView.Instance.ShowPopup(() => SceneLoader.Instance.Load(Main, () => PreloaderPopupView.Instance.HidePopup()));
        }
    }
}
