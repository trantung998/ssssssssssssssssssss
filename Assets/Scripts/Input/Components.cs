using Entitas;

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