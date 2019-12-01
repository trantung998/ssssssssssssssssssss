using Entitas;

public class GameManaSystem : IInitializeSystem, IExecuteSystem
{
    private GameContext _gameContext;
    private ITimeService _timeService;
    
    private int maxManaValue;
    private float gainManaSpeed;

    public void Initialize()
    {
        maxManaValue = 20;
        gainManaSpeed = 1f;
    }

    public void Execute()
    {
//        _gameContext.manaEntity
    }
}