using System.Collections;
using First.EntityStructs;
using First.EntityViews;
using Svelto.Common;
using Svelto.ECS;
using Svelto.ECS.Extensions;
using UnityEngine;

namespace First.Engines.Character
{
    [Sequenced(nameof(MoveEngineEnum.MovementEngine))]
    public class MovementEngine : IQueryingEntitiesEngine, IStepEngine
    {
        readonly ITime _time;
        private readonly IEnumerator _updateTick;
        public EntitiesDB entitiesDB { get; set; }

        public MovementEngine()
        {
            _time = new Time();
            _updateTick = OnUpdate();
        }

        public void Ready()
        {
        }

        IEnumerator OnUpdate()
        {
            while (true)
            {
                void Movement(ref MovementComponent movementData, ref CharacterEntityViewComponents entityView)
                {
                    var velocityVector = movementData.Direction * movementData.Speed;
                    velocityVector += movementData.Acceleration;

                    // Normalise the movement vector and make it proportional to the speed per second.
                    var movement = velocityVector * _time.deltaTime;

                    // change position
                    entityView.TransformComponent.position = entityView.PositionComponent.position + movement;
 
                    //change dir, speed
                    movementData.Direction = velocityVector.normalized;
                    // movementData.Speed = velocityVector.magnitude; //

                    //reset acceleration
                    movementData.Acceleration = Vector3.zero;
                }
                
                var entities = entitiesDB.QueryEntities<MovementComponent, CharacterEntityViewComponents>(ECSGroups.ActiveCharacter);
                var movements = entities.Item1;
                var views = entities.Item2;

                uint count = entities.count;

                if (count > 0)
                {
                    for (int i = 0; i < count; i++)
                    {
                        Movement(ref movements[i], ref views[i]);
                    }
                }

                yield return null;
            }
        }

        public void Step()
        {
            _updateTick.MoveNext();
        }

        public string name => nameof(MovementEngine);
    }
}