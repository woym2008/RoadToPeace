/* ========================================================
 *	类名称：ViewComponent
 *	作 者：Zhangfan
 *	创建时间：2019-03-19 19:13:50
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

[Game]
public class ViewComponent : IComponent
{
    public IView Value;
}
