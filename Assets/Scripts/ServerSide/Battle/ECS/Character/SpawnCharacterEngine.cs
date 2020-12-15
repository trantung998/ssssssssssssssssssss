using ServerSide.Battle.ECS.GameTime;
using ServerSide.Battle.ECS.Movement;
using ServerSide.Battle.Logger;
using Svelto.ECS;
using UnityEngine;

namespace ServerSide.Battle.ECS.Character
{
    public class SpawnCharacterEngine : IQueryingEntitiesEngine, IGameEngine
    {
        public EntitiesDB entitiesDB { get; set; }

        public SpawnCharacterEngine(IEntityFactory entityFactory, SimpleEntitiesSubmissionScheduler submissionScheduler, ILog log)
        {
            _spawnCount = 0;
            _entityFactory = entityFactory;
            _submissionScheduler = submissionScheduler;
            _log = log;
        }


        public void Ready()
        {
            SpawnCharacter();
        }

        private void SpawnCharacter()
        {
            //create time entity
            var initializer = _entityFactory.BuildEntity<CharacterEntityDescriptor>(new EGID(_spawnCount++, EntityGroups.ActiveEntity));
            initializer.Init(new CharacterDataComponent());
            initializer.Init(new MovementComponent() {dir = Vector2.up, moveSpeed = 0.3f, position = Vector2.zero});
        }

        public void Update()
        {
        }

        private uint _spawnCount;
        private readonly IEntityFactory _entityFactory;
        private readonly SimpleEntitiesSubmissionScheduler _submissionScheduler;
        private readonly ILog _log;
    }
}