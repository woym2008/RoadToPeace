/* ========================================================
 *	类名称：BrickTypeComponent
 *	作 者：Zhangfan
 *	创建时间：2019-03-25 18:47:46
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
public class BrickTypeComponent : IComponent
{
    public string value;
}