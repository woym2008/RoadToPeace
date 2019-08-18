using UnityEngine;
using System.Collections;
using Entitas;

[Game]
public class HpComponent : IComponent
{
    public float hp;
}

[Game]
public class ChildComponent : IComponent
{
    public GameEntity value;
}