using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public class PlayerDataComponent : IComponent
{
    //跳起基础速度
    public float jumpupspeed;
    //跳落基础速度
    public float jumpoffspeed;
    //最大跳跃高度
    public float jumpheight;
}
