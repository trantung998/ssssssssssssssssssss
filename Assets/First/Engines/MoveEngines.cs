using System.Collections;
using Svelto.Common;
using Svelto.DataStructures;
using Svelto.ECS.Extensions;

namespace First.Engines
{
    public class MoveEngines<T> : SortedEnginesGroup<IStepEngine, T> where T : struct, ISequenceOrder
    {
        public MoveEngines(FasterList<IStepEngine> engines) : base(engines)
        {
            Loop().Run();
        }

        IEnumerator Loop()
        {
            while (true)
            {
                this.Step();
                yield return null;
            }
        }
    }

    public enum MoveEngineEnum
    {
        SteeringEngine,
        MovementEngine,
    }

    public struct MoveEnginesOrder : ISequenceOrder
    {
        public string[] enginesOrder
        {
            get => new[] {nameof(MoveEngineEnum.SteeringEngine), nameof(MoveEngineEnum.MovementEngine)};
        }
    }
}