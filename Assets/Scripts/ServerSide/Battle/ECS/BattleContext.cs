using System.Collections.Generic;
using ServerSide.Battle.ECS.GameTime;
using ServerSide.Battle.Logger;
using Svelto.ECS;

namespace ServerSide.Battle.ECS
{
    public class BattleContext
    {
        readonly EnginesRoot _enginesRoot;
        private List<IGameEngine> _gameEngines;
        private readonly ILog _log;

        public BattleContext(ILog log)
        {
            _log = log;

            var simpleSubmissionEntityViewScheduler = new SimpleEntitiesSubmissionScheduler();
            _enginesRoot = new EnginesRoot(simpleSubmissionEntityViewScheduler);
            _gameEngines = new List<IGameEngine>();

            //an EnginesRoot must never be injected inside other classes only IEntityFactory and IEntityFunctions
            //implementation can
            var entityFactory = _enginesRoot.GenerateEntityFactory();
            var entityFunctions = _enginesRoot.GenerateEntityFunctions();

            var gameTimeEngine = new GameTimeEngine(entityFactory, simpleSubmissionEntityViewScheduler, log);
            _enginesRoot.AddEngine(gameTimeEngine);
            _gameEngines.Add(gameTimeEngine);
            
            
        }

        public void OnUpdate()
        {
            foreach (var gameEngine in _gameEngines)
            {
                gameEngine.Update();
            }
        }
    }
}