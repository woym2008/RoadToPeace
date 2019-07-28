using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;

[Config]
[Unique]
public class NormalBrickTypeListComponent : IComponent
{
    public List<string> typeList;
}
