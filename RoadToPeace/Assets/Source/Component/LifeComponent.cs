/* ========================================================
 *	类名称：LifeComponent
 *	作 者：Zhangfan
 *	创建时间：2019-03-18 18:55:26
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
public class LifeComponent : IComponent
{
    public int lifeValue;
}
