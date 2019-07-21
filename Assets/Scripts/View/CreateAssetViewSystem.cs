using System.Collections.Generic;
using Entitas;

namespace View
{
    public class CreateAssetViewSystem : ReactiveSystem<GameEntity>
    {
        private readonly IViewService _viewService;
        private readonly Contexts _contexts;

        public CreateAssetViewSystem(Contexts contexts) : base(contexts.game)
        {
            _viewService = contexts.service.viewViewService.instance;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.ViewAsset);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasViewAsset;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                _viewService.CreateView(_contexts, gameEntity);
            }
        }
    }
}