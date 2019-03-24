//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity floorDataEntity { get { return GetGroup(GameMatcher.FloorData).GetSingleEntity(); } }
    public FloorDataComponent floorData { get { return floorDataEntity.floorData; } }
    public bool hasFloorData { get { return floorDataEntity != null; } }

    public GameEntity SetFloorData(float newFloorWidth, float newFloorHeight, UnityEngine.Vector3 newFirstPos) {
        if (hasFloorData) {
            throw new Entitas.EntitasException("Could not set FloorData!\n" + this + " already has an entity with FloorDataComponent!",
                "You should check if the context already has a floorDataEntity before setting it or use context.ReplaceFloorData().");
        }
        var entity = CreateEntity();
        entity.AddFloorData(newFloorWidth, newFloorHeight, newFirstPos);
        return entity;
    }

    public void ReplaceFloorData(float newFloorWidth, float newFloorHeight, UnityEngine.Vector3 newFirstPos) {
        var entity = floorDataEntity;
        if (entity == null) {
            entity = SetFloorData(newFloorWidth, newFloorHeight, newFirstPos);
        } else {
            entity.ReplaceFloorData(newFloorWidth, newFloorHeight, newFirstPos);
        }
    }

    public void RemoveFloorData() {
        floorDataEntity.Destroy();
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

    public FloorDataComponent floorData { get { return (FloorDataComponent)GetComponent(GameComponentsLookup.FloorData); } }
    public bool hasFloorData { get { return HasComponent(GameComponentsLookup.FloorData); } }

    public void AddFloorData(float newFloorWidth, float newFloorHeight, UnityEngine.Vector3 newFirstPos) {
        var index = GameComponentsLookup.FloorData;
        var component = (FloorDataComponent)CreateComponent(index, typeof(FloorDataComponent));
        component.floorWidth = newFloorWidth;
        component.floorHeight = newFloorHeight;
        component.firstPos = newFirstPos;
        AddComponent(index, component);
    }

    public void ReplaceFloorData(float newFloorWidth, float newFloorHeight, UnityEngine.Vector3 newFirstPos) {
        var index = GameComponentsLookup.FloorData;
        var component = (FloorDataComponent)CreateComponent(index, typeof(FloorDataComponent));
        component.floorWidth = newFloorWidth;
        component.floorHeight = newFloorHeight;
        component.firstPos = newFirstPos;
        ReplaceComponent(index, component);
    }

    public void RemoveFloorData() {
        RemoveComponent(GameComponentsLookup.FloorData);
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

    static Entitas.IMatcher<GameEntity> _matcherFloorData;

    public static Entitas.IMatcher<GameEntity> FloorData {
        get {
            if (_matcherFloorData == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FloorData);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFloorData = matcher;
            }

            return _matcherFloorData;
        }
    }
}