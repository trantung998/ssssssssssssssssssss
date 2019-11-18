using System.Collections.Generic;

namespace Character
{
    public enum CharacterStatId
    {
        MaxHp,
        Damage,
        Armor,
        MoveSpeed,
        CriticalChange,
        CriticalDamageScale,
    }

    public class BaseStat
    {
        public CharacterStatId StatId;
        public float originValue;
        public float activeValue;

        public BaseStat(CharacterStatId statId, float originValue)
        {
            StatId = statId;
            this.originValue = originValue;
            this.activeValue = originValue;
        }
    }


//    public class CharacterStat
//    {
//        public float attackDamage;
//        public float health;
//        public float armor;
//        public float criticalChance;
//        public float criticalDamageFactor;
//    }
}