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
    private IGroup<GameEntity> _specialfloors;
    private Contexts _contexts;
    public CreateFloorSystem(Contexts contexts, Services services)
        : base(contexts.game)
    {
        _contexts = contexts;
        _gamegroup = contexts.game.GetGroup(GameMatcher.Floor);
        _specialfloors = contexts.game.GetGroup(GameMatcher.SpecialFloor);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        float width = _contexts.config.floorData.floorWidth;
        //Debug.LogWarning("Execute width" + width);
        Vector3 poslast = _contexts.config.floorData.overPos;

        GameEntity oldlastfloor = null;
        foreach (var floor in _gamegroup)
        {
            if (floor.isLastFloor)
            {
                poslast = floor.position.position;
                floor.isLastFloor = false;
                oldlastfloor = floor;
                break;
            }
        }


        //决定接下来的floor是什么
        //普通格子还是特殊 目前暂时使用70%】
        //应该在Config有个值控制普通格子概率
        var isnormal = UnityEngine.Random.Range(0.0f,1.0f);
        //应该区分下boss出现前和出现后阶段


        if(isnormal < 0.7f || _specialfloors.count == 0)
        {
            GameEntity entity = _contexts.game.CreateEntity();
            entity.isFloor = true;
            entity.isLastFloor = true;
            entity.ReplacePosition(new Vector3(
                poslast.x + width,
                poslast.y,
                poslast.z
                ));
            entity.ReplaceGridID(1);

            //难度应该是逐渐上升的 这个值控制难度
            entity.ReplaceFloorDifficulty(1);
            entity.isDestoryOnReset = true;

            if (oldlastfloor != null)
            {
                GameEntity brotherleft = null; 
                if(oldlastfloor.hasFloorBrother)
                {
                    brotherleft = oldlastfloor.floorBrother.Left;
                }
                oldlastfloor.ReplaceFloorBrother(brotherleft, entity);
                entity.ReplaceFloorBrother(oldlastfloor, null);
            }

            //对于不是特殊格子的，随机一个格子类型
            var numtype = _contexts.config.brickTable.table.NormalBrickNames.Length;
            var randindex = UnityEngine.Random.Range(0, numtype);
            string basebrickname = _contexts.config.brickTable.table.GetBrickName(0);

            var brickname = _contexts.config.brickTable.table.NormalBrickNames[randindex];
            entity.ReplaceFloorType(brickname);
        }
        else
        {
            var index = UnityEngine.Random.Range(0, _specialfloors.count);
            //如果是特殊格子 从所有特殊格子中随机一种
            var entitis = _specialfloors.GetEntities();
            var nextdata = entitis[index];
            var count = nextdata.specialFloor.floordata.GetFloorData().Length;
            foreach (var data in nextdata.specialFloor.floordata.GetFloorData())
            {
                count--;

                GameEntity entity = _contexts.game.CreateEntity();
                entity.isFloor = true;
                if(count == 0)
                {
                    entity.isLastFloor = true;
                }
                poslast += new Vector3(width,0,0);
                entity.ReplacePosition(poslast);
                entity.ReplaceGridID(1); //临时这么写 这个应该也是配置出来的
                entity.ReplaceSpecialFloorData(data);
                entity.isDestoryOnReset = true;

                if (oldlastfloor != null)
                {
                    GameEntity brotherleft = null;
                    if (oldlastfloor.hasFloorBrother)
                    {
                        brotherleft = oldlastfloor.floorBrother.Left;
                    }
                    oldlastfloor.ReplaceFloorBrother(brotherleft, entity);
                    entity.ReplaceFloorBrother(oldlastfloor,null);
                }
                oldlastfloor = entity;
            }
        }

    }

    protected override bool Filter(GameEntity entity)
    {
        bool ret = true;
        if(_contexts.game.waitAddFloorCount.count > 0)
        {
            _contexts.game.waitAddFloorCount.count--;
            ret = false;
        }
        return (_contexts.game.gameState.state == GameState.Running) && (_gamegroup.count <= _contexts.config.floorData.numFloor) && ret;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Floor.Removed());
    }
}
