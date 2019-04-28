using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public class DifficultLevelupComponent : IComponent
{
    public float leveluptime;
}
