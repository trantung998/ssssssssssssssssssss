using System.Collections.Generic;

namespace Character
{
    public enum CharacterStatId
    {
        Hp,
        Damage,
        Armor,
        MoveSpeed,
        CriticalChange,
        CriticalDamageScale,
        AttackRange,
    }

    public class BaseStat
    {
        public CharacterStatId StatId;
        private float originValue;
        private float activeValue;
        private float buffValue;

        public BaseStat(CharacterStatId statId, float originValue)
        {
            StatId = statId;
            this.originValue = originValue;
            this.activeValue = originValue;
            this.buffValue = 1f;
        }

        public void SetBuffValue(float newBuffValue)
        {
            this.buffValue = newBuffValue;
        }

        public float ActiveValue
        {
            get => activeValue * buffValue;
            set => activeValue = value;
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