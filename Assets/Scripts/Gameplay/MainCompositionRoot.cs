using Gameplay.Services;
using Svelto.Context;
using Svelto.ECS;
using Svelto.ECS.Schedulers.Unity;
using UnityEngine;

namespace Gameplay
{
    public class MainCompositionRoot : ICompositionRoot
    {
        EnginesRoot _enginesRoot;

        public void OnContextInitialized<T>(T contextHolder)
        {
            Setup(contextHolder as UnityContext);
        }

        public void OnContextDestroyed()
        {
        }

        public void OnContextCreated<T>(T contextHolder)
        {
        }

        private void Setup(UnityContext unityContext)
        {
            var unityEntitySubmissionScheduler = new UnityEntitiesSubmissionScheduler("Gameplay");
            _enginesRoot = new EnginesRoot(unityEntitySubmissionScheduler);

            //The EntityFactory can be injected inside factories (or engine acting as factories) to build new entities
            //dynamically
            var entityFactory = _enginesRoot.GenerateEntityFactory();
            //The entity functions is a set of utility operations on Entities, including removing an entity. I couldn't
            //find a better name so far.
            var entityFunctions = _enginesRoot.GenerateEntityFunctions();
            var entityStreamConsumerFactory = _enginesRoot.GenerateConsumerFactory();

            //services
            ITime _timeService = new UnityTimeService();
            ObjectPool _objectPool = ObjectPool.instance;
        }
    }
}