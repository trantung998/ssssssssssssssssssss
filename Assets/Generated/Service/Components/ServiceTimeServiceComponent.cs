//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ServiceContext {

    public ServiceEntity timeServiceEntity { get { return GetGroup(ServiceMatcher.TimeService).GetSingleEntity(); } }
    public TimeServiceComponent timeService { get { return timeServiceEntity.timeService; } }
    public bool hasTimeService { get { return timeServiceEntity != null; } }

    public ServiceEntity SetTimeService(ITimeService newInstance) {
        if (hasTimeService) {
            throw new Entitas.EntitasException("Could not set TimeService!\n" + this + " already has an entity with TimeServiceComponent!",
                "You should check if the context already has a timeServiceEntity before setting it or use context.ReplaceTimeService().");
        }
        var entity = CreateEntity();
        entity.AddTimeService(newInstance);
        return entity;
    }

    public void ReplaceTimeService(ITimeService newInstance) {
        var entity = timeServiceEntity;
        if (entity == null) {
            entity = SetTimeService(newInstance);
        } else {
            entity.ReplaceTimeService(newInstance);
        }
    }

    public void RemoveTimeService() {
        timeServiceEntity.Destroy();
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

    public TimeServiceComponent timeService { get { return (TimeServiceComponent)GetComponent(ServiceComponentsLookup.TimeService); } }
    public bool hasTimeService { get { return HasComponent(ServiceComponentsLookup.TimeService); } }

    public void AddTimeService(ITimeService newInstance) {
        var index = ServiceComponentsLookup.TimeService;
        var component = (TimeServiceComponent)CreateComponent(index, typeof(TimeServiceComponent));
        component.instance = newInstance;
        AddComponent(index, component);
    }

    public void ReplaceTimeService(ITimeService newInstance) {
        var index = ServiceComponentsLookup.TimeService;
        var component = (TimeServiceComponent)CreateComponent(index, typeof(TimeServiceComponent));
        component.instance = newInstance;
        ReplaceComponent(index, component);
    }

    public void RemoveTimeService() {
        RemoveComponent(ServiceComponentsLookup.TimeService);
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

    static Entitas.IMatcher<ServiceEntity> _matcherTimeService;

    public static Entitas.IMatcher<ServiceEntity> TimeService {
        get {
            if (_matcherTimeService == null) {
                var matcher = (Entitas.Matcher<ServiceEntity>)Entitas.Matcher<ServiceEntity>.AllOf(ServiceComponentsLookup.TimeService);
                matcher.componentNames = ServiceComponentsLookup.componentNames;
                _matcherTimeService = matcher;
            }

            return _matcherTimeService;
        }
    }
}
