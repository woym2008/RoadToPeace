/* ========================================================
 *	类名称：CreateFloorSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-22 14:42:30
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

public class CreateFloorSystem : ReactiveSystem<GameEntity>
{
    private IGroup<GameEntity> _gamegroup;
    private Contexts _contexts;
    public CreateFloorSystem(Contexts contexts, Services services)
        : base(contexts.game)
    {
        _contexts = contexts;
        _gamegroup = contexts.game.GetGroup(GameMatcher.Floor);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        float width = _contexts.config.floorData.floorWidth;
        Vector3 poslast = _contexts.config.floorData.overPos;
        foreach (var floor in _gamegroup)
        {
            if (floor.isLastFloor)
            {
                poslast = floor.position.position;
                floor.isLastFloor = false;
                break;
            }
        }
        GameEntity entity = _contexts.game.CreateEntity();
        entity.isFloor = true;
        entity.isLastFloor = true;
        entity.ReplacePosition(new Vector3(
            poslast.x + width,
            poslast.y,
            poslast.z
            ));
    }

    protected override bool Filter(GameEntity entity)
    {
        return !_contexts.game.isGameOver;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Floor.Removed());
    }
}
