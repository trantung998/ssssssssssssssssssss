using UnityEngine;

namespace First.Services
{
    public abstract class BaseAnimator : MonoBehaviour, IAnimator
    {
        public abstract void PlayAnimation(string name);
        public abstract float Speed { get; set; }
        public abstract bool Loop { set; get; }
        public abstract bool IsFlipX { set; get; }

        public abstract void SetSkin(string skinName);

        public abstract bool HasAnimation(string name);
    }
}