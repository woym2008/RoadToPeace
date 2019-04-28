using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Unique]
public class VelocityIncrementComponent : IComponent
{
    public float value;
}
