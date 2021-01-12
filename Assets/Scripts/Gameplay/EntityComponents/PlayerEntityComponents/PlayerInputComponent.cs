using Gameplay.Services;
using Svelto.ECS;

namespace Gameplay.EntityComponents.PlayerEntityComponents
{
    public struct PlayerInputComponent : IEntityComponent
    {
        public IInput inputData;
    }
}