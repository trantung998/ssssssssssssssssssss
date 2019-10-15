using Combat;
using Combat.Slow;
using Entitas;


public class ProcessSlowEffectSystem : IExecuteSystem
{
    private GameContext _gameContext;
    private IGroup<GameEntity> _groupEntityHasEffect;
    private ITimeService _timeService;

    public ProcessSlowEffectSystem(Contexts contexts)
    {
        _gameContext = contexts.game;
        _groupEntityHasEffect = _gameContext.GetGroup(GameMatcher.EffectData);
        _timeService = contexts.service.timeServiceCompoponent.instance;
    }

    public void Execute()
    {
        foreach (var gameEntity in _groupEntityHasEffect.GetEntities())
        {
            gameEntity.effectData.value.TryGetValue(EffectId.Slow, out var slowEffectDatas);
            if (slowEffectDatas != null)
            {
                var bestValue = 0f;
                var bestDuration = 0f;
                for (var i = slowEffectDatas.Count - 1; i >= 0; i--)
                {
                    var slowEffectData = slowEffectDatas[i] as SlowEffectData;
                    if (slowEffectData != null)
                    {
                        slowEffectData.RemainTime -= _timeService.DeltaTime;
                        if (slowEffectData.RemainTime <= 0)
                        {
                            slowEffectDatas.RemoveAt(i);
                            continue;
                        }

                        if (bestValue < slowEffectData.slowValue) bestValue = slowEffectData.slowValue;
                        if (bestDuration < slowEffectData.RemainTime) bestDuration = slowEffectData.RemainTime;
                    }
                }

                var activeData = gameEntity.activeEffect.GetEffectData(EffectId.Slow);
                if (activeData != null)
                {
                    activeData.RemainTime = bestDuration;
                    ((SlowEffectData) activeData).slowValue = bestValue;
                }
                else
                {
                    gameEntity.activeEffect.value.Add(EffectId.Slow, new SlowEffectData(bestDuration, bestValue));
                }
            }
        }
    }
}