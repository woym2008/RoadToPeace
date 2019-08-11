//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LifeComponent life { get { return (LifeComponent)GetComponent(GameComponentsLookup.Life); } }
    public bool hasLife { get { return HasComponent(GameComponentsLookup.Life); } }

    public void AddLife(int newLifeValue) {
        var index = GameComponentsLookup.Life;
        var component = (LifeComponent)CreateComponent(index, typeof(LifeComponent));
        component.lifeValue = newLifeValue;
        AddComponent(index, component);
    }

    public void ReplaceLife(int newLifeValue) {
        var index = GameComponentsLookup.Life;
        var component = (LifeComponent)CreateComponent(index, typeof(LifeComponent));
        component.lifeValue = newLifeValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLife() {
        RemoveComponent(GameComponentsLookup.Life);
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

    static Entitas.IMatcher<GameEntity> _matcherLife;

    public static Entitas.IMatcher<GameEntity> Life {
        get {
            if (_matcherLife == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Life);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLife = matcher;
            }

            return _matcherLife;
        }
    }
}
