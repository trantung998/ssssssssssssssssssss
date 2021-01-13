using Svelto.ECS;

namespace Gameplay.EntityComponents.PlayerEntityComponents
{
    public struct PlayerInputComponent : IEntityComponent
    {
        public bool isSpawnCharacter;
        public float VerticalValue;
        public float HorizontalValue;
    }
}