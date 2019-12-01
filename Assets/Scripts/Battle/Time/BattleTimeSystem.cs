using Entitas;

public class BattleTimeSystem : IInitializeSystem, IExecuteSystem
{
    private readonly ITimeService _timeService;
    private readonly GameContext _gameContext;

    private float lastTimeFireEvent;

    public BattleTimeSystem(Contexts contexts)
    {
        _gameContext = contexts.game;
        _timeService = contexts.service.timeService.instance;
    }

    public void Initialize() 
    {
        //init battle time
        _gameContext.SetBattleTime(new BattleTimeData() {currnetTimeInSeconds = 0.0000f, maxTimeInSeconds = 3 * 60});
        _gameContext.SetUpdateBattleTime(0f);
    }

    public void Execute()
    {
        if (_gameContext.battleTime != null)
        {
            _gameContext.battleTime.value.currnetTimeInSeconds += _timeService.DeltaTime;

            if (_gameContext.battleTime.value.currnetTimeInSeconds - lastTimeFireEvent >= 1f)
            {
                lastTimeFireEvent = _gameContext.battleTime.value.currnetTimeInSeconds;

                _gameContext.ReplaceUpdateBattleTime(_gameContext.battleTime.value.maxTimeInSeconds -
                                                     _gameContext.battleTime.value.currnetTimeInSeconds);
            }
        }
    }
}