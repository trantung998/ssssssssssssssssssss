//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    public SpawnCharacterComponent spawnCharacter { get { return (SpawnCharacterComponent)GetComponent(InputComponentsLookup.SpawnCharacter); } }
    public bool hasSpawnCharacter { get { return HasComponent(InputComponentsLookup.SpawnCharacter); } }

    public void AddSpawnCharacter(SpawnCharacterData newValue) {
        var index = InputComponentsLookup.SpawnCharacter;
        var component = (SpawnCharacterComponent)CreateComponent(index, typeof(SpawnCharacterComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSpawnCharacter(SpawnCharacterData newValue) {
        var index = InputComponentsLookup.SpawnCharacter;
        var component = (SpawnCharacterComponent)CreateComponent(index, typeof(SpawnCharacterComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSpawnCharacter() {
        RemoveComponent(InputComponentsLookup.SpawnCharacter);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherSpawnCharacter;

    public static Entitas.IMatcher<InputEntity> SpawnCharacter {
        get {
            if (_matcherSpawnCharacter == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.SpawnCharacter);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherSpawnCharacter = matcher;
            }

            return _matcherSpawnCharacter;
        }
    }
}
