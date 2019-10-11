using System.Collections.Generic;
using Entitas;

public class InitBehaviourTreeSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;

    public InitBehaviourTreeSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BT.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasBT;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.bT.treeController.Init(_contexts, entity);
            entity.bT.treeController.CreateTree();
        }
    }
}