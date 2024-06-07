using UnityEngine;

namespace Component
{
    public class DontDestroyOnLoadGameObjectComponent : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
