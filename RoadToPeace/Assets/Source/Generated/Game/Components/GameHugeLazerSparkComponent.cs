//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public HugeLazerSparkComponent hugeLazerSpark { get { return (HugeLazerSparkComponent)GetComponent(GameComponentsLookup.HugeLazerSpark); } }
    public bool hasHugeLazerSpark { get { return HasComponent(GameComponentsLookup.HugeLazerSpark); } }

    public void AddHugeLazerSpark(string newMarkstr) {
        var index = GameComponentsLookup.HugeLazerSpark;
        var component = (HugeLazerSparkComponent)CreateComponent(index, typeof(HugeLazerSparkComponent));
        component.markstr = newMarkstr;
        AddComponent(index, component);
    }

    public void ReplaceHugeLazerSpark(string newMarkstr) {
        var index = GameComponentsLookup.HugeLazerSpark;
        var component = (HugeLazerSparkComponent)CreateComponent(index, typeof(HugeLazerSparkComponent));
        component.markstr = newMarkstr;
        ReplaceComponent(index, component);
    }

    public void RemoveHugeLazerSpark() {
        RemoveComponent(GameComponentsLookup.HugeLazerSpark);
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

    static Entitas.IMatcher<GameEntity> _matcherHugeLazerSpark;

    public static Entitas.IMatcher<GameEntity> HugeLazerSpark {
        get {
            if (_matcherHugeLazerSpark == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.HugeLazerSpark);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherHugeLazerSpark = matcher;
            }

            return _matcherHugeLazerSpark;
        }
    }
}
