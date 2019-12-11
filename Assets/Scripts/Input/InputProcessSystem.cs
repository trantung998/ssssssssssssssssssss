using System.Collections.Generic;
using Combat;
using Combat.Slow;
using Entitas;

namespace Input
{
    public class InputProcessSystem : ReactiveSystem<InputEntity>
    {
        private readonly GameContext _gameContext;
        private readonly IRandomService _randomService;

        public InputProcessSystem(Contexts contexts) : base(contexts.input)
        {
            _gameContext = contexts.game;
            _randomService = contexts.service.randomService.instance;
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

                    var effectCommandEntity = _gameContext.CreateEntity();
                    effectCommandEntity.AddAddEffectCommand(normalAttackInput.targetId,
                        new SlowEffectData(_randomService.GetFloat(1f, 3f), _randomService.GetFloat()));
                }

                inputEntity.Destroy();
            }
        }
    }
}