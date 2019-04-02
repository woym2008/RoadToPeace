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
using UnityEngine;

public class UpdateDragSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private IGroup<GameEntity> _selectFloor;
    private IGroup<GameEntity> _allFloor;
    Vector3 _offset;

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
            Debug.Log("isPointerHolding: " + _contexts.input.leftSidePointerEntity.isPointerHolding);
            if(_contexts.input.leftSidePointerEntity.isPointerHolding)
            {
                //变换到世界坐标
                //_contexts.input.pointerCurrentPos.value;
                //if(_selectFloor.count == 0)
                //{
                    var pos = _contexts.input.pointerHoldingStartPos.value;
                    var curpos = _contexts.input.pointerCurrentPos.value;
                    //得写一个camera 的 component 能获取camera
                    var camera = _contexts.game.gameCamera.camera;
                    var worldpos = camera.ScreenToWorldPoint(pos);
                    var worldcurpos = camera.ScreenToWorldPoint(curpos);

                    var floorwidth = _contexts.config.floorData.floorWidth;

                    if (_selectFloor != null && _selectFloor.count > 0)
                    {
                        //var floorwidth = _contexts.config.floorData.floorWidth;
                        foreach (var select in _selectFloor)
                        {
                            if ((select.position.position.x - 0.5f * floorwidth) >= worldcurpos.x ||
                                   (select.position.position.x + 0.5f * floorwidth) <= worldcurpos.x)
                            {
                                //select.isDragFloor = false;
                                //select.RemoveDragOffset();
                            }
                            else
                            {
                                var newy = worldcurpos.y - select.dragOffset.offset.y;
                                //floor.ReplacePosition(new Vector3(
                                //    floor.position.position.x,
                                //    newy,
                                //    floor.position.position.z
                                //    ));
                                select.position.position.y = newy;
                            }
                        }
                    }
                //_offset = worldpos - 
                //
                foreach (var floor in _allFloor)
                    {
                        if(floor.hasPosition)
                        {
                            if(!floor.isDragFloor)
                            {
                                if ((floor.position.position.x - 0.5f * floorwidth) < worldpos.x &&
                               (floor.position.position.x + 0.5f * floorwidth) > worldpos.x)
                                {
                                    floor.isDragFloor = true;
                                    floor.ReplaceDragOffset(worldpos - floor.position.position);
                                }
                            }
                            //else
                            //{
                            //    if ((floor.position.position.x - 0.5f * floorwidth) >= worldpos.x ||
                            //   (floor.position.position.x + 0.5f * floorwidth) <= worldpos.x)
                            //    {
                            //        floor.isDragFloor = false;
                            //        floor.RemoveDragOffset();
                            //    }
                            //    else
                            //    {
                            //        var newy = worldpos.y - floor.dragOffset.offset.y;
                            //        //floor.ReplacePosition(new Vector3(
                            //        //    floor.position.position.x,
                            //        //    newy,
                            //        //    floor.position.position.z
                            //        //    ));
                            //        floor.position.position.y = newy;
                            //    }
                            //}
                            
                            //检查点击位置 和 floor位置 如果ok 则设置为drag
                            //floor.isDragFloor = true;
                        }
                    }

                //}
                //else
                //{
                //    //有正在拉着的floor 则处理
                //}

            }
        }
    }
}
