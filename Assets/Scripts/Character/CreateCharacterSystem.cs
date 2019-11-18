
    using System.Collections.Generic;
    using Entitas;

    public class CreateCharacterSystem : ReactiveSystem<InputEntity>
    {
        public CreateCharacterSystem(IContext<InputEntity> context) : base(context)
        {
        }

        public CreateCharacterSystem(ICollector<InputEntity> collector) : base(collector)
        {
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            throw new System.NotImplementedException();
        }

        protected override bool Filter(InputEntity entity)
        {
            throw new System.NotImplementedException();
        }

        protected override void Execute(List<InputEntity> entities)
        {
            throw new System.NotImplementedException();
        }
    }
