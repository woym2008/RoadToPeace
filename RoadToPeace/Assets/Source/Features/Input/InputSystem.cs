/* ========================================================
 *	类名称：InputSystem
 *	作 者：Zhangfan
 *	创建时间：2019-04-02 15:50:19
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

public class InputSystem : Feature
{
    public InputSystem(Contexts contexts, Services services)
    {
        Add(new InitPointerSystem(contexts, services));
        Add(new UpdatePointerSystem(contexts, services));

        //Add(new UpdateDragSystem(contexts, services));
        Add(new UpdateDrag3DSystem(contexts, services));
    }
}
