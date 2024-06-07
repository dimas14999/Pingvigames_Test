using System;
using UnityEngine;

namespace Component
{
    public abstract class AnimationComponent: MonoBehaviour
    {
        public abstract void Show(Action onComplete);
        public abstract void Hide(Action onComplete);
    }
}