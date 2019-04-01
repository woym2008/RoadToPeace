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
    private IGroup<GameEntity> _selectFloor;
    private IGroup<GameEntity> _allFloor;

    public UpdateDragSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;

        _allFloor = contexts.game.GetGroup(GameMatcher.Floor);

        _selectFloor = contexts.game.GetGroup(GameMatcher.DragFloor);
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
                if(_selectFloor.count == 0)
                {
                    var pos = _contexts.input.pointerHoldingStartPos;
                    //得写一个camera 的 component 能获取camera

                    //
                    foreach(var floor in _allFloor)
                    {
                        if(floor.hasPosition)
                        {
                            //检查点击位置 和 floor位置 如果ok 则设置为drag
                            //floor.isDragFloor = true;
                        }
                    }
                }
                else
                {
                    //有正在拉着的floor 则处理
                }
            }
        }
    }
}
