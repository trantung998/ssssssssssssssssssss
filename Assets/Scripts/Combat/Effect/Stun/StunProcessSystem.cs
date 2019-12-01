using Entitas;

namespace Combat
{
    public class StunProcessSystem : IExecuteSystem
    {
        private IGroup<GameEntity> stunedEntities;
        private ITimeService _timeService;

        public StunProcessSystem(Contexts contexts)
        {
            stunedEntities = contexts.game.GetGroup(GameMatcher.EffectData);
            _timeService = contexts.service.timeService.instance;
        }

        public void Execute()
        {
            foreach (var gameEntity in stunedEntities.GetEntities())
            {
                gameEntity.effectData.value.TryGetValue(EffectId.Stun, out var stunEffectDataList);

                if (stunEffectDataList != null)
                {
                    var bestDuration = 0f;

                    for (var i = stunEffectDataList.Count - 1; i >= 0; i--)
                    {
                        var baseEffectData = stunEffectDataList[i];
                        if (baseEffectData.RemainTime > 0)
                        {
                            baseEffectData.RemainTime -= _timeService.DeltaTime;
                            if (baseEffectData.RemainTime > bestDuration) bestDuration = baseEffectData.RemainTime;
                        }
                        else
                        {
                            stunEffectDataList.RemoveAt(i);
                            continue;
                        }
                    }

                    var activeData = gameEntity.activeEffect.GetEffectData(EffectId.Stun);
                    if (activeData != null)
                    {
                        activeData.RemainTime = bestDuration;
                    }
                    else
                    {
                        gameEntity.activeEffect.value.Add(EffectId.Stun, new StunEffectData(bestDuration));
                    }
                }
            }
        }
    }
}