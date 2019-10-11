using Entitas;


[Input, Game]
public class DelayEntityDestroyedComponent : IComponent
{
    public float delayTime;

    public bool IsTimeOut(float dt)
    {
        delayTime -= dt;
        return delayTime <= 0f;
    }
}

[Input, Game]
public class EntityDestroyedComponent : IComponent
{
}