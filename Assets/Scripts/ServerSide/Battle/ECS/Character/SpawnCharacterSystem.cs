using ServerSide.Battle.ECS.GameTime;
using ServerSide.Battle.Logger;
using Svelto.ECS;

namespace ServerSide.Battle.ECS.Character
{
    public class SpawnCharacterSystem : IQueryingEntitiesEngine, IGameEngine
    {
        public EntitiesDB entitiesDB { get; set; }

        public SpawnCharacterSystem(IEntityFactory entityFactory, SimpleEntitiesSubmissionScheduler submissionScheduler, ILog log)
        {
            _spawnCount = 0;
        }


        public void Ready()
        {
        }

        private void SpawnCharacter()
        {
            //create time entity
            var initializer = _entityFactory.BuildEntity<CharacterEntityDescriptor>(new EGID(_spawnCount++, EntityGroups.ActiveEntity));
            initializer.Init(new CharacterDataComponent());
            initializer.Init(new CharacterDataComponent());
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