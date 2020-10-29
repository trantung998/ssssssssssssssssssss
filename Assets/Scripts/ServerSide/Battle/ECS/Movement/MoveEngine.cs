using ServerSide.Battle.ECS.GameTime;
using Svelto.ECS;

namespace ServerSide.Battle.ECS.Movement
{
    public class MoveEngine : IGameEngine, IQueryingEntitiesEngine
    {
        public EntitiesDB entitiesDB { get; set; }

        public void Ready()
        {
        }

        public void Update()
        {
            var (moveComponents, count) = entitiesDB.QueryEntities<MovementComponent>(EntityGroups.ActiveEntity);
            if (count > 0)
            {
                var timeComponents = entitiesDB.QueryEntities<TimeComponent>(EntityGroups.GlobalEntity);
                var dt = timeComponents[0].deltaTime;

                for (int i = 0; i < count; i++)
                {
                    ref var moveComponent = ref moveComponents[i];
                    moveComponent.position = moveComponent.position + moveComponent.dir * (moveComponent.moveSpeed * dt);
                }
            }
        }
    }
}