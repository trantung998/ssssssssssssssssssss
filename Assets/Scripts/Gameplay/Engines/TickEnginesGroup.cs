using System;
using Svelto.DataStructures;
using Svelto.ECS;
using UnityEngine;

namespace Gameplay.Engines
{
    public class TickEnginesGroup : SortedEnginesGroup<IStepEngine, SortedTickedEnginesOrder>
    {
        public TickEnginesGroup(FasterList<IStepEngine> engines) : base(engines)
        {
            var tickingSystem = new GameObject("Ticking System");

            _tickingSystem        = tickingSystem.AddComponent<UpdateMe>();
            _tickingSystem.update = Step;
        }

        readonly UpdateMe _tickingSystem;

        class UpdateMe : MonoBehaviour
        {
            internal Action update;

            public UpdateMe(Action update) { this.update = update; }

            void Update() { update(); }
        }
    }
}