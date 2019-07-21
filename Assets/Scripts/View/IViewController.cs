using Entitas;
using UnityEngine;

namespace View
{
    public interface IViewController
    {
        Vector3 Position { get; set; }

        Vector3 Scale { get; set; }

        Quaternion Rotation { get; set; }

        bool Active { get; set; }

        void InitializeView(Contexts contexts, IEntity entity);

        void OnEntityDestroyed();

        void OnUpdate(float dt);

        void Link();

        void UnLink();
    }
}