//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyUpdateBattleTimeListenerComponent anyUpdateBattleTimeListener { get { return (AnyUpdateBattleTimeListenerComponent)GetComponent(GameComponentsLookup.AnyUpdateBattleTimeListener); } }
    public bool hasAnyUpdateBattleTimeListener { get { return HasComponent(GameComponentsLookup.AnyUpdateBattleTimeListener); } }

    public void AddAnyUpdateBattleTimeListener(System.Collections.Generic.List<IAnyUpdateBattleTimeListener> newValue) {
        var index = GameComponentsLookup.AnyUpdateBattleTimeListener;
        var component = (AnyUpdateBattleTimeListenerComponent)CreateComponent(index, typeof(AnyUpdateBattleTimeListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyUpdateBattleTimeListener(System.Collections.Generic.List<IAnyUpdateBattleTimeListener> newValue) {
        var index = GameComponentsLookup.AnyUpdateBattleTimeListener;
        var component = (AnyUpdateBattleTimeListenerComponent)CreateComponent(index, typeof(AnyUpdateBattleTimeListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyUpdateBattleTimeListener() {
        RemoveComponent(GameComponentsLookup.AnyUpdateBattleTimeListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAnyUpdateBattleTimeListener;

    public static Entitas.IMatcher<GameEntity> AnyUpdateBattleTimeListener {
        get {
            if (_matcherAnyUpdateBattleTimeListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyUpdateBattleTimeListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyUpdateBattleTimeListener = matcher;
            }

            return _matcherAnyUpdateBattleTimeListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddAnyUpdateBattleTimeListener(IAnyUpdateBattleTimeListener value) {
        var listeners = hasAnyUpdateBattleTimeListener
            ? anyUpdateBattleTimeListener.value
            : new System.Collections.Generic.List<IAnyUpdateBattleTimeListener>();
        listeners.Add(value);
        ReplaceAnyUpdateBattleTimeListener(listeners);
    }

    public void RemoveAnyUpdateBattleTimeListener(IAnyUpdateBattleTimeListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyUpdateBattleTimeListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyUpdateBattleTimeListener();
        } else {
            ReplaceAnyUpdateBattleTimeListener(listeners);
        }
    }
}
