/* ========================================================
 *	类名称：FloorComponent
 *	作 者：Zhangfan
 *	创建时间：2019-03-22 15:17:17
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
public class FloorComponent : IComponent
{
}

[Game, Unique]
public class WaitAddFloorCount : IComponent
{
    public int count;
}

[Game]
public class FloorTypeComponent : IComponent
{
    public string type;
}

[Game,Unique]
public class FloorCountComponent : IComponent
{
    public int value;
}