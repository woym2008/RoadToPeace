using UnityEngine;
using System.Collections;
using Entitas;

//用来标注 自己是floor上的第几个brick
[Game]
public class BrickIndexComponent : IComponent
{
    public int index;
}
