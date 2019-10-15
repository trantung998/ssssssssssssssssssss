using Entitas;
using Entitas.CodeGeneration.Attributes;

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