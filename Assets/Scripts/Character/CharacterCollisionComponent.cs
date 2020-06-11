using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.Analytics;

public enum CharacterCollisionType
{
    None,
    Body,
    AttackRange,
}

public enum CollisionShape
{
    Rectangle,
    Circle,
}

public class CollisionData
{
    public CharacterCollisionType type;

    //bit 0: teamId; off = 0, on = 1
    //bit 1-->30 CharacterCollisionType
    public int targetMask;
    public float range;
    public Vector2 offSet;
    public float refreshRate;
    private int hashCode;
    public float refreshTimeTracker;

    public HashSet<int> listTargetInRange;

    public CollisionData(CharacterCollisionType type, int targetMask, float range, Vector2 offSet, float refreshRate)
    {
        this.type = type;
        this.targetMask = targetMask;
        this.range = range;
        this.offSet = offSet;
        this.refreshRate = refreshRate;
        UpdateHash();
        listTargetInRange = new HashSet<int>();
    }

    private void UpdateHash()
    {
        hashCode = MurMurHash3.Hash(type, targetMask);
    }

    public override int GetHashCode()
    {
        return hashCode;
    }
}

[Game]
public class CharacterCollisionComponent : IComponent
{
    public List<CollisionData> CollisionDatas;

    public void AddCollisionData(CollisionData data)
    {
        if (!IsContainCollisionData(data)) CollisionDatas.Add(data);
    }

    private bool IsContainCollisionData(CollisionData data)
    {
        return CollisionDatas.Exists(collisionData => collisionData.GetHashCode() == data.GetHashCode());
    }
}