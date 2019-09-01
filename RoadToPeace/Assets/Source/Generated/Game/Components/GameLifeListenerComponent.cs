//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LifeListenerComponent lifeListener { get { return (LifeListenerComponent)GetComponent(GameComponentsLookup.LifeListener); } }
    public bool hasLifeListener { get { return HasComponent(GameComponentsLookup.LifeListener); } }

    public void AddLifeListener(System.Collections.Generic.List<ILifeListener> newValue) {
        var index = GameComponentsLookup.LifeListener;
        var component = (LifeListenerComponent)CreateComponent(index, typeof(LifeListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceLifeListener(System.Collections.Generic.List<ILifeListener> newValue) {
        var index = GameComponentsLookup.LifeListener;
        var component = (LifeListenerComponent)CreateComponent(index, typeof(LifeListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveLifeListener() {
        RemoveComponent(GameComponentsLookup.LifeListener);
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

    static Entitas.IMatcher<GameEntity> _matcherLifeListener;

    public static Entitas.IMatcher<GameEntity> LifeListener {
        get {
            if (_matcherLifeListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LifeListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLifeListener = matcher;
            }

            return _matcherLifeListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddLifeListener(ILifeListener value) {
        var listeners = hasLifeListener
            ? lifeListener.value
            : new System.Collections.Generic.List<ILifeListener>();
        listeners.Add(value);
        ReplaceLifeListener(listeners);
    }

    public void RemoveLifeListener(ILifeListener value, bool removeComponentWhenEmpty = true) {
        var listeners = lifeListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveLifeListener();
        } else {
            ReplaceLifeListener(listeners);
        }
    }
}
