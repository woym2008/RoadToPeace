/* ========================================================
 *	类名称：MoveFloorSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-22 14:53:40
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

public class MoveFloorSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly Services _services;
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _floorgroup;

    List<GameEntity> listtest = new List<GameEntity>();

    public MoveFloorSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _services = services;
        _game = _contexts.game;
        _floorgroup = contexts.game.GetGroup(GameMatcher.Floor);
    }

    public void Execute()
    {
        var player = _contexts.game.playerEntity;
        if(player != null && player.hasPosition)
        {
            if(_game.hasGameState && _game.gameState.state == GameState.Running)
            {
                var floors = _floorgroup.GetEntities();
                _floorgroup.GetEntities(listtest);
                int testnum = _floorgroup.count;
                foreach (var floorentity in listtest)
                {
                    if(_floorgroup.count != testnum)
                    {
                        //Debug.Log("push one entity");
                    }
                    //if (floorentity.hasPosition)
                    //if(floorentity.isDrag == true)
                    {
                        floorentity.position.position.x -= _contexts.game.floorSpeed.value * Time.fixedDeltaTime;

                        if (floorentity.position.position.x < _contexts.config.floorData.overPos.x)
                        {
                            floorentity.isFloor = false;
                            floorentity.isDestroyed = true;
                            //减去一个entity 再创建一个新的
                            Debug.Log("Destory one floor");
                            continue;                            
                        }

                        //floorentity.isDrag = false;
                    }
                }

                //foreach (var floorentity in listtest)
                //{
                    //floorentity.isDrag = true;
                //}
            }
            
        }
    }
}
