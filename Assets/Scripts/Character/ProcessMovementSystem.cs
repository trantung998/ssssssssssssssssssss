using Entitas;
using UnityEngine;

namespace Character
{
    public class ProcessMovementSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _movementEntityGroup;
        private ITimeService _timeService;

        public ProcessMovementSystem(Contexts contexts)
        {
            _movementEntityGroup =
                contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.CharacterPosition, GameMatcher.CharacterMovement));
            _timeService = contexts.service.timeServiceCompoponent.instance;
        }

        public void Execute()
        {
            foreach (var entity in _movementEntityGroup.GetEntities())
            {
                var position = entity.characterPosition.value;
                var speed = entity.characterMovement.speed;
                if (speed > 0)
                {
                    var dir = entity.characterMovement.direction;

                    position += speed * _timeService.DeltaTime * (Vector3) dir;

                    entity.ReplaceCharacterPosition(position);
                }
            }
        }
    }
}