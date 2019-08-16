using System.Collections.Generic;
using Entitas;
using Indicator;
using UnityEngine;
using View;

public class SpawnIndicatorSystem : ReactiveSystem<GameEntity>
{
    public SpawnIndicatorSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.IndicatorIndicator)
            .NoneOf(GameMatcher.ViewAsset, GameMatcher.ViewCharacterView));
    }

    protected override bool Filter(GameEntity entity)
    {
        return !entity.hasViewAsset && entity.hasIndicatorIndicator;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            entity.AddViewAsset(GetViewId(entity.indicatorIndicator));
            entity.AddCharacterPosition(Vector3.zero);
            entity.AddCharacterFollowCharacter(entity.indicatorIndicator.value.targetId, Vector2.up);
        }
    }

    private AssetId GetViewId(IndicatorComponent indicatorComponent)
    {
        var data = indicatorComponent.value;
        if (data is DamageIndicatorData) return AssetId.DamageView;
        return AssetId.DamageView;
    }
}