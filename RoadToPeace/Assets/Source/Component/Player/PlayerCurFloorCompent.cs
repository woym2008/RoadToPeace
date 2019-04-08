using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

[Game]
public class PlayerCurFloorComponent : IComponent
{
    public GameEntity curFloor;
    public int curBrickID;
}
