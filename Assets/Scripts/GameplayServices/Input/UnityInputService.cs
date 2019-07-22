using UnityEngine;

namespace GameplayServices.Input
{
    public class UnityInputService : IInputService
    {
        private InputContext _inputContext;

        public UnityInputService(Contexts contexts)
        {
            _inputContext = contexts.input;
        }


        public void TriggerTestNormalAttack()
        {
        }

        public void OnUpdate()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Key A Pressssssssssssed");
                var inputEntity = _inputContext.CreateEntity();
                inputEntity.AddInputData(new TestNormalAttackInput()
                {
                    Type = InputType.TestNormalAttack,
                    sourceId = 0,
                    targetId = 1,
                });
            }
        }
    }
}