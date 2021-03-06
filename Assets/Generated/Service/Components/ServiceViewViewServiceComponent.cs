//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ServiceContext {

    public ServiceEntity viewViewServiceEntity { get { return GetGroup(ServiceMatcher.ViewViewService).GetSingleEntity(); } }
    public View.ViewServiceComponent viewViewService { get { return viewViewServiceEntity.viewViewService; } }
    public bool hasViewViewService { get { return viewViewServiceEntity != null; } }

    public ServiceEntity SetViewViewService(View.IViewService newInstance) {
        if (hasViewViewService) {
            throw new Entitas.EntitasException("Could not set ViewViewService!\n" + this + " already has an entity with View.ViewServiceComponent!",
                "You should check if the context already has a viewViewServiceEntity before setting it or use context.ReplaceViewViewService().");
        }
        var entity = CreateEntity();
        entity.AddViewViewService(newInstance);
        return entity;
    }

    public void ReplaceViewViewService(View.IViewService newInstance) {
        var entity = viewViewServiceEntity;
        if (entity == null) {
            entity = SetViewViewService(newInstance);
        } else {
            entity.ReplaceViewViewService(newInstance);
        }
    }

    public void RemoveViewViewService() {
        viewViewServiceEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ServiceEntity {

    public View.ViewServiceComponent viewViewService { get { return (View.ViewServiceComponent)GetComponent(ServiceComponentsLookup.ViewViewService); } }
    public bool hasViewViewService { get { return HasComponent(ServiceComponentsLookup.ViewViewService); } }

    public void AddViewViewService(View.IViewService newInstance) {
        var index = ServiceComponentsLookup.ViewViewService;
        var component = (View.ViewServiceComponent)CreateComponent(index, typeof(View.ViewServiceComponent));
        component.instance = newInstance;
        AddComponent(index, component);
    }

    public void ReplaceViewViewService(View.IViewService newInstance) {
        var index = ServiceComponentsLookup.ViewViewService;
        var component = (View.ViewServiceComponent)CreateComponent(index, typeof(View.ViewServiceComponent));
        component.instance = newInstance;
        ReplaceComponent(index, component);
    }

    public void RemoveViewViewService() {
        RemoveComponent(ServiceComponentsLookup.ViewViewService);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class ServiceMatcher {

    static Entitas.IMatcher<ServiceEntity> _matcherViewViewService;

    public static Entitas.IMatcher<ServiceEntity> ViewViewService {
        get {
            if (_matcherViewViewService == null) {
                var matcher = (Entitas.Matcher<ServiceEntity>)Entitas.Matcher<ServiceEntity>.AllOf(ServiceComponentsLookup.ViewViewService);
                matcher.componentNames = ServiceComponentsLookup.componentNames;
                _matcherViewViewService = matcher;
            }

            return _matcherViewViewService;
        }
    }
}
