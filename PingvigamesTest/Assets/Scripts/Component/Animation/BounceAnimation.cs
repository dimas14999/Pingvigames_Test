using System;
using DG.Tweening;
using UnityEngine;

namespace Component.Animation
{
    public class BounceAnimation : AnimationComponent
    {
        [SerializeField] private float _animationDuration = 1f;
        [SerializeField] private GameObject _container;
        public override void Show(Action onComplete)
        {
            transform.localScale = Vector3.zero;
            _container.SetActive(true);
            transform.DOScale(Vector3.one, _animationDuration).SetEase(Ease.OutBounce).OnComplete(() =>
            {
                onComplete?.Invoke();
            });
        }

        public override void Hide(Action onComplete)
        {
            transform.DOScale(Vector3.zero, _animationDuration).SetEase(Ease.InBack).OnComplete(() =>
            {
                _container.SetActive(false);
                onComplete?.Invoke();
            });
        }
    }
}