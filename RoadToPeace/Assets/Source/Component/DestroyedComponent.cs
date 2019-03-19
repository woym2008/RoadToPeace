/* ========================================================
 *	类名称：DestroyedComponent
 *	作 者：Zhangfan
 *	创建时间：2019-03-19 18:43:17
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
[Event(EventTarget.Self)]
public class DestroyedComponent : IComponent
{
}
