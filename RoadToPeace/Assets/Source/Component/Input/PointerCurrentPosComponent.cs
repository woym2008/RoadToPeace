﻿/* ========================================================
 *	类名称：PointerCurrentPosComponent
 *	作 者：Zhangfan
 *	创建时间：2019-04-01 18:58:23
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
using UnityEngine;

[Input]
[Unique]
public class PointerCurrentPosComponent : IComponent
{
    public Vector3 value;
}
