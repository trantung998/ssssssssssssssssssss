using System.Collections;
using First.EntityStructs;
using Svelto.ECS;

namespace First.Engines.Character
{
    public class CharacterDeathEngine : IQueryingEntitiesEngine
    {
        public EntitiesDB entitiesDB { get; set; }

        public void Ready()
        {
            OnUpdate().Run();
        }

        IEnumerator OnUpdate()
        {
            void CheckHealth()
            {
                var (healths, entityCount) = entitiesDB.QueryEntities<CharacterHealthComponent>(ECSGroups.ActiveCharacter);
                for (int i = 0; i < entityCount; i++)
                {
                    if (healths[i].HealthValue <= 0)
                    {
                        healths[i].IsDeath = true;
                    }
                }
            }

            while (true)
            {
                CheckHealth();
                yield return null;
            }
        }
    }
}