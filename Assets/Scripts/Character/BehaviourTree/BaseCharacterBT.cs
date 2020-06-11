using System;
using System.Linq;
using Character;
using Entitas;
using NPBehave;
using UnityEngine;
using Action = NPBehave.Action;

public class BaseCharacterBT : IBTController
{
    public float updateFrequency = 0.1f;

    private Clock myThrottledClock;
    private Root behaviorTree;
    private float accumulator = 0.0f;
    private Blackboard blackboard;

    private GameEntity _entity;
    private GameContext _gameContext;

    public void Init(Contexts contexts, IEntity entity)
    {
        this._entity = (GameEntity) entity;
        _gameContext = contexts.game;
    }

    public void CreateTree()
    {
        myThrottledClock = new Clock();
        Node mainTree = new Service(1.0f, UpdateService,
            new Selector(
                new Condition(IsAlive, Stops.SELF,
                    new Selector(new Condition(HasEnemyInAttackRange, Stops.SELF,
                            new Action(() => { Debug.Log("Has enemy inrange, attackkkkkkkkkkk!"); })),
                        new Action(() => { Debug.Log("Keep Patrol boy!"); })))
                , new Sequence(
                    new Action(() => { Debug.Log("Chet cmr charId: " + _entity.characterCharacterMetaData.id); }))));


        behaviorTree = new Root(new Blackboard(myThrottledClock), myThrottledClock, mainTree);
        blackboard = behaviorTree.Blackboard;
        InitCharacterData();

        behaviorTree.Start();
    }

//    private Node FindTarget()
//    {
//        return new 
//    }

    private void UpdateService()
    {
        Debug.Log("ServiceUpdate");
    }

    private void InitCharacterData()
    {
        //khởi tạo 
        blackboard["State"] = _entity.characterState.value;
        blackboard["MoveDir"] = _entity.characterMovement.direction;
    }

    protected virtual float GetCharacterStat(CharacterStatId characterStatId)
    {
        var statHashSet = _gameContext.GetEntitiesWithCharacterCharacterStats(_entity.characterCharacterMetaData.id);
        if (statHashSet != null)
        {
            var statEntity = statHashSet.FirstOrDefault();
            if (statEntity != null)
            {
                var attackRange = statEntity.characterCharacterStats.GetStat(characterStatId);
                if (attackRange != null)
                {
                    return attackRange.ActiveValue;
                }
            }
        }

        return 0f;
    }

    private bool HasEnemyInAttackRange()
    {
//        var attackRange = GetCharacterStat(CharacterStatId.AttackRange);
        return false;
    }

    private bool IsAlive()
    {
        var hp = GetCharacterStat(CharacterStatId.Hp);
        return hp > 0;
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