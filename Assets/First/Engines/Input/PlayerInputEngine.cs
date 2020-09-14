using System;
using System.Collections;
using First;
using First.Descriptors;
using First.EntityStructs;
using Svelto.ECS;
using Svelto.Tasks;
using UnityEngine;

public class PlayerInputEngine : IQueryingEntitiesEngine
{
    public EntitiesDB entitiesDB { get; set; }
    readonly ITime _time;
    private readonly IEntityFactory _entityFactory;

    public PlayerInputEngine(IEntityFactory entityFactory)
    {
        _time = new Time();
        _entityFactory = entityFactory;
    }

    public void Ready()
    {
        var initializer = _entityFactory.BuildEntity<PlayerInputEntityDescriptor>(new EGID(0, ECSGroups.PlayerInput));
        initializer.Init(new SteeringInputComponent() {destination = Vector2.zero, isProcess = false});
        ReadInput().RunOnScheduler(StandardSchedulers.earlyScheduler);
    }

    IEnumerator ReadInput()
    {
        while (true)
        {
            void IterateSteeringInput(EntityCollection<SteeringInputComponent> groups)
            {
                var (playerSteeringComponents, count) = groups;
                for (int i = 0; i < count; i++)
                {
                    var destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    playerSteeringComponents[i].destination = destination;
                    playerSteeringComponents[i].isProcess = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                //
            }

            if (Input.GetMouseButtonUp(0))
            {
                var groups = entitiesDB.QueryEntities<SteeringInputComponent>(ECSGroups.PlayerInput);
                IterateSteeringInput(groups);
            }

            yield return null;
        }
    }
}