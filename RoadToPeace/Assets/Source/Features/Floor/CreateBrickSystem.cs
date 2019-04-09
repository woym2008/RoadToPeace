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
            int randType = Random.Range(0, maxtype);
            //创建三个brick
            var brick_up = _contexts.game.CreateEntity();
            var brick_mid = _contexts.game.CreateEntity();
            var brick_down = _contexts.game.CreateEntity();
            var brick_earth = _contexts.game.CreateEntity();

            int passindex = Random.Range(0, 3);

            var childbricks = new GameEntity[3];

            string suffix = "";
            brick_up.isBrick = true;
            if (entity.floorDifficulty.value > 0)
            {
                brick_up.isIsBrickPassed = (passindex == 0) ? false : true;
                suffix = (passindex == 0) ? "_Trap" : "";
            }
            else
            {
                brick_up.isIsBrickPassed = true;
                suffix = "";
            }            
            brick_up.ReplaceAsset(_contexts.config.brickTypeList.typeList[randType] + suffix, 3);
            brick_up.ReplaceBrickType(randType);
            brick_up.ReplaceBrickParent(entity);
            brick_up.ReplacePosition(new Vector3(
                entity.position.position.x,
                entity.position.position.y + _contexts.config.floorData.floorHeight,
                0
                ));
            brick_up.ReplaceBrickYOffset(_contexts.config.floorData.floorHeight);
            childbricks[0] = brick_up;

            brick_mid.isBrick = true;
            if(entity.floorDifficulty.value > 0)
            {
                brick_mid.isIsBrickPassed = (passindex == 1) ? false : true;
                suffix = (passindex == 1) ? "_Trap" : "";
            }
            else
            {
                brick_mid.isIsBrickPassed = true;
                suffix = "";
            }            
            brick_mid.ReplaceAsset(_contexts.config.brickTypeList.typeList[randType] + suffix, 3);
            brick_mid.ReplaceBrickType(randType);
            brick_mid.ReplaceBrickParent(entity);
            brick_mid.ReplacePosition(new Vector3(
                entity.position.position.x,
                entity.position.position.y,
                0
                ));
            brick_mid.ReplaceBrickYOffset(0);
            childbricks[1] = brick_mid;

            brick_down.isBrick = true;
            if (entity.floorDifficulty.value > 0)
            {
                brick_down.isIsBrickPassed = (passindex == 2) ? false : true;
                suffix = (passindex == 2) ? "_Trap" : "";
            }
            else
            {
                brick_down.isIsBrickPassed = true;
                suffix = "";
            }            
            brick_down.ReplaceAsset(_contexts.config.brickTypeList.typeList[randType] + suffix, 3);
            brick_down.ReplaceBrickType(randType);
            brick_down.ReplaceBrickParent(entity);
            brick_down.ReplacePosition(new Vector3(
                entity.position.position.x,
                entity.position.position.y - _contexts.config.floorData.floorHeight,
                0
                ));
            brick_down.ReplaceBrickYOffset(-_contexts.config.floorData.floorHeight);
            childbricks[2] = brick_down;

            //brick_up.addbr
            brick_earth.isBrick = true;
            //brick_earth.isIsBrickPassed = (passindex == 2) ? true : false;
            suffix = "_Soil";
            brick_earth.ReplaceAsset(_contexts.config.brickTypeList.typeList[randType] + suffix, 3);
            brick_earth.ReplaceBrickParent(entity);
            brick_earth.ReplacePosition(new Vector3(
                entity.position.position.x,
                entity.position.position.y - _contexts.config.floorData.floorHeight * 2.0f,
                0
                ));

            brick_earth.ReplaceBrickYOffset(-_contexts.config.floorData.floorHeight * 2.0f);

            //--------------------------------------------------------------------------------
            entity.ReplaceFloorChild(childbricks);
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
