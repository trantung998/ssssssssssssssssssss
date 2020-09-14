using Svelto.ECS;

namespace First.EntityStructs
{
    public struct CharacterHealthComponent : IEntityComponent, INeedEGID
    {
        public int HealthValue;
        public int MaxHealthValue;
        
        public bool IsDeath;
        public EGID ID { get; set; }
    }
}