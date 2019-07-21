using System.Collections.Generic;
using Character;
using Entitas;

namespace Combat
{
    public class NormalAttackProcessSystem : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;

        public NormalAttackProcessSystem(Contexts contexts) : base(contexts.game)
        {
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
            target.characterCharacterStats.health -=
                (source.characterCharacterStats.attackDamage - target.characterCharacterStats.armor);
        }
    }
}