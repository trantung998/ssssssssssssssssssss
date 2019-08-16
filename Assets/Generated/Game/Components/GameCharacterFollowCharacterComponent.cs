//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Character.FollowCharacterComponent characterFollowCharacter { get { return (Character.FollowCharacterComponent)GetComponent(GameComponentsLookup.CharacterFollowCharacter); } }
    public bool hasCharacterFollowCharacter { get { return HasComponent(GameComponentsLookup.CharacterFollowCharacter); } }

    public void AddCharacterFollowCharacter(int newId, UnityEngine.Vector2 newOffSet) {
        var index = GameComponentsLookup.CharacterFollowCharacter;
        var component = (Character.FollowCharacterComponent)CreateComponent(index, typeof(Character.FollowCharacterComponent));
        component.id = newId;
        component.offSet = newOffSet;
        AddComponent(index, component);
    }

    public void ReplaceCharacterFollowCharacter(int newId, UnityEngine.Vector2 newOffSet) {
        var index = GameComponentsLookup.CharacterFollowCharacter;
        var component = (Character.FollowCharacterComponent)CreateComponent(index, typeof(Character.FollowCharacterComponent));
        component.id = newId;
        component.offSet = newOffSet;
        ReplaceComponent(index, component);
    }

    public void RemoveCharacterFollowCharacter() {
        RemoveComponent(GameComponentsLookup.CharacterFollowCharacter);
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

    static Entitas.IMatcher<GameEntity> _matcherCharacterFollowCharacter;

    public static Entitas.IMatcher<GameEntity> CharacterFollowCharacter {
        get {
            if (_matcherCharacterFollowCharacter == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CharacterFollowCharacter);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCharacterFollowCharacter = matcher;
            }

            return _matcherCharacterFollowCharacter;
        }
    }
}
