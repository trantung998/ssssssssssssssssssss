using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

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

    [Game]
    public class PositionComponent : IComponent
    {
        public Vector3 value;
    }
}