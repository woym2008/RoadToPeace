using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

//控制出随机块时的出块难度 如果为0 一个陷阱都没有
[Game]
public class FloorDifficultyComponent : IComponent
{
    public int value;
}
