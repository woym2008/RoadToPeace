/* ========================================================
 *	类名称：StartPlayerPositionComponent
 *	作 者：Zhangfan
 *	创建时间：2019-03-20 19:39:25
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

[Config]
[Unique]
public class StartPlayerPositionComponent : IComponent
{
    public Vector2 value;
}
