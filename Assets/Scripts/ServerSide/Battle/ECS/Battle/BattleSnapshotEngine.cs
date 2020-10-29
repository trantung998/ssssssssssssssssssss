using ServerSide.Battle.ECS.GameTime;
using ServerSide.Battle.Logger;
using Svelto.ECS;

namespace ServerSide.Battle.ECS.Battle
{
    public class BattleSnapshotEngine : IQueryingEntitiesEngine, IGameEngine
    {
        public EntitiesDB entitiesDB { get; set; }
        private readonly IEntityFactory _entityFactory;
        private readonly SimpleEntitiesSubmissionScheduler _submissionScheduler;
        private readonly ILog _log;

        public BattleSnapshotEngine(IEntityFactory entityFactory, SimpleEntitiesSubmissionScheduler submissionScheduler, ILog log)
        {
            _entityFactory = entityFactory;
            _submissionScheduler = submissionScheduler;
            _log = log;
        }

        public void Ready()
        {
            //create snapshot entity
            var initializer = _entityFactory.BuildEntity<BattleSnapshotEntityDescriptor>(new EGID(1, EntityGroups.GlobalEntity));
        }

        public void Update()
        {
            //create battle snapshot
            
        }
    }
}