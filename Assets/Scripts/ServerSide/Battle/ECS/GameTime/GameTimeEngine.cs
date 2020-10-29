using System;
using ServerSide.Battle.Logger;
using Svelto.ECS;
using Svelto.ECS.Schedulers;
using UnityEngine;

namespace ServerSide.Battle.ECS.GameTime
{
    public class GameTimeEngine : IQueryingEntitiesEngine, IGameEngine
    {
        public EntitiesDB entitiesDB { get; set; }
        private readonly IEntityFactory _entityFactory;
        private readonly SimpleEntitiesSubmissionScheduler _submissionScheduler;
        private readonly ILog _log;

        public GameTimeEngine(IEntityFactory entityFactory, SimpleEntitiesSubmissionScheduler submissionScheduler, ILog log)
        {
            _entityFactory = entityFactory;
            _submissionScheduler = submissionScheduler;
            _log = log;
        }

        public void Ready()
        {
            //create time entity
            var initializer = _entityFactory.BuildEntity<GameTimeEntityDescriptor>(new EGID(0, EntityGroups.GlobalEntity));
            initializer.Init(new TimeComponent() {lastimeUpdate = DateTime.Now.Ticks});
        }

        public void Update()
        {
            //schedule the entity submission
            _submissionScheduler.SubmitEntities();

            var (timeComponents, count) = entitiesDB.QueryEntities<TimeComponent>(EntityGroups.GlobalEntity);
            if (count > 0)
            {
                var now = DateTime.Now.Ticks;
                ref var timeComponent = ref timeComponents[0];

                timeComponent.frame++;
                timeComponent.deltaTime = 1.0f * (now - timeComponent.lastimeUpdate) / TimeSpan.TicksPerSecond;
                timeComponent.lastimeUpdate = now;

                _log.Debug("dt: " + timeComponent.deltaTime);
            }
        }
    }
}