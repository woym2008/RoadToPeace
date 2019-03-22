/* ========================================================
 *	类名称：RoadBoundaryComponent
 *	作 者：Zhangfan
 *	创建时间：2019-03-22 18:40:46
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

[Config]
[Unique]
public class RoadBoundaryComponent : IComponent
{
    public float left;
    public float right;
}
