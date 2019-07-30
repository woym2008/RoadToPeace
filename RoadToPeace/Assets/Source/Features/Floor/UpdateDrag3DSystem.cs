/* ========================================================
 *  类名称：UpdateDragSystem
 *  作 者：Zhangfan
 *  创建时间：2019-07-14 10:54:00
 *  版 本：V1.0.0
 *  描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;
using UnityEngine;

public class UpdateDrag3DSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private IGroup<GameEntity> _selectFloor;
    private IGroup<GameEntity> _allFloor;
    Vector3 _offset;

    int layInput = LayerMask.NameToLayer("Input");

    public UpdateDrag3DSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;

        _allFloor = contexts.game.GetGroup(GameMatcher.Floor);

        _selectFloor = contexts.game.GetGroup(GameMatcher.Drag);
    }

    public void Execute()
    {
        if (_contexts.game.gameState.state == GameState.Running)
        {
            if (_contexts.input.leftSidePointerEntity.isPointerHolding)
            {
                var camera = _contexts.game.gameCamera.camera;
                var floorwidth = _contexts.config.floorData.floorWidth;
                var floorheight = _contexts.config.floorData.floorHeight;
                var halffloorheight = floorheight * 0.5f;

                var datas = _contexts.input.inputDatas.datas;

                var gamedirTransform = _contexts.config.gameForward.point;

                var firstpos = _contexts.config.groundData.firstPos;
                if (datas != null)
                {
                    if (datas.Length > 0)
                    {
                        foreach (var data in datas)
                        {
                            //var worldpos = camera.ScreenToWorldPoint(data.startpos);
                            var startray = camera.ScreenPointToRay(data.startpos);
                            RaycastHit starthit;
                            
                            if(!Physics.Raycast(startray, out starthit, 1 << layInput))
                            {
                                continue;
                            }
                            /*
                            var worldpos = startray.origin + (firstpos.z - camera.transform.position.z) * startray.direction;
                            //var worldcurpos = camera.ScreenToWorldPoint(data.curpos);
                            var curray = camera.ScreenPointToRay(data.curpos);
                            var worldcurpos = curray.origin + (firstpos.z - camera.transform.position.z) * curray.direction;
                            */
                            var camtopoint = Vector3.Distance(new Vector3(starthit.point.x, starthit.point.y-2, starthit.point.z), camera.transform.position);
                            var worldpos = camera.ScreenToWorldPoint(new Vector3(data.startpos.x, data.startpos.y, camtopoint));
                            var worldcurpos = camera.ScreenToWorldPoint(new Vector3(data.curpos.x, data.curpos.y, camtopoint));

                            var localpos = gamedirTransform.worldToLocalMatrix * worldpos;
                            var localcurpos = gamedirTransform.worldToLocalMatrix * worldcurpos;

                            foreach (var floor in _allFloor)
                            {
                                if (floor.hasPosition)
                                {
                                    var localfloorpos = gamedirTransform.worldToLocalMatrix * floor.position.position;
                                    switch (data.state)
                                    {
                                        case InputData.InputState.Begin:
                                            {
                                                if (!floor.hasDrag || !floor.drag.isdrag)
                                                {
                                                    /*
                                                    if ((floor.position.position.x - 0.5f * floorwidth) < worldcurpos.x &&
                                                   (floor.position.position.x + 0.5f * floorwidth) > worldcurpos.x)
                                                    {
                                                        //Debug.LogWarning("FirstClick");
                                                        //floor.ReplaceDrag(true);
                                                        floor.ReplaceDrag(true, data.fingerindex);
                                                        floor.ReplaceDragOffset(worldcurpos);
                                                    }*/
                                                    if ((localfloorpos.x - 0f * floorwidth) < localpos.x &&
                                                   (localfloorpos.x + 1f * floorwidth) > localpos.x)
                                                    {
                                                        //Debug.LogWarning("FirstClick");
                                                        //floor.ReplaceDrag(true);
                                                        floor.ReplaceDrag(true, data.fingerindex);
                                                        floor.ReplaceDragOffset(localpos);
                                                    }
                                                }
                                            }
                                            break;
                                        case InputData.InputState.Touching:
                                            {
                                                //Debug.LogWarning("Touching");
                                                //if (!floor.hasDrag || !floor.drag.isdrag)
                                                //{
                                                //    if ((floor.position.position.x - 0.5f * floorwidth) < worldcurpos.x &&
                                                //   (floor.position.position.x + 0.5f * floorwidth) > worldcurpos.x)
                                                //    {
                                                //        Debug.LogWarning("FirstClick");
                                                //        //floor.ReplaceDrag(true);
                                                //        floor.ReplaceDrag(true, data.fingerindex);
                                                //        floor.ReplaceDragOffset(worldcurpos);
                                                //    }
                                                //}
                                                //else
                                                if (floor.hasDrag && floor.drag.isdrag)
                                                {
                                                    if (data.fingerindex == floor.drag.dragID)
                                                    {
                                                        /*
                                                        var dis = worldcurpos.z - floor.dragOffset.offset.z;
                                                        if (dis > halffloorheight * 0.5f && floor.gridID.id <= 1)
                                                        {
                                                            //向上
                                                            floor.position.position.z = floor.position.position.z + floorheight;
                                                            floor.gridID.id++;

                                                        }
                                                        else if (dis < -halffloorheight * 0.5f && floor.gridID.id >= 1)
                                                        {
                                                            //向下
                                                            floor.position.position.z = floor.position.position.z - floorheight;
                                                            floor.gridID.id--;
                                                        }*/
                                                        var dis = localcurpos.z - floor.dragOffset.offset.z;
                                     
                                                        if (dis > halffloorheight * 0.5f && floor.gridID.id <= 1)
                                                        {
                                                            //向上
                                                            localfloorpos.z = localfloorpos.z + floorheight;
                                                            floor.gridID.id++;

                                                        }
                                                        else if (dis < -halffloorheight * 0.5f && floor.gridID.id >= 1)
                                                        {
                                                            //向下
                                                            localfloorpos.z = localfloorpos.z - floorheight;
                                                            floor.gridID.id--;
                                                        }
                                                        floor.position.position = gamedirTransform.localToWorldMatrix * localfloorpos;
                                                    }
                                                }
                                            }
                                            break;
                                        case InputData.InputState.End:
                                        case InputData.InputState.Discar:
                                            {
                                                //Debug.LogError("End");
                                                if (floor.hasDrag && floor.drag.isdrag)
                                                {
                                                    floor.RemoveDrag();
                                                    floor.RemoveDragOffset();
                                                }
                                            }
                                            break;
                                    }
                                    //---------------------------
                                    /*
                                    if (!floor.hasDrag || !floor.drag.isdrag)
                                    {
                                        if ((floor.position.position.x - 0.5f * floorwidth) < worldcurpos.x &&
                                       (floor.position.position.x + 0.5f * floorwidth) > worldcurpos.x)
                                        {
                                            if (data.state == InputData.InputState.Begin)
                                            {
                                                Debug.LogWarning("FirstClick");
                                                //floor.ReplaceDrag(true);
                                                floor.ReplaceDrag(true, data.fingerindex);
                                                floor.ReplaceDragOffset(worldcurpos);
                                            }
                                        }
                                    }

                                    else //if(data.fingerindex == floor.drag.dragID)
                                    {
                                        if (data.fingerindex == floor.drag.dragID)
                                        {
                                            var dis = worldcurpos.y - floor.dragOffset.offset.y;
                                            if (dis > halffloorheight * 0.5f && floor.gridID.id <= 1)
                                            {
                                                //向上
                                                floor.position.position.y = floor.position.position.y + floorheight;
                                                floor.gridID.id++;

                                            }
                                            else if (dis < -halffloorheight * 0.5f && floor.gridID.id >= 1)
                                            {
                                                //向下
                                                floor.position.position.y = floor.position.position.y - floorheight;
                                                floor.gridID.id--;
                                            }
                                        }

                                        /*
                                        if ((floor.position.position.x - 0.5f * floorwidth) >= worldcurpos.x ||
                                            (floor.position.position.x + 0.5f * floorwidth) <= worldcurpos.x)
                                        {
                                            //floor.ReplaceDrag(false);
                                            floor.RemoveDrag();
                                            floor.RemoveDragOffset();
                                        }
                                        else
                                        {
                                            var dis = worldcurpos.y - floor.dragOffset.offset.y;
                                            if (dis > halffloorheight * 0.5f && floor.gridID.id <= 1)
                                            {
                                                //向上
                                                floor.position.position.y = floor.position.position.y + floorheight;
                                                floor.gridID.id++;

                                            }
                                            else if (dis < -halffloorheight * 0.5f && floor.gridID.id >= 1)
                                            {
                                                //向下
                                                floor.position.position.y = floor.position.position.y - floorheight;
                                                floor.gridID.id--;
                                            }


                                            //floor.position.position.y = newy;
                                        }
                                    }
                                    //---------------------------
                                    if (!floor.hasDrag || !floor.drag.isdrag)
                                    {

                                    }*/
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (var floor in _allFloor)
                        {
                            if (floor.hasDrag)
                            {
                                floor.RemoveDrag();
                                floor.RemoveDragOffset();
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogWarning("empty");
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
