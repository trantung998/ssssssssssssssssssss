//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public DelayEntityDestroyedComponent delayEntityDestroyed { get { return (DelayEntityDestroyedComponent)GetComponent(InputComponentsLookup.DelayEntityDestroyed); } }
    public bool hasDelayEntityDestroyed { get { return HasComponent(InputComponentsLookup.DelayEntityDestroyed); } }

    public void AddDelayEntityDestroyed(float newDelayTime) {
        var index = InputComponentsLookup.DelayEntityDestroyed;
        var component = (DelayEntityDestroyedComponent)CreateComponent(index, typeof(DelayEntityDestroyedComponent));
        component.delayTime = newDelayTime;
        AddComponent(index, component);
    }

    public void ReplaceDelayEntityDestroyed(float newDelayTime) {
        var index = InputComponentsLookup.DelayEntityDestroyed;
        var component = (DelayEntityDestroyedComponent)CreateComponent(index, typeof(DelayEntityDestroyedComponent));
        component.delayTime = newDelayTime;
        ReplaceComponent(index, component);
    }

    public void RemoveDelayEntityDestroyed() {
        RemoveComponent(InputComponentsLookup.DelayEntityDestroyed);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity : IDelayEntityDestroyedEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherDelayEntityDestroyed;

    public static Entitas.IMatcher<InputEntity> DelayEntityDestroyed {
        get {
            if (_matcherDelayEntityDestroyed == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.DelayEntityDestroyed);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherDelayEntityDestroyed = matcher;
            }

            return _matcherDelayEntityDestroyed;
        }
    }
}
