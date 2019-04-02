/* ========================================================
 *	类名称：DragOffsetComponent
 *	作 者：Zhangfan
 *	创建时间：2019-04-02 15:30:33
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;
using UnityEngine;

[Game]
public class DragOffsetComponent : IComponent
{
    public Vector3 offset;
}
