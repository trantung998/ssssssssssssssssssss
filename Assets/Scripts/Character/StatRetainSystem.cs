using Entitas;

public class StatRetainSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _statRetainGroup;


    public StatRetainSystem(Contexts contexts)
    {
        _statRetainGroup = contexts.game.GetGroup(GameMatcher.NeedStatRetain);
        _statRetainGroup.OnEntityAdded += OnEntityAdded;
        _statRetainGroup.OnEntityRemoved += OnEntityRemoved;
    }

    private void OnEntityRemoved(IGroup<GameEntity> @group, GameEntity entity, int index, IComponent component)
    {
    }

    private void OnEntityAdded(IGroup<GameEntity> @group, GameEntity entity, int index, IComponent component)
    {
    }

    public void Execute()
    {
    }
}