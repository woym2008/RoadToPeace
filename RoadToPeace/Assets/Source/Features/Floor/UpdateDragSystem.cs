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

        _selectFloor = contexts.game.GetGroup(GameMatcher.Drag);
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
                var camera = _contexts.game.gameCamera.camera;
                var floorwidth = _contexts.config.floorData.floorWidth;
                var floorheight = _contexts.config.floorData.floorHeight;
                var halffloorheight = floorheight * 0.5f;

                var datas = _contexts.input.inputDatas.datas;
                if(datas != null)
                {
                    foreach (var data in datas)
                    {
                        var worldpos = camera.ScreenToWorldPoint(data.startpos);
                        var worldcurpos = camera.ScreenToWorldPoint(data.curpos);

                        foreach (var floor in _allFloor)
                        {
                            if (floor.hasPosition)
                            {
                                //---------------------------
                                if (!floor.hasDrag || !floor.drag.isdrag)
                                {
                                    if ((floor.position.position.x - 0.5f * floorwidth) < worldpos.x &&
                                   (floor.position.position.x + 0.5f * floorwidth) > worldpos.x)
                                    {
                                        //floor.ReplaceDrag(true);
                                        floor.ReplaceDrag(true, data.fingerindex);
                                        floor.ReplaceDragOffset(worldpos - floor.position.position);
                                    }
                                }

                                else if(data.fingerindex == floor.drag.dragID)
                                {
                                    if ((floor.position.position.x - 0.5f * floorwidth) >= worldcurpos.x ||
                                        (floor.position.position.x + 0.5f * floorwidth) <= worldcurpos.x)
                                    {
                                        //floor.ReplaceDrag(false);
                                        floor.RemoveDrag();
                                        floor.RemoveDragOffset();
                                    }
                                    else
                                    {
                                        var newy = worldcurpos.y - floor.dragOffset.offset.y;
                                        //floor.ReplacePosition(new Vector3(
                                        //    floor.position.position.x,
                                        //    newy,
                                        //    floor.position.position.z
                                        //    ));
                                        var dis = newy - floor.position.position.y;
                                        if (dis > halffloorheight && floor.gridID.id >= 1)
                                        {
                                            //向上
                                            floor.position.position.y = floor.position.position.y + floorheight;
                                            floor.gridID.id--;

                                        }
                                        else if (dis < -halffloorheight && floor.gridID.id <= 1)
                                        {
                                            //向下
                                            floor.position.position.y = floor.position.position.y - floorheight;
                                            floor.gridID.id++;
                                        }


                                        //floor.position.position.y = newy;
                                    }
                                }
                                //---------------------------
                                if (!floor.hasDrag || !floor.drag.isdrag)
                                {

                                }
                            }
                        }
                    }

                }

                //--------------------------------------------------------------
                /*
                var pos = _contexts.input.pointerHoldingStartPos.value;
                    var curpos = _contexts.input.pointerCurrentPos.value;
                    //得写一个camera 的 component 能获取camera
                    var camera = _contexts.game.gameCamera.camera;
                    var worldpos = camera.ScreenToWorldPoint(pos);
                    var worldcurpos = camera.ScreenToWorldPoint(curpos);

                    

                foreach (var floor in _allFloor)
                {
                    if (floor.hasPosition)
                    {
                        if (!floor.hasDrag || !floor.drag.isdrag)
                        {
                            if ((floor.position.position.x - 0.5f * floorwidth) < worldpos.x &&
                           (floor.position.position.x + 0.5f * floorwidth) > worldpos.x)
                            {
                                //floor.ReplaceDrag(true);
                                floor.ReplaceDrag(true, 0);
                                floor.ReplaceDragOffset(worldpos - floor.position.position);
                            }
                        }

                        else
                        {
                            if ((floor.position.position.x - 0.5f * floorwidth) >= worldcurpos.x ||
                                (floor.position.position.x + 0.5f * floorwidth) <= worldcurpos.x)
                            {
                                //floor.ReplaceDrag(false);
                                floor.RemoveDrag();
                                floor.RemoveDragOffset();
                            }
                            else
                            {
                                var newy = worldcurpos.y - floor.dragOffset.offset.y;
                                //floor.ReplacePosition(new Vector3(
                                //    floor.position.position.x,
                                //    newy,
                                //    floor.position.position.z
                                //    ));
                                var dis = newy - floor.position.position.y;
                                if(dis > halffloorheight && floor.gridID.id >= 1)
                                {
                                    //向上
                                    floor.position.position.y = floor.position.position.y + floorheight;
                                    floor.gridID.id--;

                                }
                                else if(dis < -halffloorheight && floor.gridID.id <= 1)
                                {
                                    //向下
                                    floor.position.position.y = floor.position.position.y - floorheight;
                                    floor.gridID.id++;
                                }


                                //floor.position.position.y = newy;
                            }
                        }

                        //检查点击位置 和 floor位置 如果ok 则设置为drag
                        //floor.isDragFloor = true;
                    }
                }
                */
            }
        }
    }
}
