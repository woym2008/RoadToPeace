/* ========================================================
 *	类名称：DestoryFloorSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-22 14:59:27
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

public class DestoryFloorSystem : ReactiveSystem<GameEntity>
{
    IGroup<GameEntity> _entityGroup;
    public DestoryFloorSystem(Contexts contexts, Services services)
        : base(contexts.game)
    {
        _entityGroup = contexts.game.GetGroup(GameMatcher.Brick);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            foreach(var brickentity in _entityGroup)
            {
                if(brickentity.brickParent.parent == entity)
                {
                    //Debug.Log(brickentity);
                    brickentity.isDestroyed = true;
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        Debug.Log("On Trigger Removed");
        return context.CreateCollector(GameMatcher.Floor.Removed());
    }
}
