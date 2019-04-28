//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ConfigContext {

    public ConfigEntity playerDataEntity { get { return GetGroup(ConfigMatcher.PlayerData).GetSingleEntity(); } }
    public PlayerDataComponent playerData { get { return playerDataEntity.playerData; } }
    public bool hasPlayerData { get { return playerDataEntity != null; } }

    public ConfigEntity SetPlayerData(float newJumpupspeed, float newJumpoffspeed, float newJumpheight) {
        if (hasPlayerData) {
            throw new Entitas.EntitasException("Could not set PlayerData!\n" + this + " already has an entity with PlayerDataComponent!",
                "You should check if the context already has a playerDataEntity before setting it or use context.ReplacePlayerData().");
        }
        var entity = CreateEntity();
        entity.AddPlayerData(newJumpupspeed, newJumpoffspeed, newJumpheight);
        return entity;
    }

    public void ReplacePlayerData(float newJumpupspeed, float newJumpoffspeed, float newJumpheight) {
        var entity = playerDataEntity;
        if (entity == null) {
            entity = SetPlayerData(newJumpupspeed, newJumpoffspeed, newJumpheight);
        } else {
            entity.ReplacePlayerData(newJumpupspeed, newJumpoffspeed, newJumpheight);
        }
    }

    public void RemovePlayerData() {
        playerDataEntity.Destroy();
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
public partial class ConfigEntity {

    public PlayerDataComponent playerData { get { return (PlayerDataComponent)GetComponent(ConfigComponentsLookup.PlayerData); } }
    public bool hasPlayerData { get { return HasComponent(ConfigComponentsLookup.PlayerData); } }

    public void AddPlayerData(float newJumpupspeed, float newJumpoffspeed, float newJumpheight) {
        var index = ConfigComponentsLookup.PlayerData;
        var component = (PlayerDataComponent)CreateComponent(index, typeof(PlayerDataComponent));
        component.jumpupspeed = newJumpupspeed;
        component.jumpoffspeed = newJumpoffspeed;
        component.jumpheight = newJumpheight;
        AddComponent(index, component);
    }

    public void ReplacePlayerData(float newJumpupspeed, float newJumpoffspeed, float newJumpheight) {
        var index = ConfigComponentsLookup.PlayerData;
        var component = (PlayerDataComponent)CreateComponent(index, typeof(PlayerDataComponent));
        component.jumpupspeed = newJumpupspeed;
        component.jumpoffspeed = newJumpoffspeed;
        component.jumpheight = newJumpheight;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerData() {
        RemoveComponent(ConfigComponentsLookup.PlayerData);
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
public sealed partial class ConfigMatcher {

    static Entitas.IMatcher<ConfigEntity> _matcherPlayerData;

    public static Entitas.IMatcher<ConfigEntity> PlayerData {
        get {
            if (_matcherPlayerData == null) {
                var matcher = (Entitas.Matcher<ConfigEntity>)Entitas.Matcher<ConfigEntity>.AllOf(ConfigComponentsLookup.PlayerData);
                matcher.componentNames = ConfigComponentsLookup.componentNames;
                _matcherPlayerData = matcher;
            }

            return _matcherPlayerData;
        }
    }
}