using System.Collections;
using Svelto.ECS;

namespace First.Engines.Effect
{
    //
    public class BurnHpEngine : IQueryingEntitiesEngine
    {
        public EntitiesDB entitiesDB { get; set; }

        public void Ready()
        {
        }

        private IEnumerator OnUpdate()
        {
            while (true)
            {
                yield return null;
            }
        }
    }
}