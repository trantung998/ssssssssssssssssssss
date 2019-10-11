using System.Collections.Generic;
using Character;
using Entitas;
using Indicator;

namespace Combat
{
    public class NormalAttackProcessSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;
        private readonly IRandomService _randomService;

        public NormalAttackProcessSystem(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
            _randomService = contexts.service.randomService.instance;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.CombatNormalAttackData);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasCombatNormalAttackData;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var normalAttackEntity in entities)
            {
                var combatNormalAttackData = normalAttackEntity.combatNormalAttackData.value;
                var sourceEntity = _gameContext.GetEntityWithCharacterCharacterMetaData(combatNormalAttackData.source);
                if (sourceEntity != null && sourceEntity.isEnabled)
                {
                    var targetEntity =
                        _gameContext.GetEntityWithCharacterCharacterMetaData(combatNormalAttackData.target);
                    if (targetEntity != null && targetEntity.isEnabled)
                    {
                        ProcessDamage(sourceEntity, targetEntity);
                    }
                }

                normalAttackEntity.Destroy();
            }
        }

        private void ProcessDamage(GameEntity source, GameEntity target)
        {
            //do some things fun
            //critical...
            //Life Steal...
            //etc
            ProcessCritical(source.characterCharacterStats.value, 
                target.characterCharacterMetaData.id,
                ref target.characterCharacterStats.value);
        }

        private void ProcessCritical(CharacterStat source, int targetId, ref CharacterStat target)
        {
            var damage = source.attackDamage;
            var criticalChance = source.criticalChance;
            var damageIndicator = new DamageIndicatorData()
            {
                targetId = targetId,
                type = IndicatorType.Damage
            };
            if (criticalChance > 0)
            {
                var random = _randomService.GetFloat();

                if (criticalChance <= random)
                {
                    //critical trigger
                    damage *= source.criticalDamageFactor;
                    damageIndicator.isCriticalHit = true;
                }
            }

            var actualDamage = (damage - target.armor);
            damageIndicator.value = actualDamage;
            target.health -= actualDamage;

            var damageIndicatorEntity = _gameContext.CreateEntity();
            damageIndicatorEntity.AddIndicatorIndicator(damageIndicator);
        }
    }
}