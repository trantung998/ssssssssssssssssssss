using Entitas;
using Entitas.CodeGeneration.Attributes;

[Service, Unique]
public class TimeServiceCompoponent : IComponent
{
    public ITimeService instance;
}

public class InitTimeService : IInitializeSystem
{
    private readonly ServiceContext _serviceContext;
    private readonly ITimeService _timeService;

    public InitTimeService(Contexts contexts, ITimeService timeService)
    {
        _serviceContext = contexts.service;
        _timeService = timeService;
    }

    public void Initialize()
    {
        _serviceContext.ReplaceTimeServiceCompoponent(_timeService);
    }
}