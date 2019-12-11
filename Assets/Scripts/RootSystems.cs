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

        Add(new TeardownGameSystem(contexts));
    }
}

public class GameSystems : Feature
{
    public GameSystems(Contexts contexts)
    {
        Add(new BattleTimeSystem(contexts));
        Add(new BattleManaSystem(contexts));

        Add(new CreateDummyCharacterSystem(contexts));

        Add(new UpdateTickSystem(contexts));
        Add(new CreateAssetViewSystem(contexts));
        Add(new ProcessAddEffectCommand(contexts));

        Add(new GameEventSystems(contexts));

        Add(new NormalAttackProcessSystem(contexts));
        Add(new ProcessSlowEffectSystem(contexts));
        Add(new StunProcessSystem(contexts));

        Add(new UpdateCharacterViewSystem(contexts));
        Add(new ProcessMovementSystem(contexts));

        Add(new FollowCharacterSystem(contexts));
        Add(new SpawnIndicatorSystem(contexts));

        Add(new BehaviourTreeFeature(contexts));
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

public class BehaviourTreeFeature : Feature
{
    public BehaviourTreeFeature(Contexts contexts)
    {
        Add(new InitBehaviourTreeSystem(contexts));
        Add(new UpdateBehaviourTreeSystem(contexts));
    }
}