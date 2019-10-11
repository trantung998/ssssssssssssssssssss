namespace Combat
{
    public class StunEffectData : BaseEffectData
    {
        public StunEffectData(float duration) : base(duration)
        {
            EffectId = EffectId.Stun;
        }
    }
}