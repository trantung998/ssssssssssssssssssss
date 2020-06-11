public class BaseAnimationMapping
{
    public virtual string GetAnimationName(CharacterState characterState)
    {
        return characterState.ToString();
    }
}