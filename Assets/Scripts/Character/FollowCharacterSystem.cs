using Entitas;


public class FollowCharacterSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _group;
    private readonly GameContext _gameContext;

    public FollowCharacterSystem(Contexts contexts)
    {
        _gameContext = contexts.game;
        _group = _gameContext.GetGroup(GameMatcher.CharacterFollowCharacter);
    }

    public void Execute()
    {
        foreach (var gameEntity in _group.GetEntities())
        {
            var target =
                _gameContext.GetEntityWithCharacterCharacterMetaData(gameEntity.characterFollowCharacter.id);
            if (target != null && target.isEnabled && target.hasCharacterPosition)
            {
                gameEntity.characterPosition.value = target.characterPosition.value;
            }
            else
            {
                gameEntity.AddDestroyed(0f);
            }
        }
    }
}