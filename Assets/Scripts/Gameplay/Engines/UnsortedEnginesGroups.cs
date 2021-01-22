using Svelto.Common;
using Svelto.DataStructures;
using Svelto.ECS;

namespace Gameplay.Engines
{
    [Sequenced(nameof(EnginesNames.UnsortedEngines))]
    public class UnsortedEnginesGroups : UnsortedEnginesGroup<IStepEngine>
    {
        public UnsortedEnginesGroups(FasterList<IStepEngine> engines) : base(engines)
        {
        }
    }
}