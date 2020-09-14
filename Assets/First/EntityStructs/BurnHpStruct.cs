using First.DataModels;
using Svelto.ECS;

namespace First.EntityStructs
{
    public struct BurnHpStruct
    {
        public float duration;
        public DamageStruct DamagePerTick;
        public EGID ID { get; set; }
    }
}