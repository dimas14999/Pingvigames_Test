using System;
using DG.Tweening;
using UnityEngine;

namespace Component.Animation
{
    public class LeftToRightAnimation : AnimationComponent
    {
        [SerializeField] private Vector2 _from;
        [SerializeField] private Vector2 _at;
        [SerializeField] private float _animationDuration = 1f;
        [SerializeField] private RectTransform _container;
        public override void Show(Action onComplete)
        {
            _container.anchoredPosition = _from;
            _container.gameObject.SetActive(true);
            _container.DOAnchorPos(_at, _animationDuration).SetEase(Ease.OutQuint).OnComplete(() =>{onComplete?.Invoke();});
        }

        public override void Hide(Action onComplete)
        {
            _container.DOAnchorPos(_from * -1, _animationDuration).SetEase(Ease.InQuint).OnComplete(() =>
            {
                _container.gameObject.SetActive(false);
                onComplete?.Invoke();
            });
        }
    }
}
