//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gameReadyEntity { get { return GetGroup(GameMatcher.GameReady).GetSingleEntity(); } }

    public bool isGameReady {
        get { return gameReadyEntity != null; }
        set {
            var entity = gameReadyEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isGameReady = true;
                } else {
                    entity.Destroy();
                }
            }
        }
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

    static readonly GameReadyComponent gameReadyComponent = new GameReadyComponent();

    public bool isGameReady {
        get { return HasComponent(GameComponentsLookup.GameReady); }
        set {
            if (value != isGameReady) {
                var index = GameComponentsLookup.GameReady;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : gameReadyComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherGameReady;

    public static Entitas.IMatcher<GameEntity> GameReady {
        get {
            if (_matcherGameReady == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameReady);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameReady = matcher;
            }

            return _matcherGameReady;
        }
    }
}