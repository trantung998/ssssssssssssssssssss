using Svelto.Common;

namespace Gameplay.Engines
{
    public enum EnginesNames
    {
        UnsortedEngines,
    }

    public struct SortedTickedEnginesOrder : ISequenceOrder
    {
        public string[] enginesOrder => new[]
        {
            nameof(EnginesNames.UnsortedEngines)
        };
    }
}