using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config,Unique]
public class GameForwardComponent : IComponent
{   
    public Transform point;
}
