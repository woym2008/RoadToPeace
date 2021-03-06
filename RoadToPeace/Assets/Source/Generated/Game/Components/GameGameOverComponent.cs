//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity gameOverEntity { get { return GetGroup(GameMatcher.GameOver).GetSingleEntity(); } }

    public bool isGameOver {
        get { return gameOverEntity != null; }
        set {
            var entity = gameOverEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isGameOver = true;
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

    static readonly GameOverComponent gameOverComponent = new GameOverComponent();

    public bool isGameOver {
        get { return HasComponent(GameComponentsLookup.GameOver); }
        set {
            if (value != isGameOver) {
                var index = GameComponentsLookup.GameOver;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : gameOverComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherGameOver;

    public static Entitas.IMatcher<GameEntity> GameOver {
        get {
            if (_matcherGameOver == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GameOver);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGameOver = matcher;
            }

            return _matcherGameOver;
        }
    }
}
