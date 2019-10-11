//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public StunEffectActiveComponent stunEffectActive { get { return (StunEffectActiveComponent)GetComponent(GameComponentsLookup.StunEffectActive); } }
    public bool hasStunEffectActive { get { return HasComponent(GameComponentsLookup.StunEffectActive); } }

    public void AddStunEffectActive(Combat.StunEffectData newValue) {
        var index = GameComponentsLookup.StunEffectActive;
        var component = (StunEffectActiveComponent)CreateComponent(index, typeof(StunEffectActiveComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceStunEffectActive(Combat.StunEffectData newValue) {
        var index = GameComponentsLookup.StunEffectActive;
        var component = (StunEffectActiveComponent)CreateComponent(index, typeof(StunEffectActiveComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveStunEffectActive() {
        RemoveComponent(GameComponentsLookup.StunEffectActive);
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

    static Entitas.IMatcher<GameEntity> _matcherStunEffectActive;

    public static Entitas.IMatcher<GameEntity> StunEffectActive {
        get {
            if (_matcherStunEffectActive == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StunEffectActive);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStunEffectActive = matcher;
            }

            return _matcherStunEffectActive;
        }
    }
}
