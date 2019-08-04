using System.Collections.Generic;
using Combat;
using Entitas;

namespace Input
{
    public class InputProcessSystem : ReactiveSystem<InputEntity>
    {
        private readonly GameContext _gameContext;

        public InputProcessSystem(Contexts contexts) : base(contexts.input)
        {
            _gameContext = contexts.game;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.InputData.Added());
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasInputData;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var inputEntity in entities)
            {
                if (inputEntity.inputData.value.Type == InputType.TestNormalAttack)
                {
                    var normalAttackInput = (TestNormalAttackInput) inputEntity.inputData.value;
                    var attackRequest = _gameContext.CreateEntity();
                    attackRequest.AddCombatNormalAttackData(new NormalAttackData()
                    {
                        source = normalAttackInput.sourceId,
                        target = normalAttackInput.targetId,
                    });
                }

                inputEntity.Destroy();
            }
        }
    }
}