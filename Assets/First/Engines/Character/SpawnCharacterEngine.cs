using System.Collections;
using First.Descriptors;
using First.EntityStructs;
using First.EntityViews;
using First.Factories;
using First.Services;
using SpawnData;
using Svelto.ECS;
// using Svelto.ECS.First.Descriptors;
using Svelto.Tasks.Enumerators;
using UnityEngine;

namespace First.Engines.Character
{
    public class SpawnCharacterEngine : IQueryingEntitiesEngine
    {
        readonly IEntityFunctions _entityFunctions;
        readonly CharacterFactory _characterFactory;
        private RngFast _random;
        private int _stepCount;
        readonly WaitForSecondsEnumerator _waitForSecondsEnumerator = new WaitForSecondsEnumerator(1f);

        public SpawnCharacterEngine(IEntityFunctions entityFunctions, CharacterFactory characterFactory)
        {
            _entityFunctions = entityFunctions;
            _characterFactory = characterFactory;
            _random = Service<RngFast>.Get();
        }

        public EntitiesDB entitiesDB { get; set; }

        public void Ready()
        {
            OnUpdate().Run();
        }

        IEnumerator OnUpdate()
        {
            _characterFactory.Preallocate();
            // while (true)
            {
                yield return _waitForSecondsEnumerator;

                var spawnData = new CharacterSpawnData();
                spawnData.prefabName = "Characters/Dummy1";
                spawnData.spawnPoint = new Vector3(_random.GetFloat(-2f, 2f), _random.GetFloat(-2f, 2f), 0);

                //has got a compatible entity previously disabled and can be reused?
                //Note, pooling make sense only for Entities that use implementors.
                //A pure struct based entity doesn't need pooling because it never allocates.
                //to simplify the logic, we use a recycle group for each entity type
                var fromGroupId = ECSGroups.CharacterToRecycleGroups + 0;

                if (entitiesDB.HasAny<CharacterEntityViewComponents>(fromGroupId))
                {
                    ReuseEntity(fromGroupId, spawnData);
                }
                else
                {
                    yield return _characterFactory.Build(spawnData);
                }
            }
        }

        void ReuseEntity(ExclusiveGroupStruct fromGroupId, CharacterSpawnData spawnData)
        {
            // var (healths, entityViews, count) = entitiesDB.QueryEntities<CharacterHealthStruct, CharacterEntityViewComponents>(fromGroupId);
            var entities = entitiesDB.QueryEntities<CharacterHealthComponent, CharacterEntityViewComponents, MovementComponent>(fromGroupId);
            var count = entities.count;

            if (count > 0)
            {
                var healths = entities.Item1;
                var entityViews = entities.Item2;
                var movements = entities.Item3;

                healths[0].HealthValue = 100;
                healths[0].IsDeath = false;

                entityViews[0].TransformComponent.position = spawnData.spawnPoint;
                entityViews[0].Health.value = 1;
                
                movements[0].Direction = Vector2.up;
                movements[0].Speed = 1f;
        
                _entityFunctions.SwapEntityGroup<CharacterEntityDescriptor>(entityViews[0].ID, ECSGroups.ActiveCharacter);
            }
        }
    }
}