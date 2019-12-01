using Entitas;
using Entitas.CodeGeneration.Attributes;

public class BattleTimeData
{
    public int maxTimeInSeconds;
    public float currnetTimeInSeconds;
}

[Game, Unique]
public class BattleTimeComponent : IComponent
{
    public BattleTimeData value;
}

[Game, Unique, Event(EventTarget.Any)]
public class UpdateBattleTimeComponent : IComponent
{
    public float timeValue;
}