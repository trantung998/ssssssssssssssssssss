using Entitas;
using View;

public class InitViewService : IInitializeSystem
{
    private ServiceContext _serviceContext;
    private IViewService _viewService;

    public InitViewService(ServiceContext serviceContext, IViewService instance)
    {
        _serviceContext = serviceContext;
        _viewService = instance;
    }

    public void Initialize()
    {
        _serviceContext.ReplaceViewViewService(_viewService);
    }
}