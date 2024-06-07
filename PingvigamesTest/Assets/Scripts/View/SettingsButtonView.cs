using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class SettingsButtonView : MonoBehaviour
    {
        [SerializeField] private Button _settingsButton;
        [SerializeField] private SettingsPopupView _settingsPopupView;

        private void OnEnable()
        {
            _settingsButton.onClick.AddListener(OnSettingsHandler);
        }

        private void OnDisable()
        {
            _settingsButton.onClick.RemoveListener(OnSettingsHandler);
        }
        
        private void OnSettingsHandler()
        {
            _settingsPopupView.ShowPopup();
        }
    }
}
