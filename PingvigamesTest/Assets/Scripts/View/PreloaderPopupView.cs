using System;
using UnityEngine;

namespace View
{
    public class PreloaderPopupView : BaseView
    {
        public static PreloaderPopupView Instance { get; private set; }

        // Лучше использовать DI, к примеру Zenject
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
    }
}
