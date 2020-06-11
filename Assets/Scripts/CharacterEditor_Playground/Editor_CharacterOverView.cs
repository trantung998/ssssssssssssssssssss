using Sirenix.Utilities;

[GlobalConfig("Resources/Database/Characters", UseAsset = true)]
public class Editor_CharacterOverView : GlobalConfig<Editor_CharacterOverView>
{
    public Editor_CharacterData[] AllCharacters;
}