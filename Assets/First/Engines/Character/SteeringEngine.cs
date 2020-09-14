using System.Collections;
using First.EntityStructs;
using First.EntityViews;
using Svelto.Common;
using Svelto.ECS;
using Svelto.ECS.Extensions;
using UnityEngine;

namespace First.Engines.Character
{
    [Sequenced(nameof(MoveEngineEnum.SteeringEngine))]
    public class SteeringEngine : IQueryingEntitiesEngine, IStepEngine
    {
        public EntitiesDB entitiesDB { get; set; }
        readonly IEnumerator _updateTick;


        public SteeringEngine()
        {
            _updateTick = OnUpdate();
        }


        public void Step()
        {
            _updateTick.MoveNext();
        }

        public void Ready()
        {
            UpdateFromInput().Run();
        }

        IEnumerator UpdateFromInput()
        {
            while (true)
            {
                var (steeringInputs, stCount) = entitiesDB.QueryEntities<SteeringInputComponent>(ECSGroups.PlayerInput);
                if (stCount > 0)
                {
                    // if (steeringInputs[0].isProcess) yield return null;
                    var process = steeringInputs[0].isProcess;
                    if (!process)
                    {
                        steeringInputs[0].isProcess = true;
                        var destination = steeringInputs[0].destination;
                        var (steeringEntities, count) = entitiesDB.QueryEntities<SteeringComponent>(ECSGroups.ActiveCharacter);
                        for (int i = 0; i < count; i++)
                        {
                            steeringEntities[i].destination = destination;
                        }
                    }
                }


                yield return null;
            }
        }

        IEnumerator OnUpdate()
        {
            while (true)
            {
                var groups = entitiesDB.QueryEntities<SteeringComponent, MovementComponent, CharacterEntityViewComponents>(ECSGroups.ActiveCharacter);

                var steeringComponents = groups.Item1;
                var movementComponents = groups.Item2;
                var viewComponents = groups.Item3;
                var count = groups.count;
                for (int i = 0; i < count; i++)    
                {
                    var currentVelocity = (Vector2) movementComponents[i].Direction * movementComponents[i].Speed; 
                    var desiredVector = steeringComponents[i].destination - (Vector2) viewComponents[i].PositionComponent.position;
                    // desiredVector = desiredVector.normalized;
                    var desiredVelocity = desiredVector;

                    var steeringVelocity = desiredVelocity - currentVelocity;

                    if (steeringVelocity.sqrMagnitude > steeringComponents[i].maxSteeringForce * steeringComponents[i].maxSteeringForce)
                    {
                        steeringVelocity = steeringVelocity.normalized;
                        steeringVelocity *= steeringComponents[i].maxSteeringForce;
                    }

                    movementComponents[i].Acceleration = steeringVelocity;
                }

                yield return null;
            }
        }


        public string name => nameof(SteeringEngine);
    }
}