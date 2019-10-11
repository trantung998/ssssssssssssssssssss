using Entitas;

namespace Combat
{
    public class StunProcessSystem : IExecuteSystem
    {
        private IGroup<GameEntity> stunedEntities;
        private ITimeService _timeService;

        public StunProcessSystem(Contexts contexts)
        {
            stunedEntities = contexts.game.GetGroup(GameMatcher.StunEffectActive);
            _timeService = contexts.service.timeServiceCompoponent.instance;
        }

        public void Execute()
        {
            foreach (var gameEntity in stunedEntities.GetEntities())
            {
                if (gameEntity.stunEffectActive.value.RemainTime > 0)
                {
                    if (!gameEntity.hasCombatEffectStatus) gameEntity.AddCombatEffectStatus(0);
                    var statusValue = gameEntity.combatEffectStatus.value;
                    
                    if (!gameEntity.stunEffectActive.value.IsEffectActive(statusValue))
                    {
                        gameEntity.stunEffectActive.value.SetEffectState(ref statusValue);
                    }

                    gameEntity.stunEffectActive.value.RemainTime -= _timeService.DeltaTime;
                }

                else
                {
                    var statusValue = gameEntity.combatEffectStatus.value;
                    gameEntity.stunEffectActive.value.SetEffectState(ref statusValue, false);
                }
            }
        }
    }
}