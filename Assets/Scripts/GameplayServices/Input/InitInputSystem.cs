using Entitas;

namespace GameplayServices.Input
{
    public class InitInputSystem : IInitializeSystem
    {
        private ServiceContext _serviceContext;
        private IInputService _inputService;

        public InitInputSystem(Contexts contexts, IInputService inputService)
        {
            _serviceContext = contexts.service;
            _inputService = inputService;
        }

        public void Initialize()
        {
            _serviceContext.ReplaceGameplayServicesInputInputService(_inputService);
        }
    }
}