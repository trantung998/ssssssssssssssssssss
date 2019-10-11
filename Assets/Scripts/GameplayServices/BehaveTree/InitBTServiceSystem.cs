using Entitas;

public class InitBTServiceSystem : IInitializeSystem
{
    private ServiceContext _serviceContext;
    private IBTService _btService;

    public InitBTServiceSystem(Contexts contexts, IBTService service)
    {
        _serviceContext = contexts.service;
        _btService = service;
    }

    public void Initialize()
    {
        _serviceContext.ReplaceBTService(_btService);
    }
}