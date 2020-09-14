using Svelto.ECS;
using UnityEngine;

namespace First.EntityStructs
{
    public struct MovementComponent : IEntityComponent, INeedEGID
    {
        public float Speed;
        public Vector3 Direction;
        public Vector3 Acceleration;
        public EGID ID { get; set; }
    }
}