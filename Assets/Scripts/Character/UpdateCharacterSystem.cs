using Entitas;

namespace Character
{
    public class UpdateCharacterSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _characterGroup;
        private readonly GameContext _gameContext;

        public UpdateCharacterSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
            _characterGroup = _gameContext.GetGroup(GameMatcher.ViewCharacterView);
        }

        public void Execute()
        {
            foreach (var gameEntity in _characterGroup.GetEntities())
            {
                gameEntity.viewCharacterView.value.OnUpdate(_gameContext.gameTimeTick.value);
            }
        }
    }
}