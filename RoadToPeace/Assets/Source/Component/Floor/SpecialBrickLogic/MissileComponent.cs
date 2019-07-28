using UnityEngine;
using System.Collections;
using Entitas;

[Game]
public class MissileComponent : IComponent
{
    public int selfmissilepos;
    public GameEntity preMissileBrick;
    public GameEntity postMissileBrick;
}
