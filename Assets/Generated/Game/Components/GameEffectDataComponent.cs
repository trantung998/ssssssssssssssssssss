//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public EffectDataComponent effectData { get { return (EffectDataComponent)GetComponent(GameComponentsLookup.EffectData); } }
    public bool hasEffectData { get { return HasComponent(GameComponentsLookup.EffectData); } }

    public void AddEffectData(System.Collections.Generic.Dictionary<Combat.EffectId, System.Collections.Generic.List<Combat.BaseEffectData>> newValue) {
        var index = GameComponentsLookup.EffectData;
        var component = (EffectDataComponent)CreateComponent(index, typeof(EffectDataComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceEffectData(System.Collections.Generic.Dictionary<Combat.EffectId, System.Collections.Generic.List<Combat.BaseEffectData>> newValue) {
        var index = GameComponentsLookup.EffectData;
        var component = (EffectDataComponent)CreateComponent(index, typeof(EffectDataComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveEffectData() {
        RemoveComponent(GameComponentsLookup.EffectData);
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

    static Entitas.IMatcher<GameEntity> _matcherEffectData;

    public static Entitas.IMatcher<GameEntity> EffectData {
        get {
            if (_matcherEffectData == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EffectData);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEffectData = matcher;
            }

            return _matcherEffectData;
        }
    }
}
