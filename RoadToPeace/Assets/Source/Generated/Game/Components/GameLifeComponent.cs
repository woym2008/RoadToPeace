//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity lifeEntity { get { return GetGroup(GameMatcher.Life).GetSingleEntity(); } }
    public LifeComponent life { get { return lifeEntity.life; } }
    public bool hasLife { get { return lifeEntity != null; } }

    public GameEntity SetLife(int newLifeValue) {
        if (hasLife) {
            throw new Entitas.EntitasException("Could not set Life!\n" + this + " already has an entity with LifeComponent!",
                "You should check if the context already has a lifeEntity before setting it or use context.ReplaceLife().");
        }
        var entity = CreateEntity();
        entity.AddLife(newLifeValue);
        return entity;
    }

    public void ReplaceLife(int newLifeValue) {
        var entity = lifeEntity;
        if (entity == null) {
            entity = SetLife(newLifeValue);
        } else {
            entity.ReplaceLife(newLifeValue);
        }
    }

    public void RemoveLife() {
        lifeEntity.Destroy();
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
