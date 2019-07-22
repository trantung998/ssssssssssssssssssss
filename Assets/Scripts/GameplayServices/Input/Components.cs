using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace GameplayServices.Input
{
    public interface IInputService
    {
        void TriggerTestNormalAttack();
        void OnUpdate();
    }

    [Service, Unique]
    public class InputServiceComponent : IComponent
    {
        public IInputService instance;
    }
}