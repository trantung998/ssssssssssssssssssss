using System.Collections;
using Gameplay.EntityComponents.PlayerEntityComponents;
using Gameplay.Services;
using Svelto.ECS;

namespace Gameplay.Engines.PlayerEngines
{
    public class PlayerInputEngine : IQueryingEntitiesEngine, IStepEngine
    {
        IEnumerator _readInput;
        private IInput _input;

        public void Ready()
        {
        }

        public EntitiesDB entitiesDB { get; set; }

        public void Step()
        {
        }

        public string name => nameof(PlayerInputEngine);


        IEnumerator ReadInput()
        {
            void IteratePlayersInput()
            {
                var (playerComponents, playersCount) = entitiesDB.QueryEntities<PlayerInputComponent>(GameGroups.UserInput);

                for (int i = 0; i < playersCount; i++)
                {
                    var h = _input.HorizontalValue;
                    var v = _input.VerticalValue;
                    
                }
            }

            while (true)
            {
                IteratePlayersInput();

                yield return null;
            }
        }
    }
}