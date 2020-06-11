using UnityEngine;

public class UnityAnimatorService : BaseAnimationService
{
    [SerializeField] private Animator animator;
    [SerializeField] [HideInInspector] private SpriteRenderer _spriteRenderer;

    private Vector3 flipXVector = new Vector3(-1, 1, 1);

    private void OnValidate()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        if (_spriteRenderer == null)
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    public override float AnimationSpeed
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

    public override bool IsAnimationLoop
    {
        get => true;
        set { }
    }

    public override bool IsFlipX { get; set; }

    public override void PlayAnimation(string name)
    {
        if (animator != null)
        {
            animator.Play(name);
        }
    }

    public override void FlipX(bool isFlip)
    {
        IsFlipX = isFlip;

        if (_spriteRenderer != null)
        {
            _spriteRenderer.flipX = isFlip;

//            animator.gameObject.transform.localScale = isFlip ? flipXVector : Vector3.one;
        }
    }
}