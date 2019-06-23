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
            //var brick_earth = _contexts.game.CreateEntity();
            brick_up.isDestoryOnReset = true;
            brick_mid.isDestoryOnReset = true;
            brick_down.isDestoryOnReset = true;
            //brick_earth.isDestoryOnReset = true;
            brick_up.isBrick = true;
            brick_mid.isBrick = true;
            brick_down.isBrick = true;
            //brick_earth.isBrick = true;
            var childbricks = new GameEntity[3];
            childbricks[0] = brick_up;
            childbricks[1] = brick_mid;
            childbricks[2] = brick_down;
            entity.ReplaceFloorChild(childbricks);

            //定制的还是随机的
            if (entity.hasSpecialFloorData)
            {
                var data = entity.specialFloorData.data;
                var ex_upstr = data.brick1_data == "" ? "" : "_";
                var up_resstr = string.Format("{0}{1}{2}{3}", "Brick/", _contexts.config.brickTypeList.typeList[data.type], ex_upstr, data.brick1_data);
                var ex_midstr = data.brick2_data == "" ? "" : "_";
                var mid_resstr = string.Format("{0}{1}{2}{3}", "Brick/",_contexts.config.brickTypeList.typeList[data.type], ex_midstr, data.brick2_data);
                var ex_downstr = data.brick3_data == "" ? "" : "_";
                var down_resstr = string.Format("{0}{1}{2}{3}", "Brick/",_contexts.config.brickTypeList.typeList[data.type], ex_downstr, data.brick3_data);
                //var earth_resstr = string.Format("{0}{1}_{2}", "Brick/",_contexts.config.brickTypeList.typeList[data.type], "Soil");
                Debug.Log("up:" + up_resstr);
                Debug.Log("mid:" + mid_resstr);
                Debug.Log("down:" + down_resstr);
                //Debug.Log("earth:" + earth_resstr);

                brick_up.ReplaceAsset(up_resstr, 3);
                brick_up.ReplaceBrickType(data.type);
                brick_up.ReplaceBrickParent(entity);
                brick_up.ReplacePosition(new Vector3(
                    entity.position.position.x,
                    entity.position.position.y + _contexts.config.floorData.floorHeight,
                    0
                    ));
                brick_up.ReplaceBrickYOffset(_contexts.config.floorData.floorHeight);
                //brick_up.isIsBrickPassed = !checkIsTrap(data.brick1_data);
                brick_up.ReplaceWayOfPassBrick(CheckPassWay(data.brick1_data));

                brick_mid.ReplaceAsset(mid_resstr, 3);
                brick_mid.ReplaceBrickType(data.type);
                brick_mid.ReplaceBrickParent(entity);
                brick_mid.ReplacePosition(new Vector3(
                    entity.position.position.x,
                    entity.position.position.y,
                    0
                    ));
                brick_mid.ReplaceBrickYOffset(0);
                //brick_mid.isIsBrickPassed = !checkIsTrap(data.brick2_data);
                brick_mid.ReplaceWayOfPassBrick(CheckPassWay(data.brick2_data));

                brick_down.ReplaceAsset(down_resstr, 3);
                brick_down.ReplaceBrickType(data.type);
                brick_down.ReplaceBrickParent(entity);
                brick_down.ReplacePosition(new Vector3(
                    entity.position.position.x,
                    entity.position.position.y - _contexts.config.floorData.floorHeight,
                    0
                    ));
                brick_down.ReplaceBrickYOffset(-_contexts.config.floorData.floorHeight);
                //brick_down.isIsBrickPassed = !checkIsTrap(data.brick3_data);
                brick_down.ReplaceWayOfPassBrick(CheckPassWay(data.brick3_data));
                /*
                brick_earth.ReplaceAsset(earth_resstr, 3);
                brick_earth.ReplaceBrickParent(entity);
                brick_earth.ReplacePosition(new Vector3(
                    entity.position.position.x,
                    entity.position.position.y - _contexts.config.floorData.floorHeight * 2.0f,
                    0
                    ));

                brick_earth.ReplaceBrickYOffset(-_contexts.config.floorData.floorHeight * 2.0f);
                */               
            }
            else
            {
                int randType = Random.Range(0, maxtype);

                int passindex = Random.Range(0, 3);



                string suffix = "";
                brick_up.isBrick = true;
                if (entity.floorDifficulty.value > 0)
                {
                    //brick_up.isIsBrickPassed = (passindex == 0) ? false : true;
                    suffix = (passindex == 0) ? "_Trap" : "";
                    brick_up.ReplaceWayOfPassBrick(CheckPassWay(suffix));
                }
                else
                {
                    //brick_up.isIsBrickPassed = true;
                    brick_up.ReplaceWayOfPassBrick(PassBrickWay.Run);
                    suffix = "";
                }
                brick_up.ReplaceAsset( _contexts.config.brickTypeList.typeList[randType] + suffix, 3);
                brick_up.ReplaceBrickType(randType);
                brick_up.ReplaceBrickParent(entity);
                brick_up.ReplacePosition(new Vector3(
                    entity.position.position.x,
                    entity.position.position.y,
                    entity.position.position.z + _contexts.config.floorData.floorHeight
                    ));
                brick_up.ReplaceBrickYOffset(_contexts.config.floorData.floorHeight);


                brick_mid.isBrick = true;
                if (entity.floorDifficulty.value > 0)
                {
                    //brick_mid.isIsBrickPassed = (passindex == 1) ? false : true;
                    suffix = (passindex == 1) ? "_Trap" : "";
                    brick_mid.ReplaceWayOfPassBrick(CheckPassWay(suffix));
                }
                else
                {
                    //brick_mid.isIsBrickPassed = true;
                    brick_mid.ReplaceWayOfPassBrick(PassBrickWay.Run);
                    suffix = "";
                }
                brick_mid.ReplaceAsset( _contexts.config.brickTypeList.typeList[randType] + suffix, 3);
                brick_mid.ReplaceBrickType(randType);
                brick_mid.ReplaceBrickParent(entity);
                brick_mid.ReplacePosition(new Vector3(
                    entity.position.position.x,
                    entity.position.position.y,
                    entity.position.position.z
                    ));
                brick_mid.ReplaceBrickYOffset(0);

                brick_down.isBrick = true;
                if (entity.floorDifficulty.value > 0)
                {
                    //brick_down.isIsBrickPassed = (passindex == 2) ? false : true;
                    suffix = (passindex == 2) ? "_Trap" : "";
                    brick_down.ReplaceWayOfPassBrick(CheckPassWay(suffix));
                }
                else
                {
                    //brick_down.isIsBrickPassed = true;
                    brick_down.ReplaceWayOfPassBrick(PassBrickWay.Run);
                    suffix = "";
                }
                brick_down.ReplaceAsset( _contexts.config.brickTypeList.typeList[randType] + suffix, 3);
                brick_down.ReplaceBrickType(randType);
                brick_down.ReplaceBrickParent(entity);
                brick_down.ReplacePosition(new Vector3(
                    entity.position.position.x,
                    entity.position.position.y,
                    entity.position.position.z - _contexts.config.floorData.floorHeight
                    ));
                brick_down.ReplaceBrickYOffset(-_contexts.config.floorData.floorHeight);
                /*
                //brick_up.addbr
                /brick_earth.isBrick = true;
                //brick_earth.isIsBrickPassed = (passindex == 2) ? true : false;
                suffix = "_Soil";
                brick_earth.ReplaceAsset( _contexts.config.brickTypeList.typeList[randType] + suffix, 3);
                brick_earth.ReplaceBrickParent(entity);
                brick_earth.ReplacePosition(new Vector3(
                    entity.position.position.x,
                    entity.position.position.y - _contexts.config.floorData.floorHeight * 2.0f,
                    0
                    ));

                brick_earth.ReplaceBrickYOffset(-_contexts.config.floorData.floorHeight * 2.0f);
                */
                //--------------------------------------------------------------------------------

            }

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

    private PassBrickWay CheckPassWay(string name)
    {
        switch(name)
        {
            case "_Jump":
                return PassBrickWay.Jump;
                break;
            case "_Trap":
                return PassBrickWay.Collision;
                break;
            case "_Electrocution":
                return PassBrickWay.Electrocution;
                break;
            case "Jump":
                return PassBrickWay.Jump;
                break;
            case "Trap":
                return PassBrickWay.Collision;
                break;
            case "Electrocution":
                return PassBrickWay.Electrocution;
                break;
        }

        return PassBrickWay.Run;
    }
}
