//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public FloorDifficultyComponent floorDifficulty { get { return (FloorDifficultyComponent)GetComponent(GameComponentsLookup.FloorDifficulty); } }
    public bool hasFloorDifficulty { get { return HasComponent(GameComponentsLookup.FloorDifficulty); } }

    public void AddFloorDifficulty(int newValue) {
        var index = GameComponentsLookup.FloorDifficulty;
        var component = (FloorDifficultyComponent)CreateComponent(index, typeof(FloorDifficultyComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceFloorDifficulty(int newValue) {
        var index = GameComponentsLookup.FloorDifficulty;
        var component = (FloorDifficultyComponent)CreateComponent(index, typeof(FloorDifficultyComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveFloorDifficulty() {
        RemoveComponent(GameComponentsLookup.FloorDifficulty);
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

    static Entitas.IMatcher<GameEntity> _matcherFloorDifficulty;

    public static Entitas.IMatcher<GameEntity> FloorDifficulty {
        get {
            if (_matcherFloorDifficulty == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.FloorDifficulty);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherFloorDifficulty = matcher;
            }

            return _matcherFloorDifficulty;
        }
    }
}