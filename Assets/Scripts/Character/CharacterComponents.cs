using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using EventType = Entitas.CodeGeneration.Attributes.EventType;

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
        public CharacterStat value;
    }

    [Game, Event(EventTarget.Self, EventType.Added)]
    public class PositionComponent : IComponent
    {
        public Vector3 value;
    }

    [Game]
    public class MovementComponent : IComponent
    {
        public float speed;
        public Vector2 direction;
    }

    [Game]
    public class FollowCharacterComponent : IComponent
    {
        public int id;
        public Vector2 offSet;
    }
}