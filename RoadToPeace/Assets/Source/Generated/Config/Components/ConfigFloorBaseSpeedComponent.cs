//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ConfigContext {

    public ConfigEntity floorBaseSpeedEntity { get { return GetGroup(ConfigMatcher.FloorBaseSpeed).GetSingleEntity(); } }
    public FloorBaseSpeedComponent floorBaseSpeed { get { return floorBaseSpeedEntity.floorBaseSpeed; } }
    public bool hasFloorBaseSpeed { get { return floorBaseSpeedEntity != null; } }

    public ConfigEntity SetFloorBaseSpeed(float newValue) {
        if (hasFloorBaseSpeed) {
            throw new Entitas.EntitasException("Could not set FloorBaseSpeed!\n" + this + " already has an entity with FloorBaseSpeedComponent!",
                "You should check if the context already has a floorBaseSpeedEntity before setting it or use context.ReplaceFloorBaseSpeed().");
        }
        var entity = CreateEntity();
        entity.AddFloorBaseSpeed(newValue);
        return entity;
    }

    public void ReplaceFloorBaseSpeed(float newValue) {
        var entity = floorBaseSpeedEntity;
        if (entity == null) {
            entity = SetFloorBaseSpeed(newValue);
        } else {
            entity.ReplaceFloorBaseSpeed(newValue);
        }
    }

    public void RemoveFloorBaseSpeed() {
        floorBaseSpeedEntity.Destroy();
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

    public FloorBaseSpeedComponent floorBaseSpeed { get { return (FloorBaseSpeedComponent)GetComponent(ConfigComponentsLookup.FloorBaseSpeed); } }
    public bool hasFloorBaseSpeed { get { return HasComponent(ConfigComponentsLookup.FloorBaseSpeed); } }

    public void AddFloorBaseSpeed(float newValue) {
        var index = ConfigComponentsLookup.FloorBaseSpeed;
        var component = (FloorBaseSpeedComponent)CreateComponent(index, typeof(FloorBaseSpeedComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceFloorBaseSpeed(float newValue) {
        var index = ConfigComponentsLookup.FloorBaseSpeed;
        var component = (FloorBaseSpeedComponent)CreateComponent(index, typeof(FloorBaseSpeedComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveFloorBaseSpeed() {
        RemoveComponent(ConfigComponentsLookup.FloorBaseSpeed);
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

    static Entitas.IMatcher<ConfigEntity> _matcherFloorBaseSpeed;

    public static Entitas.IMatcher<ConfigEntity> FloorBaseSpeed {
        get {
            if (_matcherFloorBaseSpeed == null) {
                var matcher = (Entitas.Matcher<ConfigEntity>)Entitas.Matcher<ConfigEntity>.AllOf(ConfigComponentsLookup.FloorBaseSpeed);
                matcher.componentNames = ConfigComponentsLookup.componentNames;
                _matcherFloorBaseSpeed = matcher;
            }

            return _matcherFloorBaseSpeed;
        }
    }
}