//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity velocityIncrementEntity { get { return GetGroup(GameMatcher.VelocityIncrement).GetSingleEntity(); } }
    public VelocityIncrementComponent velocityIncrement { get { return velocityIncrementEntity.velocityIncrement; } }
    public bool hasVelocityIncrement { get { return velocityIncrementEntity != null; } }

    public GameEntity SetVelocityIncrement(float newValue) {
        if (hasVelocityIncrement) {
            throw new Entitas.EntitasException("Could not set VelocityIncrement!\n" + this + " already has an entity with VelocityIncrementComponent!",
                "You should check if the context already has a velocityIncrementEntity before setting it or use context.ReplaceVelocityIncrement().");
        }
        var entity = CreateEntity();
        entity.AddVelocityIncrement(newValue);
        return entity;
    }

    public void ReplaceVelocityIncrement(float newValue) {
        var entity = velocityIncrementEntity;
        if (entity == null) {
            entity = SetVelocityIncrement(newValue);
        } else {
            entity.ReplaceVelocityIncrement(newValue);
        }
    }

    public void RemoveVelocityIncrement() {
        velocityIncrementEntity.Destroy();
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

    public VelocityIncrementComponent velocityIncrement { get { return (VelocityIncrementComponent)GetComponent(GameComponentsLookup.VelocityIncrement); } }
    public bool hasVelocityIncrement { get { return HasComponent(GameComponentsLookup.VelocityIncrement); } }

    public void AddVelocityIncrement(float newValue) {
        var index = GameComponentsLookup.VelocityIncrement;
        var component = (VelocityIncrementComponent)CreateComponent(index, typeof(VelocityIncrementComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceVelocityIncrement(float newValue) {
        var index = GameComponentsLookup.VelocityIncrement;
        var component = (VelocityIncrementComponent)CreateComponent(index, typeof(VelocityIncrementComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveVelocityIncrement() {
        RemoveComponent(GameComponentsLookup.VelocityIncrement);
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

    static Entitas.IMatcher<GameEntity> _matcherVelocityIncrement;

    public static Entitas.IMatcher<GameEntity> VelocityIncrement {
        get {
            if (_matcherVelocityIncrement == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.VelocityIncrement);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherVelocityIncrement = matcher;
            }

            return _matcherVelocityIncrement;
        }
    }
}