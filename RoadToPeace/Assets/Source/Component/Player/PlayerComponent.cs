using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class PlayerLogicComponent : IComponent
{
}

[Game][Unique]
public class PlayerUIComponent : IComponent
{
    public Transform hpui;
}