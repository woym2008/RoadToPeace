/* ========================================================
 *	类名称：CameraPosComponent
 *	作 者：Zhangfan
 *	创建时间：2019-03-27 10:50:34
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
public class CameraPosComponent : IComponent
{
    public Vector3 runningpos;
    public Vector3 titlepos;
}
