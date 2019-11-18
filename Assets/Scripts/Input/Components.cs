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
}

[Input]
public class SpawnCharacterComponent : IComponent
{
    public SpawnCharacterData value;
}