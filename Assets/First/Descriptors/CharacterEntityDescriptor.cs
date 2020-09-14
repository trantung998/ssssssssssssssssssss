using First.EntityStructs;
using First.EntityViews;
using Svelto.ECS;
using UnityEngine;

// namespace Svelto.ECS.First.Descriptors
// {
    public class CharacterEntityDescriptor : IEntityDescriptor
    {
        public CharacterEntityDescriptor()
        {
            Debug.Log("");
        }

        static readonly IComponentBuilder[] _componentsToBuild =
        {
            new ComponentBuilder<CharacterEntityViewComponents>(), 
            new ComponentBuilder<CharacterHealthComponent>(), 
            new ComponentBuilder<DamageableEntityStruct>(),
            new ComponentBuilder<MovementComponent>(),
            new ComponentBuilder<SteeringComponent>(),
        };

        public IComponentBuilder[] componentsToBuild => _componentsToBuild;
    }
// }