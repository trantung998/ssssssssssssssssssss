using System.Collections.Generic;
using Entitas;

public class SpawnCharacterSystem : IExecuteSystem
{
    private long[] characterIds;

    private int maxUnitPerTeam = 64;

    public SpawnCharacterSystem(Contexts contexts)
    {
        characterIds = new[] {0L, 0L};
    }

    public void Execute()
    {
    }

    private int GetNewId(int teamId)
    {
        int rtn = 0;
        for (int i = 0; i < maxUnitPerTeam; i++)
        {
        }

        return rtn;
    }
}