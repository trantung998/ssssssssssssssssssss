using Entitas;


public class TeardownGameSystem : ITearDownSystem
{
    private IGroup<GameEntity> gameViewEntity;

    public TeardownGameSystem(Contexts contexts)
    {
        gameViewEntity = contexts.game.GetGroup(GameMatcher.ViewCharacterView);
    }

    public void TearDown()
    {
        foreach (var gameEntity in gameViewEntity.GetEntities())
        {
            gameEntity.viewCharacterView.value.OnEntityDestroyed();
        }
    }
}