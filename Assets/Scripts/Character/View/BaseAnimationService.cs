using UnityEngine;

public abstract class BaseAnimationService : MonoBehaviour
{
    public abstract float AnimationSpeed { get; set; }
    public abstract bool IsAnimationLoop { get; set; }
    public abstract bool IsFlipX { get; set; }

    public abstract void PlayAnimation(string animationName);

    public abstract void FlipX(bool isFlipX);
}