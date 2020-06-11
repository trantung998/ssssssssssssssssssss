using System.Collections.Generic;
using System.Linq;
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
            return context.CreateCollector(GameMatcher.NormalAttackData);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasNormalAttackData;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var normalAttackEntity in entities)
            {
                var combatNormalAttackData = normalAttackEntity.normalAttackData.value;
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
            var sourceStatDatas =
                _gameContext.GetEntitiesWithCharacterCharacterStats(source.characterCharacterMetaData.id);
            if (sourceStatDatas == null) return;

            var sourceStatEntity = sourceStatDatas.FirstOrDefault();

            if (sourceStatEntity != null)
            {
                if (sourceStatEntity.characterCharacterStats.retainCount > 0)
                {
                    var sourceDamage = sourceStatEntity.characterCharacterStats.GetStat(CharacterStatId.Damage);

                    if (sourceDamage == null) return;
                    var damageValue = sourceDamage.ActiveValue;

                    //do some things fun
                    //critical...
                    //Life Steal...
                    //etc
                    var isCritical = ProcessCritical(sourceStatEntity, target, ref damageValue);

                    ProcessArmor(sourceStatEntity, target, ref damageValue);

                    ProcessLifeSteal(sourceStatEntity, target, ref damageValue);

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
            }
        }

        private void ProcessArmor(GameEntity sourceEntity, GameEntity targetEntity, ref float inputDamageValue)
        {
            var targetArmor = targetEntity.characterCharacterStats.GetStat(CharacterStatId.Armor);
            if (targetArmor == null) return;
            //theo dota2
            var damageMultiplier = 1 - ((0.052f * targetArmor.ActiveValue) /
                                        (0.9f + 0.048f * MathFast.Abs(targetArmor.ActiveValue)));

            inputDamageValue = (inputDamageValue * damageMultiplier);


            var targetHpValue = targetEntity.characterCharacterStats.GetStat(CharacterStatId.Hp);
            if (targetHpValue == null)
            {
                //lỗi
                return;
            }

            targetHpValue.ActiveValue -= inputDamageValue;
            //done
        }

        private void ProcessLifeSteal(GameEntity sourceEntity, GameEntity targetEntity, ref float inputDamageValue)
        {
        }

        private bool ProcessCritical(GameEntity sourceStatEntity, GameEntity targetEntity, ref float inputDamageValue)
        {
            var criticalChance = sourceStatEntity.characterCharacterStats.GetStat(CharacterStatId.CriticalChange);
            if (criticalChance == null) return false;

//            var damageOutput = sourceDamage.activeValue;
            var isCritical = false;

            if (criticalChance.ActiveValue > 0)
            {
                var random = _randomService.GetFloat();

                if (criticalChance.ActiveValue <= random)
                {
                    //critical trigger
                    var criticalDamage =
                        sourceStatEntity.characterCharacterStats.GetStat(CharacterStatId.CriticalDamageScale);

                    inputDamageValue *= criticalDamage.ActiveValue;
                    isCritical = true;
                }
            }

            return isCritical;
        }
    }
}