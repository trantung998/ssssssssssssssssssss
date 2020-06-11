using Entitas;
using UnityEngine;

public class UpdateCollisionSystem : IExecuteSystem
{
    private IGroup<GameEntity> allCharacterGroup;


    public void Execute()
    {
        var allCharacterEntities = allCharacterGroup.GetEntities();
        foreach (var gameEntity in allCharacterEntities)
        {
            var collisionDatas = gameEntity.characterCollision.CollisionDatas;
            for (var i = collisionDatas.Count - 1; i >= 0; i--)
            {
                if (collisionDatas[i].refreshTimeTracker >= collisionDatas[i].refreshRate)
                {
                }
            }
        }
    }

    private void UpdateCollisionData(CollisionData collisionData, Vector2 centerPosition)
    {
        var targetTeamId = BitHelper.IsBitOn(collisionData.targetMask, 0) ? 1 : 0;

        var allCharacterEntities = allCharacterGroup.GetEntities();
        foreach (var targetEntity in allCharacterEntities)
        {
            if (targetEntity.characterCharacterMetaData.value.teamId == targetTeamId)
            {
                var targetCollisions = targetEntity.characterCollision.CollisionDatas;
                for (var i = 0; i < targetCollisions.Count; i++)
                {
                    if (BitHelper.IsBitOn(collisionData.targetMask, (int) targetCollisions[i].type))
                    {
                        var targetPos = (Vector2) targetEntity.characterPosition.value;
                        
                    }
                }
            }
        }
    }
}