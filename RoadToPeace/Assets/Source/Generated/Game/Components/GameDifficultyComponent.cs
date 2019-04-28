//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity difficultyEntity { get { return GetGroup(GameMatcher.Difficulty).GetSingleEntity(); } }
    public DifficultyComponent difficulty { get { return difficultyEntity.difficulty; } }
    public bool hasDifficulty { get { return difficultyEntity != null; } }

    public GameEntity SetDifficulty(int newValue) {
        if (hasDifficulty) {
            throw new Entitas.EntitasException("Could not set Difficulty!\n" + this + " already has an entity with DifficultyComponent!",
                "You should check if the context already has a difficultyEntity before setting it or use context.ReplaceDifficulty().");
        }
        var entity = CreateEntity();
        entity.AddDifficulty(newValue);
        return entity;
    }

    public void ReplaceDifficulty(int newValue) {
        var entity = difficultyEntity;
        if (entity == null) {
            entity = SetDifficulty(newValue);
        } else {
            entity.ReplaceDifficulty(newValue);
        }
    }

    public void RemoveDifficulty() {
        difficultyEntity.Destroy();
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

    public DifficultyComponent difficulty { get { return (DifficultyComponent)GetComponent(GameComponentsLookup.Difficulty); } }
    public bool hasDifficulty { get { return HasComponent(GameComponentsLookup.Difficulty); } }

    public void AddDifficulty(int newValue) {
        var index = GameComponentsLookup.Difficulty;
        var component = (DifficultyComponent)CreateComponent(index, typeof(DifficultyComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceDifficulty(int newValue) {
        var index = GameComponentsLookup.Difficulty;
        var component = (DifficultyComponent)CreateComponent(index, typeof(DifficultyComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveDifficulty() {
        RemoveComponent(GameComponentsLookup.Difficulty);
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

    static Entitas.IMatcher<GameEntity> _matcherDifficulty;

    public static Entitas.IMatcher<GameEntity> Difficulty {
        get {
            if (_matcherDifficulty == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Difficulty);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherDifficulty = matcher;
            }

            return _matcherDifficulty;
        }
    }
}