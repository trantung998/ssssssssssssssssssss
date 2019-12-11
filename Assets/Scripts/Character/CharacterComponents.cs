using System.Collections.Generic;
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

        public int teamId;
        //etc....
    }

    public class StatData
    {
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
        [EntityIndex] public int characterId;
        public int retainCount;
        public List<BaseStat> Stats;
        
        public BaseStat GetStat(CharacterStatId id)
        {
            if (Stats != null)
            {
                for (int i = 0; i < Stats.Count; i++)
                {
                    if (Stats[i].StatId == id)
                    {
                        return Stats[i];
                    }
                }
            }

            return null;
        }

        public void AddOrReplaceStat(BaseStat newStat)
        {
            if (Stats == null) Stats = new List<BaseStat>();
            var exitsStatIndex = Stats.FindIndex(stat => stat.StatId == newStat.StatId);
            if (exitsStatIndex < 0)
            {
                Stats.Add(newStat);
            }
            else
            {
                Stats[exitsStatIndex] = newStat;
            }
        }
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