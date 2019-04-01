/* ========================================================
 *	类名称：UpdateDragSystem
 *	作 者：Zhangfan
 *	创建时间：2019-04-01 18:47:54
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

public class UpdateDragSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    public UpdateDragSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if(_contexts.game.gameState.state == GameState.Running)
        {
            //已经点击了
            if(_contexts.input.isLeftSidePointer)
            {
                //变换到世界坐标
                //_contexts.input.pointerCurrentPos.value;
            }
        }
    }
}
