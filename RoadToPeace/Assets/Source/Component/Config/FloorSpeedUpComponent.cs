using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//每等级提升的速度增量
[Config]
[Unique]
public class FloorSpeedUpComponent : IComponent
{
    public float value;
}
