//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ConfigContext {

    public ConfigEntity runPlayerPositionEntity { get { return GetGroup(ConfigMatcher.RunPlayerPosition).GetSingleEntity(); } }
    public RunPlayerPositionComponent runPlayerPosition { get { return runPlayerPositionEntity.runPlayerPosition; } }
    public bool hasRunPlayerPosition { get { return runPlayerPositionEntity != null; } }

    public ConfigEntity SetRunPlayerPosition(UnityEngine.Vector2 newValue) {
        if (hasRunPlayerPosition) {
            throw new Entitas.EntitasException("Could not set RunPlayerPosition!\n" + this + " already has an entity with RunPlayerPositionComponent!",
                "You should check if the context already has a runPlayerPositionEntity before setting it or use context.ReplaceRunPlayerPosition().");
        }
        var entity = CreateEntity();
        entity.AddRunPlayerPosition(newValue);
        return entity;
    }

    public void ReplaceRunPlayerPosition(UnityEngine.Vector2 newValue) {
        var entity = runPlayerPositionEntity;
        if (entity == null) {
            entity = SetRunPlayerPosition(newValue);
        } else {
            entity.ReplaceRunPlayerPosition(newValue);
        }
    }

    public void RemoveRunPlayerPosition() {
        runPlayerPositionEntity.Destroy();
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

    public RunPlayerPositionComponent runPlayerPosition { get { return (RunPlayerPositionComponent)GetComponent(ConfigComponentsLookup.RunPlayerPosition); } }
    public bool hasRunPlayerPosition { get { return HasComponent(ConfigComponentsLookup.RunPlayerPosition); } }

    public void AddRunPlayerPosition(UnityEngine.Vector2 newValue) {
        var index = ConfigComponentsLookup.RunPlayerPosition;
        var component = (RunPlayerPositionComponent)CreateComponent(index, typeof(RunPlayerPositionComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceRunPlayerPosition(UnityEngine.Vector2 newValue) {
        var index = ConfigComponentsLookup.RunPlayerPosition;
        var component = (RunPlayerPositionComponent)CreateComponent(index, typeof(RunPlayerPositionComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveRunPlayerPosition() {
        RemoveComponent(ConfigComponentsLookup.RunPlayerPosition);
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

    static Entitas.IMatcher<ConfigEntity> _matcherRunPlayerPosition;

    public static Entitas.IMatcher<ConfigEntity> RunPlayerPosition {
        get {
            if (_matcherRunPlayerPosition == null) {
                var matcher = (Entitas.Matcher<ConfigEntity>)Entitas.Matcher<ConfigEntity>.AllOf(ConfigComponentsLookup.RunPlayerPosition);
                matcher.componentNames = ConfigComponentsLookup.componentNames;
                _matcherRunPlayerPosition = matcher;
            }

            return _matcherRunPlayerPosition;
        }
    }
}
