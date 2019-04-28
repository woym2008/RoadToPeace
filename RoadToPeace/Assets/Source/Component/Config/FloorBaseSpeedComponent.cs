using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public class FloorBaseSpeedComponent : IComponent
{
    public float value;
}
