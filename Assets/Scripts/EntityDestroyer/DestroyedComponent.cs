using Entitas;


[Input, Game]
public class DestroyedComponent : IComponent
{
    public float delayTime;

    public bool IsTimeOut(float dt)
    {
        delayTime -= dt;
        return delayTime <= 0f;
    }
}