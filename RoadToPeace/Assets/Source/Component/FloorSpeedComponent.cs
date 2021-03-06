﻿/* ========================================================
 *	类名称：FloorSpeedComponent
 *	作 者：Zhangfan
 *	创建时间：2019-03-22 18:32:13
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
[Unique]
public class FloorSpeedComponent : IComponent
{
    public float value;
    //目标速度，为了速度不会突然提升提升
    public float targetvalue;
}
