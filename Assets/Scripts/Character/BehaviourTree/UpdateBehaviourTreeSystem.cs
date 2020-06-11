using Entitas;


public class UpdateBehaviourTreeSystem : IExecuteSystem
{
    private IGroup<GameEntity> _entityGroup;
    private ITimeService _timeService;
    private IBTService _btService;

    public UpdateBehaviourTreeSystem(Contexts contexts)
    {
        _entityGroup = contexts.game.GetGroup(GameMatcher.BT);
        _timeService = contexts.service.timeService.instance;
        _btService = contexts.service.bTService.instance;
    }

    public void Execute()
    {
        //Update global clock
        _btService.Update(_timeService.DeltaTime);

        //update custom clocks
        foreach (var gameEntity in _entityGroup.GetEntities())
        {
            gameEntity.bT.treeController.UpdateTree(_timeService.DeltaTime);
        }
    }
}