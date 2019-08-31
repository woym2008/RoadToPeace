using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

public enum PassBrickWay
{
    Run,
    //跳过去
    Jump,
    //撞死
    Collision,
    //电死
    Electrocution,
    //空中阻挡
    AirCollision,

}

public class WayOfPassBrickComponent : IComponent
{
    public PassBrickWay value;
}
