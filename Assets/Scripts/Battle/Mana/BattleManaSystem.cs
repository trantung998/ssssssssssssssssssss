using System.Collections.Generic;
using Entitas;

public class BattleManaSystem : IInitializeSystem, IExecuteSystem
{
    private GameContext _gameContext;
    private ITimeService _timeService;

    private int maxManaValue;
    private float gainManaSpeed;
    private IGroup<InputEntity> _consumeManaEntities;

    public BattleManaSystem(Contexts contexts)
    {
        _gameContext = contexts.game;
        _timeService = contexts.service.timeService.instance;

        _consumeManaEntities = contexts.input.GetGroup(InputMatcher.ConsumeManaCommand);
    }

    public void Initialize()
    {
        maxManaValue = 10;
        gainManaSpeed = 1f;

        _gameContext.SetMana(new List<ManaData>() {new ManaData(), new ManaData()});
        _gameContext.mana.InitData(maxManaValue, 5f);
    }

    public void Execute()
    {
        var manaGainValue = _timeService.DeltaTime * gainManaSpeed;

        _gameContext.mana.ChangeManaValue(0, manaGainValue);
        _gameContext.mana.ChangeManaValue(1, manaGainValue);

        foreach (var entity in _consumeManaEntities.GetEntities())
        {
            var teamid = entity.consumeManaCommand.teamId;
            if (_gameContext.mana.IsManaValueEnoughToUse(teamid, entity.consumeManaCommand.value))
                _gameContext.mana.ChangeManaValue(teamid, entity.consumeManaCommand.value);

            entity.isEntityDestroyed = true;
        }
    }
}