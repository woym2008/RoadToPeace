using UnityEngine;
using UnityEditor;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//[Config]
[Unique]
public class FloorDataComponent : IComponent
{
    public float floorWidth;
    public float floorHeight;
    public Vector3 firstPos;
}