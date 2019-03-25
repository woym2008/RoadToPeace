/* ========================================================
 *	类名称：BrickTypeCountComponent
 *	作 者：Zhangfan
 *	创建时间：2019-03-25 18:39:34
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
public class BrickTypeCountComponent : IComponent
{
    //这个属性决定地表的类型（草地 火焰 ）
    public int value;
}
