using First.EntityViews.Components;
using Svelto.ECS;
using Svelto.ECS.Hybrid;

namespace First.EntityViews
{
    public struct CharacterEntityViewComponents : IEntityViewComponent
    {
        public ITransformComponent TransformComponent;
        public IPositionComponent PositionComponent;
        public IAnimationComponent AnimationComponent;
        public IHealthComponent Health;

        public EGID ID { get; set; }
    }
}