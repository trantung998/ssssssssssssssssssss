using Entitas;

namespace Indicator
{
    public enum IndicatorType
    {
        None,
        Damage,
    }

    public class BaseIndicatorData
    {
        public IndicatorType type;
        public int targetId;
    }

    public class DamageIndicatorData : BaseIndicatorData
    {
        public float value;
        public bool isCriticalHit;
    }

    [Game]
    public class IndicatorComponent : IComponent
    {
        public BaseIndicatorData value;
    }
}