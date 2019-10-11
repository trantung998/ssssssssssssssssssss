namespace Combat.Slow
{
    public class SlowEffectData : BaseEffectData
    {
        public float slowValue;

        public SlowEffectData(float duration, float slowValue) : base(duration)
        {
            EffectId = EffectId.Slow;
            this.slowValue = slowValue;
        }
    }
}