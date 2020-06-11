using Entitas;
using NPBehave;
using UnityEngine;
using Random = UnityEngine.Random;

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

        Node mainTree = new Service(
            () =>
            {
                blackboard["position"] = _entity.characterPosition.value;
            },
            new Selector(new Condition(TestStopSelf, Stops.SELF, new Action(() => { Debug.Log("Node 1"); })),
                new Action(() => { Debug.Log("Node 2"); })) /*,
            new Selector(
                new Condition(IsOutOfBound, Stops.IMMEDIATE_RESTART,
                    new Sequence(
                        new Action(() =>
                        {
                            _entity.characterMovement.direction *= -1;
                            Debug.Log("OOOOOOOO");
                        }),
                        new WaitUntilStopped())),
                new Sequence(new Action(() => { Debug.Log("XXXXXXXXXXXX"); }), new WaitUntilStopped()))*/
        );

        behaviorTree = new Root(new Blackboard(myThrottledClock), myThrottledClock, mainTree);
        blackboard = behaviorTree.Blackboard;
        blackboard["left"] = Vector2.left * 5f;
        blackboard["right"] = Vector2.right * 5f;
        behaviorTree.Start();
    }

    private bool TestStopSelf()
    {
        var random = Random.Range(0, 100);
        return random > 20;
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