using Entitas;
using GameplayServices.Input;

namespace Input
{
    public class UpdateInputSystem : IExecuteSystem
    {
        private readonly IInputService _inputService;

        public UpdateInputSystem(Contexts contexts)
        {
            _inputService = contexts.service.gameplayServicesInputInputService.instance;
        }

        public void Execute()
        {
            _inputService.OnUpdate();
        }
    }
}