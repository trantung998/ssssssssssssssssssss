//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BTComponent bT { get { return (BTComponent)GetComponent(GameComponentsLookup.BT); } }
    public bool hasBT { get { return HasComponent(GameComponentsLookup.BT); } }

    public void AddBT(IBTController newTreeController) {
        var index = GameComponentsLookup.BT;
        var component = (BTComponent)CreateComponent(index, typeof(BTComponent));
        component.treeController = newTreeController;
        AddComponent(index, component);
    }

    public void ReplaceBT(IBTController newTreeController) {
        var index = GameComponentsLookup.BT;
        var component = (BTComponent)CreateComponent(index, typeof(BTComponent));
        component.treeController = newTreeController;
        ReplaceComponent(index, component);
    }

    public void RemoveBT() {
        RemoveComponent(GameComponentsLookup.BT);
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

    static Entitas.IMatcher<GameEntity> _matcherBT;

    public static Entitas.IMatcher<GameEntity> BT {
        get {
            if (_matcherBT == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BT);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBT = matcher;
            }

            return _matcherBT;
        }
    }
}