using System.Collections;
using First.EntityStructs;
using First.EntityViews;
using Svelto.ECS;

namespace First.Engines.Character
{
    public class UpdateHealthEngine : IQueryingEntitiesEngine
    {
        public EntitiesDB entitiesDB { get; set; }

        public void Ready()
        {
            OnUpdate().Run();
        }

        private IEnumerator OnUpdate()
        {
            while (true)
            {
                var entities = entitiesDB.QueryEntities<CharacterHealthComponent, CharacterEntityViewComponents>(ECSGroups.ActiveCharacter);
                var entityHealthStructs = entities.Item1;
                var entityViewStructs = entities.Item2;
                var entityCount = entities.count;
                for (int i = 0; i < entityCount; i++)
                {
                    float hpPercent = entityHealthStructs[i].HealthValue / (float) entityHealthStructs[i].MaxHealthValue;
                    entityViewStructs[i].Health.value = hpPercent;
                }


                yield return null;
            }
        }
    }
}