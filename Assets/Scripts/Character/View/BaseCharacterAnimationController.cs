using UnityEngine;

public class BaseCharacterAnimationController
{
    private BaseAnimationService _animationService;
    private BaseAnimationMapping _animationMapping;
    private string currentAnimPlayingName;

    public BaseCharacterAnimationController(BaseAnimationService animationService)
    {
        _animationService = animationService;
        _animationMapping = GetAnimationMapping();
    }

    protected BaseAnimationMapping GetAnimationMapping()
    {
        return new BaseAnimationMapping();
    }

    public virtual string PlayAnimation(CharacterState characterState, bool isFlipX = false, float speed = 1,
        bool loop = true)
    {
        var animName = _animationMapping.GetAnimationName(characterState);

        return PlayAnimation(animName, speed, loop, isFlipX);
    }

    public string PlayAnimation(string animName, float speed, bool loop, bool isFlipX = false)
    {
        if (string.IsNullOrEmpty(animName) ||
            currentAnimPlayingName == animName && isFlipX == _animationService.IsFlipX)
        {
            //do nothing
        }
        else
        {
            if (_animationService != null)
            {
                currentAnimPlayingName = animName;
                _animationService.FlipX(isFlipX);
                _animationService.PlayAnimation(animName);
                _animationService.AnimationSpeed = speed;
                _animationService.IsAnimationLoop = loop;
            }
        }

        return animName;
    }
}