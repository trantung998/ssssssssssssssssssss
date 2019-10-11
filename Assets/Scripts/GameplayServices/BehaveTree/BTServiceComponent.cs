using Entitas;
using Entitas.CodeGeneration.Attributes;
using NPBehave;

public interface IBTService
{
    void Update(float dt);
    Blackboard GetSharedBlackboard(string key);

    Clock GetClock();
}

[Service, Unique]
public class BTServiceComponent : IComponent
{
    public IBTService instance;
}