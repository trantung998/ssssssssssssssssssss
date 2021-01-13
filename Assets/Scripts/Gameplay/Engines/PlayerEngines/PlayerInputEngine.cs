using System.Collections;
using Gameplay.EntityComponents.PlayerEntityComponents;
using Gameplay.EntityDescriptors.PlayerEntityDescriptors;
using Gameplay.Services;
using Svelto.ECS;
using Svelto.ECS.Schedulers.Unity;

namespace Gameplay.Engines.PlayerEngines
{
    public class PlayerInputEngine : IQueryingEntitiesEngine, IStepEngine
    {
        IEnumerator _readInput;
        private IInput _input;
        private IEntityFactory m_entityFactory;
        private UnityEntitiesSubmissionScheduler m_submissionScheduler;

        public void Ready()
        {
            var initializer = m_entityFactory.BuildEntity<PlayerInputDescriptor>(0, GameGroups.UserInputGroup.BuildGroup);
        }

        public EntitiesDB entitiesDB { get; set; }

        public void Step()
        {
        }

        public string name => nameof(PlayerInputEngine);


        void SetDataInput()
        {
            foreach (var ((userInputs, count), @group) in entitiesDB.QueryEntities<PlayerInputComponent>(GameGroups.UserInputGroup.Groups))
            {
                for (int i = 0; i < count; i++)
                {
                    userInputs[i].HorizontalValue = _input.HorizontalValue;
                    userInputs[i].VerticalValue = _input.VerticalValue;
                    userInputs[i].isSpawnCharacter = _input.IsSpawnCharacter;
                }
            }
        }

        IEnumerator ReadInput()
        {
            while (true)
            {
                // IteratePlayersInput(userInputGroup);

                yield return null;
            }
        }
    }
}