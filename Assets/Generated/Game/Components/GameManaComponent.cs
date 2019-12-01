//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity manaEntity { get { return GetGroup(GameMatcher.Mana).GetSingleEntity(); } }

    public bool isMana {
        get { return manaEntity != null; }
        set {
            var entity = manaEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isMana = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly ManaComponent manaComponent = new ManaComponent();

    public bool isMana {
        get { return HasComponent(GameComponentsLookup.Mana); }
        set {
            if (value != isMana) {
                var index = GameComponentsLookup.Mana;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : manaComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherMana;

    public static Entitas.IMatcher<GameEntity> Mana {
        get {
            if (_matcherMana == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Mana);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMana = matcher;
            }

            return _matcherMana;
        }
    }
}
