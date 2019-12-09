using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

public class ManaData
{
    public float maxValue;
    public float currnetValue;
}

[Game, Unique]
public class ManaComponent : IComponent
{
    public List<ManaData> manaDatas;

    public bool IsManaValueEnoughToUse(int teamId, float checkValue)
    {
        var result = manaDatas[teamId].currnetValue + checkValue;
        return result >= 0;
    }

    public void ChangeManaValue(int teamId, float value)
    {
        manaDatas[teamId].currnetValue += value;

        if (manaDatas[teamId].currnetValue >= manaDatas[teamId].maxValue)
            manaDatas[teamId].currnetValue = manaDatas[teamId].maxValue;

        if (manaDatas[teamId].currnetValue <= 0)
            manaDatas[teamId].currnetValue = 0;
    }

    public void InitData(float maxMana, float currentMana)
    {
        manaDatas[0].currnetValue = currentMana;
        manaDatas[0].maxValue = maxMana;

        manaDatas[1].currnetValue = currentMana;
        manaDatas[1].maxValue = maxMana;
    }

    public float GetManaPercent(int teamId)
    {
        return manaDatas[teamId].currnetValue / manaDatas[teamId].maxValue;
    }
}

[Input]
public class ConsumeManaCommand : IComponent
{
    public int teamId;
    public int value;
}