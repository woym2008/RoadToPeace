using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config]
[Unique]
public class GroundDataComponent : IComponent
{
    //路面横向长度
    public float groundWidth;
    //路面纵向长度
    public float groundHeight;
    //游戏开始时建造路面位置
    public Vector3 firstPos;
    //消失位置
    public Vector3 overPos;
    //总共路段数量
    public int numGround;
}
