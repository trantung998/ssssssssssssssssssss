using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Character
{
    public class CharacterMetaData
    {
        public string displayName;

        public int level;

        //etc....
    }

    [Game]
    public class CharacterMetaDataComponent : IComponent
    {
        [PrimaryEntityIndex] public int id;

        public CharacterMetaData value;
    }

    [Game]
    public class CharacterStatsComponent : IComponent
    {
        public float attackDamage;
        public float health;
        public float armor;
    }
}