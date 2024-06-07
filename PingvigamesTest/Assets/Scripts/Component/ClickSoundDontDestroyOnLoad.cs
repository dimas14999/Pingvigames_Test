using System;
using UnityEngine;

namespace Component
{
    public class ClickSoundDontDestroyOnLoad : MonoBehaviour
    {
        public static ClickSoundDontDestroyOnLoad Instance { get; private set; }

        private AudioSource _audioSource;
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
            _audioSource = GetComponent<AudioSource>();
        }

        public void Play()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }
}
