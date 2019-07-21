using Entitas;
using View;


public class GameplayServices
{
    public readonly IViewService ViewService;

    public GameplayServices(IViewService viewService)
    {
        ViewService = viewService;
    }
}

public class ServiceRegistrationSystems : Feature
{
    public ServiceRegistrationSystems(Contexts contexts, GameplayServices services) : base("GameplayServices")
    {
        Add(new InitViewService(contexts.service, services.ViewService));
    }

    public sealed override Entitas.Systems Add(ISystem system)
    {
        return base.Add(system);
    }
}