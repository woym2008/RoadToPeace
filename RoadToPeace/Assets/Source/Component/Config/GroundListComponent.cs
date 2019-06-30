using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;

[Config]
[Unique]
public class GroundListComponent : IComponent
{
    public List<string> groundList;
}
