/* ========================================================
 *	类名称：FirstCreateFloorSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-25 16:11:59
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

public class FirstCreateFloorSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public FirstCreateFloorSystem(Contexts contexts, Services services)
        : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var curpos = _contexts.config.floorData.firstPos;

        for(int i = 0; i < _contexts.config.floorData.numFloor; ++i)
        {
            var floorEntity = _contexts.game.CreateEntity();
            floorEntity.isDestoryOnReset = true;
            floorEntity.isFloor = true;
            floorEntity.ReplacePosition(curpos);
            floorEntity.ReplaceGridID(1);
            floorEntity.ReplaceFloorDifficulty(0);

            if ( i == (_contexts.config.floorData.numFloor - 1) )
            {
                floorEntity.isLastFloor = true;
            }

            curpos = curpos + new Vector3(
                _contexts.config.floorData.floorWidth,
                0,
                0
                );

            //Debug.Log("width: " + curpos);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        //return !_contexts.game.isGameOver;
        return (_contexts.game.gameState.state == GameState.Ready);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        //return context.CreateCollector(GameMatcher.GameStart);
        return context.CreateCollector(GameMatcher.GameState);
    }
}
