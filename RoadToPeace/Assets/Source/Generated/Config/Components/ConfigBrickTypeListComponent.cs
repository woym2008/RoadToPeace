//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ConfigContext {

    public ConfigEntity brickTypeListEntity { get { return GetGroup(ConfigMatcher.BrickTypeList).GetSingleEntity(); } }
    public BrickTypeListComponent brickTypeList { get { return brickTypeListEntity.brickTypeList; } }
    public bool hasBrickTypeList { get { return brickTypeListEntity != null; } }

    public ConfigEntity SetBrickTypeList(System.Collections.Generic.List<string> newTypeList) {
        if (hasBrickTypeList) {
            throw new Entitas.EntitasException("Could not set BrickTypeList!\n" + this + " already has an entity with BrickTypeListComponent!",
                "You should check if the context already has a brickTypeListEntity before setting it or use context.ReplaceBrickTypeList().");
        }
        var entity = CreateEntity();
        entity.AddBrickTypeList(newTypeList);
        return entity;
    }

    public void ReplaceBrickTypeList(System.Collections.Generic.List<string> newTypeList) {
        var entity = brickTypeListEntity;
        if (entity == null) {
            entity = SetBrickTypeList(newTypeList);
        } else {
            entity.ReplaceBrickTypeList(newTypeList);
        }
    }

    public void RemoveBrickTypeList() {
        brickTypeListEntity.Destroy();
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

    public BrickTypeListComponent brickTypeList { get { return (BrickTypeListComponent)GetComponent(ConfigComponentsLookup.BrickTypeList); } }
    public bool hasBrickTypeList { get { return HasComponent(ConfigComponentsLookup.BrickTypeList); } }

    public void AddBrickTypeList(System.Collections.Generic.List<string> newTypeList) {
        var index = ConfigComponentsLookup.BrickTypeList;
        var component = (BrickTypeListComponent)CreateComponent(index, typeof(BrickTypeListComponent));
        component.typeList = newTypeList;
        AddComponent(index, component);
    }

    public void ReplaceBrickTypeList(System.Collections.Generic.List<string> newTypeList) {
        var index = ConfigComponentsLookup.BrickTypeList;
        var component = (BrickTypeListComponent)CreateComponent(index, typeof(BrickTypeListComponent));
        component.typeList = newTypeList;
        ReplaceComponent(index, component);
    }

    public void RemoveBrickTypeList() {
        RemoveComponent(ConfigComponentsLookup.BrickTypeList);
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

    static Entitas.IMatcher<ConfigEntity> _matcherBrickTypeList;

    public static Entitas.IMatcher<ConfigEntity> BrickTypeList {
        get {
            if (_matcherBrickTypeList == null) {
                var matcher = (Entitas.Matcher<ConfigEntity>)Entitas.Matcher<ConfigEntity>.AllOf(ConfigComponentsLookup.BrickTypeList);
                matcher.componentNames = ConfigComponentsLookup.componentNames;
                _matcherBrickTypeList = matcher;
            }

            return _matcherBrickTypeList;
        }
    }
}
