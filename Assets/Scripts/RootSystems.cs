using Combat;
using GameTime;
using View;

public class RootSystems : Feature
{
    public RootSystems(Contexts contexts)
    {
        Add(new GameSystems(contexts));
    }
}

public class GameSystems : Feature
{
    public GameSystems(Contexts contexts)
    {
        Add(new UpdateTickSystem(contexts));
        Add(new CreateAssetViewSystem(contexts));
        Add(new NormalAttackProcessSystem(contexts));
    }
}