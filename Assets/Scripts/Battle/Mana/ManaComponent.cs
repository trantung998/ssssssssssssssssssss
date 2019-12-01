using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

public class ManaData
{
    public float currnetValue;
}

[Game, Unique]
public class ManaComponent : IComponent
{
    public List<ManaData> manaDatas;

    public void ChangeManaValue(int teamId, float value)
    {
        manaDatas[teamId].currnetValue += value;
    }
}

[Game]
public class ConsumeManaCommand : IComponent
{
    public int teamId;
    public int value;
}