using UnityEngine;
using UnityEngine.UI;

namespace Component
{
    public class ClickSoundComponent : MonoBehaviour
    {
        protected void Start()
        {
            GetComponent<Button>().onClick.AddListener(ClickHandler);
        }

        private void ClickHandler()
        {
            ClickSoundDontDestroyOnLoad.Instance.Play();
        }
    }
}
