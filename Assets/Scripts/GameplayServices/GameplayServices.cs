using Entitas;
using GameplayServices.Input;
using View;

namespace GameplayServices
{
    public class GameplayServices
    {
        public IViewService ViewService;
        public IInputService InputService;
        public IRandomService RandomService;
        public ITimeService TimeService;
    }

    public class ServiceRegistrationSystems : Feature
    {
        public ServiceRegistrationSystems(Contexts contexts, GameplayServices services) : base("GameplayServices")
        {
            Add(new InitViewService(contexts.service, services.ViewService));
            Add(new InitInputSystem(contexts, services.InputService));
            Add(new InitRandomService(contexts, services.RandomService));
            Add(new InitTimeService(contexts, services.TimeService));
        }

        public sealed override Entitas.Systems Add(ISystem system)
        {
            return base.Add(system);
        }
    }
}