using Entitas;

public class InitRandomService : IInitializeSystem
{
    private readonly IRandomService _randomService;
    private readonly ServiceContext _serviceContext;

    public InitRandomService(Contexts contexts, IRandomService randomService)
    {
        _randomService = randomService;
        _serviceContext = contexts.service;
    }

    public void Initialize()
    {
        _serviceContext.ReplaceRandomService(_randomService);
    }
}