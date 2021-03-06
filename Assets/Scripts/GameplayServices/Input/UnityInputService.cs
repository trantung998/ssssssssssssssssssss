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
                    sourceId = 1,
                    targetId = 2,
                });
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Key SSSSSSSS");
                var consumeMamanaEntity = _inputContext.CreateEntity();
                consumeMamanaEntity.AddConsumeManaCommand(0, -5);
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Input Spawn Character team 0");

                var consumeMamanaEntity = _inputContext.CreateEntity();
                consumeMamanaEntity.AddSpawnCharacter(new SpawnCharacterData(CharacterType.Creep, new Vector2(-2, 0), 0,
                    1));
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Input Spawn Character team 1");

                var consumeMamanaEntity = _inputContext.CreateEntity();
                consumeMamanaEntity.AddSpawnCharacter(new SpawnCharacterData(CharacterType.Creep, new Vector2(2, 0), 1,
                    1));
            }
        }
    }
}