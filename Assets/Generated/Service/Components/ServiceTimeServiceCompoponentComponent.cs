//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ServiceContext {

    public ServiceEntity timeServiceCompoponentEntity { get { return GetGroup(ServiceMatcher.TimeServiceCompoponent).GetSingleEntity(); } }
    public TimeServiceCompoponent timeServiceCompoponent { get { return timeServiceCompoponentEntity.timeServiceCompoponent; } }
    public bool hasTimeServiceCompoponent { get { return timeServiceCompoponentEntity != null; } }

    public ServiceEntity SetTimeServiceCompoponent(ITimeService newInstance) {
        if (hasTimeServiceCompoponent) {
            throw new Entitas.EntitasException("Could not set TimeServiceCompoponent!\n" + this + " already has an entity with TimeServiceCompoponent!",
                "You should check if the context already has a timeServiceCompoponentEntity before setting it or use context.ReplaceTimeServiceCompoponent().");
        }
        var entity = CreateEntity();
        entity.AddTimeServiceCompoponent(newInstance);
        return entity;
    }

    public void ReplaceTimeServiceCompoponent(ITimeService newInstance) {
        var entity = timeServiceCompoponentEntity;
        if (entity == null) {
            entity = SetTimeServiceCompoponent(newInstance);
        } else {
            entity.ReplaceTimeServiceCompoponent(newInstance);
        }
    }

    public void RemoveTimeServiceCompoponent() {
        timeServiceCompoponentEntity.Destroy();
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

    public TimeServiceCompoponent timeServiceCompoponent { get { return (TimeServiceCompoponent)GetComponent(ServiceComponentsLookup.TimeServiceCompoponent); } }
    public bool hasTimeServiceCompoponent { get { return HasComponent(ServiceComponentsLookup.TimeServiceCompoponent); } }

    public void AddTimeServiceCompoponent(ITimeService newInstance) {
        var index = ServiceComponentsLookup.TimeServiceCompoponent;
        var component = (TimeServiceCompoponent)CreateComponent(index, typeof(TimeServiceCompoponent));
        component.instance = newInstance;
        AddComponent(index, component);
    }

    public void ReplaceTimeServiceCompoponent(ITimeService newInstance) {
        var index = ServiceComponentsLookup.TimeServiceCompoponent;
        var component = (TimeServiceCompoponent)CreateComponent(index, typeof(TimeServiceCompoponent));
        component.instance = newInstance;
        ReplaceComponent(index, component);
    }

    public void RemoveTimeServiceCompoponent() {
        RemoveComponent(ServiceComponentsLookup.TimeServiceCompoponent);
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

    static Entitas.IMatcher<ServiceEntity> _matcherTimeServiceCompoponent;

    public static Entitas.IMatcher<ServiceEntity> TimeServiceCompoponent {
        get {
            if (_matcherTimeServiceCompoponent == null) {
                var matcher = (Entitas.Matcher<ServiceEntity>)Entitas.Matcher<ServiceEntity>.AllOf(ServiceComponentsLookup.TimeServiceCompoponent);
                matcher.componentNames = ServiceComponentsLookup.componentNames;
                _matcherTimeServiceCompoponent = matcher;
            }

            return _matcherTimeServiceCompoponent;
        }
    }
}