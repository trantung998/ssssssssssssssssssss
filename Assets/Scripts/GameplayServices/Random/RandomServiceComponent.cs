using Entitas;
using Entitas.CodeGeneration.Attributes;

[Service, Unique]
public class RandomServiceComponent : IComponent
{
    public IRandomService instance;
}