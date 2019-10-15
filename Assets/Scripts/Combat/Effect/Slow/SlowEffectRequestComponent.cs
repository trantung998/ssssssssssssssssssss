using System.Collections.Generic;
using Combat;
using Combat.Slow;
using Entitas;


[Game]
public class SlowEffectRequestComponent : IComponent
{
    public SlowEffectData value;
}
//
//[Game]
//public class SlowEffectActiveComponent : IComponent
//{
//    public SlowEffectData value;
//}




[Game]
public class EffectDataComponent : IComponent
{
    public Dictionary<EffectId, List<BaseEffectData>> value;

    public void AddEffect(BaseEffectData effectData)
    {
        if (!value.ContainsKey(effectData.EffectId))
        {
            value.Add(effectData.EffectId, new List<BaseEffectData>());
        }

        value[effectData.EffectId].Add(effectData);
    }
}

[Game]
public class AddEffectCommandComponent : IComponent
{
    public int targetId;
    public BaseEffectData value;
}