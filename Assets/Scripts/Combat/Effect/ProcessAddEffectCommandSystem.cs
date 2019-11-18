using System.Collections.Generic;
using Entitas;

namespace Combat
{
    public class ProcessAddEffectCommand : ReactiveSystem<GameEntity>
    {
        private readonly GameContext _gameContext;

        public ProcessAddEffectCommand(Contexts contexts) : base(contexts.game)
        {
            _gameContext = contexts.game;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.AddEffectCommand);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasAddEffectCommand;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var command in entities)
            {
                var target = _gameContext.GetEntityWithCharacterCharacterMetaData(command.addEffectCommand.targetId);
                if (target != null)
                {
                    if (!target.hasEffectData) target.AddEffectData(new Dictionary<EffectId, List<BaseEffectData>>());
                    var effectComponent = target.effectData;
                    effectComponent.AddEffect(command.addEffectCommand.value);

                    if (!target.hasActiveEffect) target.AddActiveEffect(new Dictionary<EffectId, BaseEffectData>());
//                    var activeEffect = target.activeEffect.GetEffectData(command.addEffectCommand.value.EffectId);
//
//                    if (activeEffect == null)
//                    {
//                        target.activeEffect.value.Add(command.addEffectCommand.value.EffectId,
//                            command.addEffectCommand.value);
//                    }
                }

                command.Destroy();
            }
        }
    }
}