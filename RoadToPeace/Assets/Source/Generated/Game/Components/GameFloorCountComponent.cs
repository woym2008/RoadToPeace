//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity floorCountEntity { get { return GetGroup(GameMatcher.FloorCount).GetSingleEntity(); } }
    public FloorCountComponent floorCount { get { return floorCountEntity.floorCount; } }
    public bool hasFloorCount { get { return floorCountEntity != null; } }

    public GameEntity SetFloorCount(int newValue) {
        if (hasFloorCount) {
            throw new Entitas.EntitasException("Could not set FloorCount!\n" + this + " already has an entity with FloorCountComponent!",
                "You should check if the context already has a floorCountEntity before setting it or use context.ReplaceFloorCount().");
        }
        var entity = CreateEntity();
        entity.AddFloorCount(newValue);
        return entity;
    }

    public void ReplaceFloorCount(int newValue) {
        var entity = floorCountEntity;
        if (entity == null) {
            entity = SetFloorCount(newValue);
        } else {
            entity.ReplaceFloorCount(newValue);
        }
    }

    public void RemoveFloorCount() {
        floorCountEntity.Destroy();
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
public partial class GameEntity {

    public FloorCountComponent floorCount { get { return (FloorCountComponent)GetComponent(GameComponentsLookup.FloorCount); } }
    public bool hasFloorCount { get { return HasComponent(GameComponentsLookup.FloorCount); } }

    public void AddFloorCount(int newValue) {
        var index = GameComponentsLookup.FloorCount;
        var component = (FloorCountComponent)CreateComponent(index, typeof(FloorCountComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceFloorCount(int newValue) {
        var index = GameComponentsLookup.FloorCount;
        var component = (FloorCountComponent)CreateComponent(index, typeof(FloorCountComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveFloorCount() {
        RemoveComponent(GameComponentsLookup.FloorCount);
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
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherFloorCount;

    public static Entitas.IMatcher<GameEntity> FloorCount {
        get {
            if (_matcherFloorCount == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FloorCount);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFloorCount = matcher;
            }

            return _matcherFloorCount;
        }
    }
}
