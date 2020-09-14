using UnityEngine;

namespace First.EntityViews.Components
{
    public interface ITransformComponent : IPositionComponent
    {
        new Vector3 position { set; }

        Quaternion rotation { set; }
    }

    public interface IPositionComponent : IComponents
    {
        Vector3 position { get; }
    }
}