using Entitas;
using UnityEngine;

public enum InputType
{
    TestNormalAttack
}

public class InputData
{
    public InputType Type;
}

public class TestNormalAttackInput : InputData
{
    public int sourceId;
    public int targetId;
}

[Input]
public class InputDataComponent : IComponent
{
    public InputData value;
}

/// <summary>
/// Spawn character components
/// </summary>
public class SpawnCharacterData
{
    public CharacterType Type;
    public Vector2 Position;
    public int teamId;
    public int level;
    public int id;

    public SpawnCharacterData(CharacterType type, Vector2 position, int teamId, int level)
    {
        Type = type;
        Position = position;
        this.teamId = teamId;
        this.level = level;
    }
}

[Input]
public class SpawnCharacterComponent : IComponent
{
    public SpawnCharacterData value;
}