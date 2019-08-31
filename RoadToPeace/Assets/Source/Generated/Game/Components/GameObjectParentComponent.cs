//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ObjectParentComponent objectParent { get { return (ObjectParentComponent)GetComponent(GameComponentsLookup.ObjectParent); } }
    public bool hasObjectParent { get { return HasComponent(GameComponentsLookup.ObjectParent); } }

    public void AddObjectParent(GameEntity newParent) {
        var index = GameComponentsLookup.ObjectParent;
        var component = (ObjectParentComponent)CreateComponent(index, typeof(ObjectParentComponent));
        component.parent = newParent;
        AddComponent(index, component);
    }

    public void ReplaceObjectParent(GameEntity newParent) {
        var index = GameComponentsLookup.ObjectParent;
        var component = (ObjectParentComponent)CreateComponent(index, typeof(ObjectParentComponent));
        component.parent = newParent;
        ReplaceComponent(index, component);
    }

    public void RemoveObjectParent() {
        RemoveComponent(GameComponentsLookup.ObjectParent);
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

    static Entitas.IMatcher<GameEntity> _matcherObjectParent;

    public static Entitas.IMatcher<GameEntity> ObjectParent {
        get {
            if (_matcherObjectParent == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ObjectParent);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherObjectParent = matcher;
            }

            return _matcherObjectParent;
        }
    }
}