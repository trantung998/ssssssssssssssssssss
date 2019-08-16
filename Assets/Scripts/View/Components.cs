using Entitas;

namespace View
{
    [Game]
    public class CharacterViewComponent : IComponent
    {
        public IViewController value;
    }

    public enum AssetId
    {
        DummyCharacter,
        DamageView,
    }

    [Game]
    public class AssetComponent : IComponent
    {
        public AssetId value;
    }
}