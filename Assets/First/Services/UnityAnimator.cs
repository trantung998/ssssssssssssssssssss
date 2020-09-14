using UnityEngine;

namespace First.Services
{
    public class UnityAnimator : BaseAnimator
    {
        [SerializeField] private Animator animator;
        [SerializeField] [HideInInspector] private SpriteRenderer spriteRenderer;

        private Vector3 _flipXVector = new Vector3(-1, 1, 1);

        private void OnValidate()
        {
            if (animator == null)
                animator = GetComponent<Animator>();

            if (spriteRenderer == null)
            {
                spriteRenderer = GetComponent<SpriteRenderer>();
            }
        }

        public override void PlayAnimation(string animationName)
        {
            if (animator != null)
            {
                animator.Play(name);
            }
        }

        public override float Speed
        {
            get
            {
                if (animator != null)
                {
                    return animator.speed;
                }

                return 0;
            }
            set
            {
                if (animator != null)
                {
                    animator.speed = value;
                }
            }
        }

        public override bool Loop
        {
            get { return true; }
            set { }
        }

        private bool _isFlipX;

        public override bool IsFlipX
        {
            get { return _isFlipX; }
            set
            {
                _isFlipX = value;

                if (spriteRenderer != null)
                {
                    spriteRenderer.flipX = _isFlipX;
                }
            }
        }

        public override void SetSkin(string skinName)
        {
//        NotImplemented;
        }

        public override bool HasAnimation(string animationName)
        {
            return true;
        }
    }
}