using Character;
using Combat;
using EntityDestroyer;
using GameTime;
using Input;
using View;

public class RootSystems : Feature
{
    public RootSystems(Contexts contexts)
    {
        Add(new GameplayInput(contexts));
        Add(new GameSystems(contexts));

        Add(new DestroyEntitySystem(contexts));
    }
}

public class GameSystems : Feature
{
    public GameSystems(Contexts contexts)
    {
        Add(new CreateDummyCharacterSystem(contexts));

        Add(new UpdateTickSystem(contexts));
        Add(new CreateAssetViewSystem(contexts));
        Add(new NormalAttackProcessSystem(contexts));

        Add(new UpdateCharacterSystem(contexts));
        Add(new FollowCharacterSystem(contexts));
        Add(new SpawnIndicatorSystem(contexts));
    }
}

public class GameplayInput : Feature
{
    public GameplayInput(Contexts contexts)
    {
        Add(new UpdateInputSystem(contexts));
        Add(new InputProcessSystem(contexts));
    }
}