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
        var maxnormaltype = _contexts.config.normalBrickTypeList.typeList.Count;

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

            var basebricktype = _contexts.config.brickTypeList.typeList[0];

            //定制的还是随机的
            if (entity.hasSpecialFloorData)
            {
                var data = entity.specialFloorData.data;
                /*
                var ex_upstr = data.brick1_data == "" ? "" : "_";
                var up_resstr = string.Format("{0}{1}{2}{3}", "Brick/", _contexts.config.brickTypeList.typeList[data.type], ex_upstr, data.brick1_data);
                var ex_midstr = data.brick2_data == "" ? "" : "_";
                var mid_resstr = string.Format("{0}{1}{2}{3}", "Brick/",_contexts.config.brickTypeList.typeList[data.type], ex_midstr, data.brick2_data);
                var ex_downstr = data.brick3_data == "" ? "" : "_";
                var down_resstr = string.Format("{0}{1}{2}{3}", "Brick/",_contexts.config.brickTypeList.typeList[data.type], ex_downstr, data.brick3_data);
                */
                var up_resstr = data.brick1_data == "" ? basebricktype : string.Format("{0}{1}", "Brick/", data.brick1_data);
                //var up_resstr = string.Format("{0}{1}", "Brick/", ex_upstr);
                var mid_resstr = data.brick2_data == "" ? basebricktype : string.Format("{0}{1}", "Brick/", data.brick2_data);
                //var mid_resstr = string.Format("{0}{1}", "Brick/",ex_midstr);
                var down_resstr = data.brick3_data == "" ? basebricktype : string.Format("{0}{1}", "Brick/", data.brick3_data);
                //var down_resstr = string.Format("{0}{1}", "Brick/", ex_downstr);
                //var earth_resstr = string.Format("{0}{1}_{2}", "Brick/",_contexts.config.brickTypeList.typeList[data.type], "Soil");
                Debug.Log("up:" + up_resstr);
                Debug.Log("mid:" + mid_resstr);
                Debug.Log("down:" + down_resstr);
                //Debug.Log("earth:" + earth_resstr);

                brick_up.ReplaceAsset(up_resstr, 3);
                brick_up.ReplaceBrickType(data.brick1_data);
                brick_up.ReplaceBrickParent(entity);
                brick_up.ReplacePosition(new Vector3(
                    entity.position.position.x,
                    entity.position.position.y + _contexts.config.floorData.floorHeight,
                    0
                    ));
                brick_up.ReplaceBrickYOffset(_contexts.config.floorData.floorHeight);
                //brick_up.isIsBrickPassed = !checkIsTrap(data.brick1_data);
                brick_up.ReplaceWayOfPassBrick(CheckPassWay(data.brick1_data));
                brick_up.ReplaceBrickIndex(0);
                brick_up.ReplaceBrickName(data.brick1_data);

                brick_mid.ReplaceAsset(mid_resstr, 3);
                brick_mid.ReplaceBrickType(data.brick2_data);
                brick_mid.ReplaceBrickParent(entity);
                brick_mid.ReplacePosition(new Vector3(
                    entity.position.position.x,
                    entity.position.position.y,
                    0
                    ));
                brick_mid.ReplaceBrickYOffset(0);
                //brick_mid.isIsBrickPassed = !checkIsTrap(data.brick2_data);
                brick_mid.ReplaceWayOfPassBrick(CheckPassWay(data.brick2_data));
                brick_mid.ReplaceBrickIndex(1);
                brick_mid.ReplaceBrickName(data.brick2_data);

                brick_down.ReplaceAsset(down_resstr, 3);
                brick_down.ReplaceBrickType(data.brick3_data);
                brick_down.ReplaceBrickParent(entity);
                brick_down.ReplacePosition(new Vector3(
                    entity.position.position.x,
                    entity.position.position.y - _contexts.config.floorData.floorHeight,
                    0
                    ));
                brick_down.ReplaceBrickYOffset(-_contexts.config.floorData.floorHeight);
                //brick_down.isIsBrickPassed = !checkIsTrap(data.brick3_data);
                brick_down.ReplaceWayOfPassBrick(CheckPassWay(data.brick3_data));
                brick_down.ReplaceBrickIndex(2);
                brick_down.ReplaceBrickName(data.brick3_data);
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
                var basestr = _contexts.config.brickResBase.basestr;
                var type = entity.floorType.type;
                //int randType = Random.Range(0, maxnormaltype);
                int randindex = Random.Range(0,3);
                //int randdiff = (int)Random.Range(0, entity.floorDifficulty.value);

                //int passindex = Random.Range(0, 3+ 5);
                string basebrickname = _contexts.config.brickTable.table.GetBrickName(0);

                string suffix = "";
                brick_up.isBrick = true;
                if (entity.floorDifficulty.value > 0)
                {
                    //brick_up.isIsBrickPassed = (passindex == 0) ? false : true;
                    suffix = (randindex == 0) ? type : basebrickname;
                    brick_up.ReplaceWayOfPassBrick(CheckPassWay(suffix));
                }
                else
                {
                    //brick_up.isIsBrickPassed = true;
                    brick_up.ReplaceWayOfPassBrick(PassBrickWay.Run);
                    suffix = basebrickname;
                }
                //brick_up.ReplaceAsset( _contexts.config.brickTypeList.typeList[randType] + suffix, 3);
                brick_up.ReplaceAsset(basestr + suffix, 3);
                brick_up.ReplaceBrickType(suffix);
                brick_up.ReplaceBrickParent(entity);
                brick_up.ReplacePosition(new Vector3(
                    entity.position.position.x,
                    entity.position.position.y,
                    entity.position.position.z + _contexts.config.floorData.floorHeight
                    ));
                brick_up.ReplaceBrickYOffset(_contexts.config.floorData.floorHeight);
                brick_up.ReplaceBrickIndex(0);
                brick_up.ReplaceBrickName(suffix);

                brick_mid.isBrick = true;
                if (entity.floorDifficulty.value > 0)
                {
                    //brick_mid.isIsBrickPassed = (passindex == 1) ? false : true;
                    suffix = (randindex == 1) ? type : basebrickname;
                    brick_mid.ReplaceWayOfPassBrick(CheckPassWay(suffix));
                }
                else
                {
                    //brick_mid.isIsBrickPassed = true;
                    brick_mid.ReplaceWayOfPassBrick(PassBrickWay.Run);
                    suffix = basebrickname;
                }
                //brick_mid.ReplaceAsset( _contexts.config.brickTypeList.typeList[randType] + suffix, 3);
                brick_mid.ReplaceAsset(basestr + suffix, 3);
                brick_mid.ReplaceBrickType(suffix);
                brick_mid.ReplaceBrickParent(entity);
                brick_mid.ReplacePosition(new Vector3(
                    entity.position.position.x,
                    entity.position.position.y,
                    entity.position.position.z
                    ));
                brick_mid.ReplaceBrickYOffset(0);
                brick_mid.ReplaceBrickIndex(1);
                brick_mid.ReplaceBrickName(suffix);

                brick_down.isBrick = true;
                if (entity.floorDifficulty.value > 0)
                {
                    //brick_down.isIsBrickPassed = (passindex == 2) ? false : true;
                    suffix = (randindex == 2) ? type : basebrickname;
                    brick_down.ReplaceWayOfPassBrick(CheckPassWay(suffix));
                }
                else
                {
                    //brick_down.isIsBrickPassed = true;
                    brick_down.ReplaceWayOfPassBrick(PassBrickWay.Run);
                    suffix = basebrickname;
                }
                //brick_down.ReplaceAsset( _contexts.config.brickTypeList.typeList[randType] + suffix, 3);
                brick_down.ReplaceAsset(basestr + suffix, 3);
                brick_down.ReplaceBrickType(suffix);
                brick_down.ReplaceBrickParent(entity);
                brick_down.ReplacePosition(new Vector3(
                    entity.position.position.x,
                    entity.position.position.y,
                    entity.position.position.z - _contexts.config.floorData.floorHeight
                    ));
                brick_down.ReplaceBrickYOffset(-_contexts.config.floorData.floorHeight);
                brick_down.ReplaceBrickIndex(2);
                brick_down.ReplaceBrickName(suffix);
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
            case "Mech_Jump":
                return PassBrickWay.Jump;
                break;
            case "Mech_Trap":
                return PassBrickWay.Collision;
                break;
            case "Mech_Electrocution":
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
            case "Mech_Battery":
                return PassBrickWay.AirCollision;
            case "Mech_Block":
                return PassBrickWay.AirCollision;
            case "Mech_MissileTail":
            case "Mech_MissileMiddle":
            case "Mech_MissileHead":
                return PassBrickWay.AirCollision;
        }

        return PassBrickWay.Run;
    }
}
