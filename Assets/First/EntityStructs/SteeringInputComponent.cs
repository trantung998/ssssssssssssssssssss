using Svelto.ECS;
using UnityEngine;

namespace First.EntityStructs
{
    public struct SteeringInputComponent : IEntityComponent
    {
        public bool isProcess;
        public Vector2 destination;
    }

    public struct SteeringComponent : IEntityComponent
    {
        public Vector2 destination;
        public float maxSteeringForce;
    }
}