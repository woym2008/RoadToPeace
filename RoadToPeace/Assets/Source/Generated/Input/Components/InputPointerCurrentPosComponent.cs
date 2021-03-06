//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity pointerCurrentPosEntity { get { return GetGroup(InputMatcher.PointerCurrentPos).GetSingleEntity(); } }
    public PointerCurrentPosComponent pointerCurrentPos { get { return pointerCurrentPosEntity.pointerCurrentPos; } }
    public bool hasPointerCurrentPos { get { return pointerCurrentPosEntity != null; } }

    public InputEntity SetPointerCurrentPos(UnityEngine.Vector3 newValue) {
        if (hasPointerCurrentPos) {
            throw new Entitas.EntitasException("Could not set PointerCurrentPos!\n" + this + " already has an entity with PointerCurrentPosComponent!",
                "You should check if the context already has a pointerCurrentPosEntity before setting it or use context.ReplacePointerCurrentPos().");
        }
        var entity = CreateEntity();
        entity.AddPointerCurrentPos(newValue);
        return entity;
    }

    public void ReplacePointerCurrentPos(UnityEngine.Vector3 newValue) {
        var entity = pointerCurrentPosEntity;
        if (entity == null) {
            entity = SetPointerCurrentPos(newValue);
        } else {
            entity.ReplacePointerCurrentPos(newValue);
        }
    }

    public void RemovePointerCurrentPos() {
        pointerCurrentPosEntity.Destroy();
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
public partial class InputEntity {

    public PointerCurrentPosComponent pointerCurrentPos { get { return (PointerCurrentPosComponent)GetComponent(InputComponentsLookup.PointerCurrentPos); } }
    public bool hasPointerCurrentPos { get { return HasComponent(InputComponentsLookup.PointerCurrentPos); } }

    public void AddPointerCurrentPos(UnityEngine.Vector3 newValue) {
        var index = InputComponentsLookup.PointerCurrentPos;
        var component = (PointerCurrentPosComponent)CreateComponent(index, typeof(PointerCurrentPosComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePointerCurrentPos(UnityEngine.Vector3 newValue) {
        var index = InputComponentsLookup.PointerCurrentPos;
        var component = (PointerCurrentPosComponent)CreateComponent(index, typeof(PointerCurrentPosComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePointerCurrentPos() {
        RemoveComponent(InputComponentsLookup.PointerCurrentPos);
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherPointerCurrentPos;

    public static Entitas.IMatcher<InputEntity> PointerCurrentPos {
        get {
            if (_matcherPointerCurrentPos == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.PointerCurrentPos);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherPointerCurrentPos = matcher;
            }

            return _matcherPointerCurrentPos;
        }
    }
}
