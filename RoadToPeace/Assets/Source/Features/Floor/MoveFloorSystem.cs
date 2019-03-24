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

public class MoveFloorSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly Services _services;
    private readonly IGroup<GameEntity> _floorgroup;

    public MoveFloorSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _services = services;
        _floorgroup = contexts.game.GetGroup(GameMatcher.Floor);
    }

    public void Execute()
    {
        var player = _contexts.game.playerEntity;
        if(player != null && player.hasPosition)
        {
            foreach(var floorentity in _floorgroup)
            {
                if(floorentity.hasPosition)
                {
                    floorentity.position.position.x += _contexts.game.floorSpeed.value;

                    if (floorentity.position.position.x < _contexts.config.roadBoundary.left)
                    {
                        floorentity.isDestroyed = true;
                        //减去一个entity 再创建一个新的

                    }
                }
            }
        }
    }
}
