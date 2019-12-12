//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public NormalAttackDataComponent normalAttackData { get { return (NormalAttackDataComponent)GetComponent(GameComponentsLookup.NormalAttackData); } }
    public bool hasNormalAttackData { get { return HasComponent(GameComponentsLookup.NormalAttackData); } }

    public void AddNormalAttackData(NormalAttackData newValue) {
        var index = GameComponentsLookup.NormalAttackData;
        var component = (NormalAttackDataComponent)CreateComponent(index, typeof(NormalAttackDataComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceNormalAttackData(NormalAttackData newValue) {
        var index = GameComponentsLookup.NormalAttackData;
        var component = (NormalAttackDataComponent)CreateComponent(index, typeof(NormalAttackDataComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveNormalAttackData() {
        RemoveComponent(GameComponentsLookup.NormalAttackData);
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

    static Entitas.IMatcher<GameEntity> _matcherNormalAttackData;

    public static Entitas.IMatcher<GameEntity> NormalAttackData {
        get {
            if (_matcherNormalAttackData == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NormalAttackData);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNormalAttackData = matcher;
            }

            return _matcherNormalAttackData;
        }
    }
}