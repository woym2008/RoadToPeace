//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity bossFightingEntity { get { return GetGroup(GameMatcher.BossFighting).GetSingleEntity(); } }

    public bool isBossFighting {
        get { return bossFightingEntity != null; }
        set {
            var entity = bossFightingEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isBossFighting = true;
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

    static readonly BossFighting bossFightingComponent = new BossFighting();

    public bool isBossFighting {
        get { return HasComponent(GameComponentsLookup.BossFighting); }
        set {
            if (value != isBossFighting) {
                var index = GameComponentsLookup.BossFighting;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : bossFightingComponent;

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

    static Entitas.IMatcher<GameEntity> _matcherBossFighting;

    public static Entitas.IMatcher<GameEntity> BossFighting {
        get {
            if (_matcherBossFighting == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BossFighting);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBossFighting = matcher;
            }

            return _matcherBossFighting;
        }
    }
}