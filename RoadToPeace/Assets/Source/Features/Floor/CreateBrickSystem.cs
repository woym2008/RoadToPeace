/* ========================================================
 *	类名称：CreateBrickSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-21 19:07:45
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;
using UnityEngine;

public class CreateBrickSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public CreateBrickSystem(Contexts contexts, Services services)
        : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        //var maxtype = _contexts.config.brickTypeCount.value;
        var maxtype = _contexts.config.brickTypeList.typeList.Count;

        foreach (var entity in entities)
        {            
            //创建三个brick
            var brick_up = _contexts.game.CreateEntity();
            var brick_mid = _contexts.game.CreateEntity();
            var brick_down = _contexts.game.CreateEntity();

            int passindex = Random.Range(0, 3);
            brick_up.isBrick = true;
            //brick_up.ReplaceAsset((passindex&1));
            brick_up.ReplaceBrickParent(entity);
            brick_mid.isBrick = true;
            brick_mid.ReplaceBrickParent(entity);
            brick_down.isBrick = true;
            brick_down.ReplaceBrickParent(entity);
            //brick_up.addbr

            //Random.Range(0, count);

            //brick_up.asset.name = ;
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Floor.Added());
    }
}
