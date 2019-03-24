//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ConfigContext {

    public ConfigEntity roadBoundaryEntity { get { return GetGroup(ConfigMatcher.RoadBoundary).GetSingleEntity(); } }
    public RoadBoundaryComponent roadBoundary { get { return roadBoundaryEntity.roadBoundary; } }
    public bool hasRoadBoundary { get { return roadBoundaryEntity != null; } }

    public ConfigEntity SetRoadBoundary(float newLeft, float newRight) {
        if (hasRoadBoundary) {
            throw new Entitas.EntitasException("Could not set RoadBoundary!\n" + this + " already has an entity with RoadBoundaryComponent!",
                "You should check if the context already has a roadBoundaryEntity before setting it or use context.ReplaceRoadBoundary().");
        }
        var entity = CreateEntity();
        entity.AddRoadBoundary(newLeft, newRight);
        return entity;
    }

    public void ReplaceRoadBoundary(float newLeft, float newRight) {
        var entity = roadBoundaryEntity;
        if (entity == null) {
            entity = SetRoadBoundary(newLeft, newRight);
        } else {
            entity.ReplaceRoadBoundary(newLeft, newRight);
        }
    }

    public void RemoveRoadBoundary() {
        roadBoundaryEntity.Destroy();
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
public partial class ConfigEntity {

    public RoadBoundaryComponent roadBoundary { get { return (RoadBoundaryComponent)GetComponent(ConfigComponentsLookup.RoadBoundary); } }
    public bool hasRoadBoundary { get { return HasComponent(ConfigComponentsLookup.RoadBoundary); } }

    public void AddRoadBoundary(float newLeft, float newRight) {
        var index = ConfigComponentsLookup.RoadBoundary;
        var component = (RoadBoundaryComponent)CreateComponent(index, typeof(RoadBoundaryComponent));
        component.left = newLeft;
        component.right = newRight;
        AddComponent(index, component);
    }

    public void ReplaceRoadBoundary(float newLeft, float newRight) {
        var index = ConfigComponentsLookup.RoadBoundary;
        var component = (RoadBoundaryComponent)CreateComponent(index, typeof(RoadBoundaryComponent));
        component.left = newLeft;
        component.right = newRight;
        ReplaceComponent(index, component);
    }

    public void RemoveRoadBoundary() {
        RemoveComponent(ConfigComponentsLookup.RoadBoundary);
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
public sealed partial class ConfigMatcher {

    static Entitas.IMatcher<ConfigEntity> _matcherRoadBoundary;

    public static Entitas.IMatcher<ConfigEntity> RoadBoundary {
        get {
            if (_matcherRoadBoundary == null) {
                var matcher = (Entitas.Matcher<ConfigEntity>)Entitas.Matcher<ConfigEntity>.AllOf(ConfigComponentsLookup.RoadBoundary);
                matcher.componentNames = ConfigComponentsLookup.componentNames;
                _matcherRoadBoundary = matcher;
            }

            return _matcherRoadBoundary;
        }
    }
}