using First.Engines;
using First.Engines.Character;
using First.Factories;
using First.Services;
using Svelto.Context;
using Svelto.DataStructures;
using Svelto.ECS;
using Svelto.ECS.Extensions;
using Svelto.ECS.Schedulers.Unity;
using Svelto.Tasks;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MainCompositionRoot : ICompositionRoot
{
    EnginesRoot _enginesRoot;
    IEntityFactory _entityFactory;
    UnityEntitiesSubmissionScheduler _unityEntitySubmissionScheduler;

    public MainCompositionRoot()
    {
        QualitySettings.vSyncCount = 1;
    }

    public void OnContextInitialized<T>(T contextHolder)
    {
        CompositionRoot(contextHolder as UnityContext);
    }

    public void OnContextDestroyed()
    {
        //clean engines
        _enginesRoot.Dispose();

        //stop task-runner
        TaskRunner.StopAndCleanupAllDefaultSchedulers();
    }

    public void OnContextCreated<T>(T contextHolder)
    {
    }

    void CompositionRoot(UnityContext contextHolder)
    {
        _unityEntitySubmissionScheduler = new UnityEntitiesSubmissionScheduler();
        _enginesRoot = new EnginesRoot(_unityEntitySubmissionScheduler);

        _entityFactory = _enginesRoot.GenerateEntityFactory();

        //The entity functions is a set of utility operations on Entities, including removing an entity. I couldn't
        //find a better name so far.
        var entityFunctions = _enginesRoot.GenerateEntityFunctions();

        var playerInputEngine = new PlayerInputEngine(_entityFactory);
        _enginesRoot.AddEngine(playerInputEngine);

        var characterFactory = new CharacterFactory(Service<ResourceService>.Get(), _entityFactory);
        var spawnCharacterEngine = new SpawnCharacterEngine(entityFunctions, characterFactory);
        _enginesRoot.AddEngine(spawnCharacterEngine);

        var applyDamageEngine = new ApplyDamageEngine();
        _enginesRoot.AddEngine(applyDamageEngine);

        var updateHealthEngine = new UpdateHealthEngine();
        _enginesRoot.AddEngine(updateHealthEngine);
        var movementEngine = new MovementEngine();
        _enginesRoot.AddEngine(movementEngine);

        var characterDeathEngine = new CharacterDeathEngine();
        _enginesRoot.AddEngine(characterDeathEngine);

        var steeringEngine = new SteeringEngine();
        _enginesRoot.AddEngine(steeringEngine);

        var moveEngines = new MoveEngines<MoveEnginesOrder>(new FasterList<IStepEngine>(new IStepEngine[] {steeringEngine, movementEngine}));
        _enginesRoot.AddEngine(moveEngines);
    }
}