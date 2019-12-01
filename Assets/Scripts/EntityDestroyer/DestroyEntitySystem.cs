using Entitas;

namespace EntityDestroyer
{
    public class DestroyEntitySystem : ICleanupSystem, ITearDownSystem
    {
        private readonly IGroup<GameEntity> _destroyedGameEntities;
        private readonly IGroup<GameEntity> _delayDestroyedGameEntities;

        private readonly IGroup<InputEntity> _destroyedInputEntities;

        private readonly GameContext _gameContext;
        private readonly InputContext _inputContext;
        private readonly ITimeService _timeService;

        public DestroyEntitySystem(Contexts contexts)
        {
            _gameContext = contexts.game;
            _inputContext = contexts.input;

            _timeService = contexts.service.timeService.instance;

            _destroyedGameEntities =
                _gameContext.GetGroup(GameMatcher.EntityDestroyed);

            _delayDestroyedGameEntities =
                _gameContext.GetGroup(
                    GameMatcher.DelayEntityDestroyed);

            _destroyedInputEntities = _inputContext.GetGroup(InputMatcher.DelayEntityDestroyed);
        }

        public void Cleanup()
        {
            foreach (var gameEntity in _delayDestroyedGameEntities.GetEntities())
            {
                if (gameEntity.delayEntityDestroyed.IsTimeOut(_timeService.DeltaTime))
                {
                    gameEntity.isEntityDestroyed = true;
                }
            }

            foreach (var e in _destroyedGameEntities.GetEntities())
            {
                if (e.isEntityDestroyed)
                {
                    DestroyView(e);
                    e.Destroy();
                }
            }

            foreach (var e in _destroyedInputEntities.GetEntities())
            {
                if (e.delayEntityDestroyed.IsTimeOut(_timeService.DeltaTime))
                    e.Destroy();
            }
        }

        private void DestroyView(GameEntity gameEntity)
        {
            if (gameEntity.hasViewCharacterView) gameEntity.viewCharacterView.value.OnEntityDestroyed();
        }

        public void TearDown()
        {
        }
    }
}