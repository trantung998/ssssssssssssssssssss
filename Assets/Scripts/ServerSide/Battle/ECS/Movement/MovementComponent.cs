using Svelto.ECS;
using UnityEngine;

namespace ServerSide.Battle.ECS.Movement
{
    public struct MovementComponent : IEntityComponent
    {
        public Vector2 dir;
        public float moveSpeed;
        public Vector2 position;
    }
}