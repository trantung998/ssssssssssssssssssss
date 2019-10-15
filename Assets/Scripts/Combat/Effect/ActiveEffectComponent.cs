using System.Collections.Generic;
using Combat;
using Entitas;

[Game]
public class ActiveEffectComponent : IComponent
{
    public Dictionary<EffectId, BaseEffectData> value;

    public BaseEffectData GetEffectData(EffectId effectId)
    {
        return value.TryGetValue(effectId, out var result) ? result : null;
    }
}