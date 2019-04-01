using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class InitPointerSystem : IInitializeSystem
{
    private Contexts _contexts;
    public InitPointerSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var e = _contexts.input.CreateEntity();
        e.isLeftSidePointer = true;

    }

    void AddCommon(InputEntity e)
    {
        //e.AddPointerHoldingTime(0f);
        //e.isPointerStartedHolding = false;
        //e.isPointerHolding = false;
        //e.isPointerReleased = false;
    }
}
