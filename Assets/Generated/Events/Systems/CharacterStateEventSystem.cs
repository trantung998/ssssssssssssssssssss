//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class CharacterStateEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<ICharacterStateListener> _listenerBuffer;

    public CharacterStateEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<ICharacterStateListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.CharacterState)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasCharacterState && entity.hasCharacterStateListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.characterState;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.characterStateListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnCharacterState(e, component.value);
            }
        }
    }
}