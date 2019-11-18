using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;
using Combat;

namespace Combat
{
    [Game]
    public class EffectStatusComponent : IComponent
    {
        public int value;
    }
}

[Game, Event(EventTarget.Self)]
public class EffectDataChangedComponent : IComponent
{
}

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

[Game]
public class ActiveEffectComponent : IComponent
{
    public Dictionary<EffectId, BaseEffectData> value;

    public BaseEffectData GetEffectData(EffectId effectId)
    {
        return value.TryGetValue(effectId, out var result) ? result : null;
    }
}