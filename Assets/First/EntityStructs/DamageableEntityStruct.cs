using First.DataModels;
using Svelto.ECS;

namespace First.EntityStructs
{
    public struct DamageableEntityStruct : IEntityComponent, INeedEGID
    {
        public DamageStruct Damage;
        public bool IsProcessed;

        public EGID ID { get; set; }
    }
}