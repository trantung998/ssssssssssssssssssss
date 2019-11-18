using System.Collections.Generic;
using Character;
using Entitas;
using Indicator;
using LeopotamGroup.Math;

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
            var sourceDamage = source.characterCharacterStats.GetStat(CharacterStatId.Damage);
            if (sourceDamage == null) return;
            var damageValue = sourceDamage.activeValue;

            //do some things fun
            //critical...
            //Life Steal...
            //etc
            var isCritical = ProcessCritical(source, target, ref damageValue);

            ProcessArmor(source, target, ref damageValue);

            ProcessLifeSteal(source, target, ref damageValue);

            var damageIndicator = new DamageIndicatorData()
            {
                targetId = target.characterCharacterMetaData.id,
                type = IndicatorType.Damage,
                isCriticalHit = isCritical,
                value = damageValue,
            };

            var damageIndicatorEntity = _gameContext.CreateEntity();
            damageIndicatorEntity.AddIndicatorIndicator(damageIndicator);
        }

        private void ProcessArmor(GameEntity sourceEntity, GameEntity targetEntity, ref float inputDamageValue)
        {
            var targetArmor = targetEntity.characterCharacterStats.GetStat(CharacterStatId.Armor);
            if (targetArmor == null) return;
            //theo dota2
            var damageMultiplier = 1 - ((0.052f * targetArmor.activeValue) /
                                        (0.9f + 0.048f * MathFast.Abs(targetArmor.activeValue)));

            inputDamageValue = (inputDamageValue * damageMultiplier);


            var targetHpValue = targetEntity.characterCharacterStats.GetStat(CharacterStatId.MaxHp);
            if (targetHpValue == null)
            {
                //lỗi
                return;
            }

            targetHpValue.activeValue -= inputDamageValue;
            //done
        }

        private void ProcessLifeSteal(GameEntity sourceEntity, GameEntity targetEntity, ref float inputDamageValue)
        {
        }

        private bool ProcessCritical(GameEntity sourceEntity, GameEntity targetEntity, ref float inputDamageValue)
        {
            var criticalChance = sourceEntity.characterCharacterStats.GetStat(CharacterStatId.CriticalChange);
            if (criticalChance == null) return false;

//            var damageOutput = sourceDamage.activeValue;
            var isCritical = false;

            if (criticalChance.activeValue > 0)
            {
                var random = _randomService.GetFloat();

                if (criticalChance.activeValue <= random)
                {
                    //critical trigger
                    var criticalDamage =
                        sourceEntity.characterCharacterStats.GetStat(CharacterStatId.CriticalDamageScale);

                    inputDamageValue *= criticalDamage.activeValue;
                    isCritical = true;
                }
            }

            return isCritical;
        }
    }
}