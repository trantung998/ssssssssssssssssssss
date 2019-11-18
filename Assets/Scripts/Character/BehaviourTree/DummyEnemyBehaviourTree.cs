using Entitas;
using NPBehave;
using UnityEngine;

public class DummyEnemyBehaviourTree : IBTController
{
    // tweak this value to control how often your tree is ticked
    public float updateFrequency = 0.1f; // 1.0f = every second

    private Clock myThrottledClock;
    private Root behaviorTree;
    private float accumulator = 0.0f;
    private Blackboard blackboard;

    private GameEntity _entity;

    public void Init(Contexts contexts, IEntity entity)
    {
        this._entity = (GameEntity) entity;
    }

    public void CreateTree()
    {
        myThrottledClock = new Clock();

        Node mainTree = new Service(0.125f,
            () => { blackboard["position"] = _entity.characterPosition.value; },
            new Selector(
                new Condition(IsOutOfBound, Stops.IMMEDIATE_RESTART,
                    new Sequence(
                        new Action(() =>
                        {
                            _entity.characterMovement.direction *= -1;
                            Debug.Log("OOOOOOOO");
                        }),
                        new WaitUntilStopped())),
                new Sequence(new Action(() => { Debug.Log("XXXXXXXXXXXX"); }), new WaitUntilStopped()))
        );

        behaviorTree = new Root(new Blackboard(myThrottledClock), myThrottledClock, mainTree);
        blackboard = behaviorTree.Blackboard;
        blackboard["left"] = Vector2.left * 5f;
        blackboard["right"] = Vector2.right * 5f;
        behaviorTree.Start();
    }

    private bool IsOutOfBound()
    {
//        Debug.Log("Check");
        var xPos = _entity.characterPosition.value.x;

        return xPos > 3f || xPos < -3f;
    }

    public void UpdateTree(float dt)
    {
        accumulator += dt;
        if (accumulator > updateFrequency)
        {
            accumulator -= updateFrequency;
            myThrottledClock.Update(updateFrequency);
        }
    }
}