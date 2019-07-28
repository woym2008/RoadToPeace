//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ConfigContext {

    public ConfigEntity bossNamesEntity { get { return GetGroup(ConfigMatcher.BossNames).GetSingleEntity(); } }
    public BossNamesComponent bossNames { get { return bossNamesEntity.bossNames; } }
    public bool hasBossNames { get { return bossNamesEntity != null; } }

    public ConfigEntity SetBossNames(System.Collections.Generic.List<string> newBossnames) {
        if (hasBossNames) {
            throw new Entitas.EntitasException("Could not set BossNames!\n" + this + " already has an entity with BossNamesComponent!",
                "You should check if the context already has a bossNamesEntity before setting it or use context.ReplaceBossNames().");
        }
        var entity = CreateEntity();
        entity.AddBossNames(newBossnames);
        return entity;
    }

    public void ReplaceBossNames(System.Collections.Generic.List<string> newBossnames) {
        var entity = bossNamesEntity;
        if (entity == null) {
            entity = SetBossNames(newBossnames);
        } else {
            entity.ReplaceBossNames(newBossnames);
        }
    }

    public void RemoveBossNames() {
        bossNamesEntity.Destroy();
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

    public BossNamesComponent bossNames { get { return (BossNamesComponent)GetComponent(ConfigComponentsLookup.BossNames); } }
    public bool hasBossNames { get { return HasComponent(ConfigComponentsLookup.BossNames); } }

    public void AddBossNames(System.Collections.Generic.List<string> newBossnames) {
        var index = ConfigComponentsLookup.BossNames;
        var component = (BossNamesComponent)CreateComponent(index, typeof(BossNamesComponent));
        component.bossnames = newBossnames;
        AddComponent(index, component);
    }

    public void ReplaceBossNames(System.Collections.Generic.List<string> newBossnames) {
        var index = ConfigComponentsLookup.BossNames;
        var component = (BossNamesComponent)CreateComponent(index, typeof(BossNamesComponent));
        component.bossnames = newBossnames;
        ReplaceComponent(index, component);
    }

    public void RemoveBossNames() {
        RemoveComponent(ConfigComponentsLookup.BossNames);
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

    static Entitas.IMatcher<ConfigEntity> _matcherBossNames;

    public static Entitas.IMatcher<ConfigEntity> BossNames {
        get {
            if (_matcherBossNames == null) {
                var matcher = (Entitas.Matcher<ConfigEntity>)Entitas.Matcher<ConfigEntity>.AllOf(ConfigComponentsLookup.BossNames);
                matcher.componentNames = ConfigComponentsLookup.componentNames;
                _matcherBossNames = matcher;
            }

            return _matcherBossNames;
        }
    }
}