using Entitas;

namespace EntityDestroyer
{
    public class DestroyEntitySystem : ICleanupSystem, ITearDownSystem
    {
        private readonly IGroup<GameEntity> _destroyedGameEntities;

        private readonly IGroup<InputEntity> _destroyedInputEntities;

        private readonly GameContext _gameContext;
        private readonly InputContext _inputContext;
        private readonly ITimeService _timeService;

        public DestroyEntitySystem(Contexts contexts)
        {
            _gameContext = contexts.game;
            _inputContext = contexts.input;

            _timeService = contexts.service.timeServiceCompoponent.instance;
            
            _destroyedGameEntities = _gameContext.GetGroup(GameMatcher.Destroyed);
            _destroyedInputEntities = _inputContext.GetGroup(InputMatcher.Destroyed);
        }

        public void Cleanup()
        {
            foreach (var e in _destroyedGameEntities.GetEntities())
            {
                if (e.destroyed.IsTimeOut(_timeService.DeltaTime))
                    e.Destroy();
            }

            foreach (var e in _destroyedInputEntities.GetEntities())
            {
                if (e.destroyed.IsTimeOut(_timeService.DeltaTime))
                    e.Destroy();
            }
        }

        public void TearDown()
        {
        }
    }
}