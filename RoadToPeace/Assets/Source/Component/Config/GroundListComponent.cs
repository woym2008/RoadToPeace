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

[Config][Unique]
public class WallListComponent : IComponent
{
    public List<string> wallList;
}

[Config]
[Unique]
public class WallDataComponent : IComponent
{
    //路面横向长度
    public float wallWidth;
}