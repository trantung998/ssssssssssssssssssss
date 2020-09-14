using First.EntityStructs;
using First.EntityViews;
using Svelto.ECS;

namespace First.Descriptors
{
    public class PlayerInputEntityDescriptor : IEntityDescriptor
    {
        static readonly IComponentBuilder[] _componentsToBuild = {new ComponentBuilder<SteeringInputComponent>(),};

        public IComponentBuilder[] componentsToBuild => _componentsToBuild;
    }
}