using System;
using Component;
using DG.Tweening;
using UnityEngine;

namespace View
{
    public class BaseView : MonoBehaviour
    {
        [SerializeField] private AnimationComponent _animationComponent;
        public virtual void ShowPopup(Action onComplete = null)
        {
            _animationComponent.Show(onComplete);
        }

        public virtual void HidePopup(Action onComplete = null)
        {
            _animationComponent.Hide(onComplete);
        }
    }
}
