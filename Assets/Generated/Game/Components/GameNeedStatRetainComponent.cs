//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly NeedStatRetainComponent needStatRetainComponent = new NeedStatRetainComponent();

    public bool isNeedStatRetain {
        get { return HasComponent(GameComponentsLookup.NeedStatRetain); }
        set {
            if (value != isNeedStatRetain) {
                var index = GameComponentsLookup.NeedStatRetain;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : needStatRetainComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherNeedStatRetain;

    public static Entitas.IMatcher<GameEntity> NeedStatRetain {
        get {
            if (_matcherNeedStatRetain == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.NeedStatRetain);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherNeedStatRetain = matcher;
            }

            return _matcherNeedStatRetain;
        }
    }
}
