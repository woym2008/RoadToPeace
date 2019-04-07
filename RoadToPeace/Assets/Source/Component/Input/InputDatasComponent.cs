using UnityEngine;
using System;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input]
[Unique]
public class InputDatasComponent : IComponent
{
    public InputData[] datas;
}
