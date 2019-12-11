using Entitas;

namespace Combat
{
    public class NormalAttackData
    {
        public int source;
        public int target;
    }

    [Game]
    public class NormalAttackDataComponent : IComponent
    {
        public NormalAttackData value;
    }

    [Game]
    public class NeedStatComponent : IComponent
    {
    }
}