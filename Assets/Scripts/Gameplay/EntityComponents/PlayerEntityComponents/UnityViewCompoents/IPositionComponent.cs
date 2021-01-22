using UnityEngine;

namespace Gameplay.EntityComponents.PlayerEntityComponents.UnityViewCompoents
{
    public interface IPositionComponent
    {
        Vector3 value { get; }
    }


    public interface ITransformComponent : IPositionComponent
    {
        new Vector3 position { set; }
    }
}