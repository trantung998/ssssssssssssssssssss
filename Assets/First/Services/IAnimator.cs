namespace First.Services
{
    public interface IAnimator
    {
        void PlayAnimation(string animationName);
        float Speed { get; set; }
        bool Loop { set; get; }
        bool IsFlipX { set; get; }

        void SetSkin(string skinName);

        bool HasAnimation(string animationName);
    }
}