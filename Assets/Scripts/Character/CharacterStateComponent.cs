using Entitas;
using Entitas.CodeGeneration.Attributes;

public class CharacterStateData
{
    public CharacterState prevState;
    public CharacterState currentState;
}

[Game, Event(EventTarget.Self)]
public class CharacterStateComponent : IComponent
{
    public CharacterStateData value;
}