using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace GameTime
{
    [Game, Unique]
    public class TickComponent : IComponent
    {
        public float value;
    }
}