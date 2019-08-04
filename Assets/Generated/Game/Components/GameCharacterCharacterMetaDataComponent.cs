//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public Character.CharacterMetaDataComponent characterCharacterMetaData { get { return (Character.CharacterMetaDataComponent)GetComponent(GameComponentsLookup.CharacterCharacterMetaData); } }
    public bool hasCharacterCharacterMetaData { get { return HasComponent(GameComponentsLookup.CharacterCharacterMetaData); } }

    public void AddCharacterCharacterMetaData(int newId, Character.CharacterMetaData newValue) {
        var index = GameComponentsLookup.CharacterCharacterMetaData;
        var component = (Character.CharacterMetaDataComponent)CreateComponent(index, typeof(Character.CharacterMetaDataComponent));
        component.id = newId;
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCharacterCharacterMetaData(int newId, Character.CharacterMetaData newValue) {
        var index = GameComponentsLookup.CharacterCharacterMetaData;
        var component = (Character.CharacterMetaDataComponent)CreateComponent(index, typeof(Character.CharacterMetaDataComponent));
        component.id = newId;
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCharacterCharacterMetaData() {
        RemoveComponent(GameComponentsLookup.CharacterCharacterMetaData);
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

    static Entitas.IMatcher<GameEntity> _matcherCharacterCharacterMetaData;

    public static Entitas.IMatcher<GameEntity> CharacterCharacterMetaData {
        get {
            if (_matcherCharacterCharacterMetaData == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CharacterCharacterMetaData);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCharacterCharacterMetaData = matcher;
            }

            return _matcherCharacterCharacterMetaData;
        }
    }
}