using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config,Unique]
public class BrickTableComponent : IComponent
{
    public BrickTable table;
}
