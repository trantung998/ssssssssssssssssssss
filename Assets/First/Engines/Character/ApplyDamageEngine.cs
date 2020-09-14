using System;
using System.Collections;
using First.EntityStructs;
using Svelto.ECS;

namespace First.Engines.Character
{
    public class ApplyDamageEngine : IQueryingEntitiesEngine
    {
        public EntitiesDB entitiesDB { get; set; }

        public void Ready()
        {
            OnUpdate().Run();
        }

        IEnumerator OnUpdate()
        {
            while (true)
            {
                var damagedEntities = entitiesDB.QueryEntities<CharacterHealthComponent, DamageableEntityStruct>(ECSGroups.ActiveCharacter);
                var healthStructs = damagedEntities.Item1;
                var damageStructs = damagedEntities.Item2;


                uint entityCount = damagedEntities.count;

                for (int i = 0; i < entityCount; i++)
                {
                    if (!damageStructs[i].IsProcessed && damageStructs[i].Damage.DamageToApply > 0)
                    {
                        healthStructs[i].HealthValue -= damageStructs[i].Damage.DamageToApply;

                        damageStructs[i].IsProcessed = true;
                        damageStructs[i].Damage.DamageToApply = 0;
                    }
                }

                yield return null;
            }
        }
    }
}