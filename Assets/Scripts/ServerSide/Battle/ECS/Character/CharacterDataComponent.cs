using Svelto.ECS;

namespace ServerSide.Battle.ECS.Character
{
    public struct CharacterDataComponent : IEntityComponent, INeedEGID
    {
        public EGID ID { get; set; }
    }
}