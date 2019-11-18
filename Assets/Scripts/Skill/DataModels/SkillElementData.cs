using System;

public enum SkillElementId
{
    CoolDown,
    Damage,
    DamageOverTime,
    Stun,
    MoveSpeed,
}

public enum SkillElementValueType
{
    Normal,
    Percent,
}

[Serializable]
public class SkillElementData
{
    public SkillElementId id;
    public SkillElementValueType ValueType;
    
    public float value;
}