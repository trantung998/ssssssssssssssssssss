//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ActiveEffectComponent activeEffect { get { return (ActiveEffectComponent)GetComponent(GameComponentsLookup.ActiveEffect); } }
    public bool hasActiveEffect { get { return HasComponent(GameComponentsLookup.ActiveEffect); } }

    public void AddActiveEffect(System.Collections.Generic.Dictionary<Combat.EffectId, Combat.BaseEffectData> newValue) {
        var index = GameComponentsLookup.ActiveEffect;
        var component = (ActiveEffectComponent)CreateComponent(index, typeof(ActiveEffectComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceActiveEffect(System.Collections.Generic.Dictionary<Combat.EffectId, Combat.BaseEffectData> newValue) {
        var index = GameComponentsLookup.ActiveEffect;
        var component = (ActiveEffectComponent)CreateComponent(index, typeof(ActiveEffectComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveActiveEffect() {
        RemoveComponent(GameComponentsLookup.ActiveEffect);
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

    static Entitas.IMatcher<GameEntity> _matcherActiveEffect;

    public static Entitas.IMatcher<GameEntity> ActiveEffect {
        get {
            if (_matcherActiveEffect == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ActiveEffect);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherActiveEffect = matcher;
            }

            return _matcherActiveEffect;
        }
    }
}
