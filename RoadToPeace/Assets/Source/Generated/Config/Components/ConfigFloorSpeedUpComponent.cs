//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ConfigContext {

    public ConfigEntity floorSpeedUpEntity { get { return GetGroup(ConfigMatcher.FloorSpeedUp).GetSingleEntity(); } }
    public FloorSpeedUpComponent floorSpeedUp { get { return floorSpeedUpEntity.floorSpeedUp; } }
    public bool hasFloorSpeedUp { get { return floorSpeedUpEntity != null; } }

    public ConfigEntity SetFloorSpeedUp(float newValue) {
        if (hasFloorSpeedUp) {
            throw new Entitas.EntitasException("Could not set FloorSpeedUp!\n" + this + " already has an entity with FloorSpeedUpComponent!",
                "You should check if the context already has a floorSpeedUpEntity before setting it or use context.ReplaceFloorSpeedUp().");
        }
        var entity = CreateEntity();
        entity.AddFloorSpeedUp(newValue);
        return entity;
    }

    public void ReplaceFloorSpeedUp(float newValue) {
        var entity = floorSpeedUpEntity;
        if (entity == null) {
            entity = SetFloorSpeedUp(newValue);
        } else {
            entity.ReplaceFloorSpeedUp(newValue);
        }
    }

    public void RemoveFloorSpeedUp() {
        floorSpeedUpEntity.Destroy();
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

    public FloorSpeedUpComponent floorSpeedUp { get { return (FloorSpeedUpComponent)GetComponent(ConfigComponentsLookup.FloorSpeedUp); } }
    public bool hasFloorSpeedUp { get { return HasComponent(ConfigComponentsLookup.FloorSpeedUp); } }

    public void AddFloorSpeedUp(float newValue) {
        var index = ConfigComponentsLookup.FloorSpeedUp;
        var component = (FloorSpeedUpComponent)CreateComponent(index, typeof(FloorSpeedUpComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceFloorSpeedUp(float newValue) {
        var index = ConfigComponentsLookup.FloorSpeedUp;
        var component = (FloorSpeedUpComponent)CreateComponent(index, typeof(FloorSpeedUpComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveFloorSpeedUp() {
        RemoveComponent(ConfigComponentsLookup.FloorSpeedUp);
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

    static Entitas.IMatcher<ConfigEntity> _matcherFloorSpeedUp;

    public static Entitas.IMatcher<ConfigEntity> FloorSpeedUp {
        get {
            if (_matcherFloorSpeedUp == null) {
                var matcher = (Entitas.Matcher<ConfigEntity>)Entitas.Matcher<ConfigEntity>.AllOf(ConfigComponentsLookup.FloorSpeedUp);
                matcher.componentNames = ConfigComponentsLookup.componentNames;
                _matcherFloorSpeedUp = matcher;
            }

            return _matcherFloorSpeedUp;
        }
    }
}