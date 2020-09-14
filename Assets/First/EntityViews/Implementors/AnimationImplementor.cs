using First.EntityViews.Components;
using First.Services;
using Svelto.ECS.Hybrid;
using UnityEngine;

namespace First.EntityViews.Implementors
{
    public class AnimationImplementor : MonoBehaviour, IAnimationComponent, IImplementor
    {
        private BaseAnimator _baseAnimator;
        string _runningAnimation;

        private void Awake()
        {
            _baseAnimator = GetComponent<BaseAnimator>();
        }

        public string PlayAnimation
        {
            get { return _runningAnimation; }
            set
            {
                _runningAnimation = value;
                if (_baseAnimator != null)
                {
                    _baseAnimator.PlayAnimation(_runningAnimation);
                }
            }
        }
    }
}