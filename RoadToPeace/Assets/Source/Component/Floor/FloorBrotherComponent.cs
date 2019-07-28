using UnityEngine;
using System.Collections;
using Entitas;

[Game]
public class FloorBrotherComponent : IComponent
{
    public GameEntity Left;
    public GameEntity Right;
}
