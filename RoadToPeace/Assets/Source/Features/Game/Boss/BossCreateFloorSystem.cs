using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

//这个类的目的是 在boss阶段通知floor创建一个新的floor，但是要标记一下，下次删了一个floor并不立刻创建一个floor

public class ShipBossCreateFloorSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private Services _services;

    private IGroup<GameEntity> _gamegroup;

    public ShipBossCreateFloorSystem(Contexts contents, Services services):
        base(contents.game)
    {
        _contexts = contents;
        _services = services;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            _contexts.game.waitAddFloorCount.count++;
            Vector3 poslast = _contexts.config.floorData.overPos;

            float width = _contexts.config.floorData.floorWidth;

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

            //GameEntity entity = _contexts.game.CreateEntity();
            entity.isFloor = true;
            entity.isLastFloor = true;
            entity.ReplacePosition(new Vector3(
                poslast.x + width,
                poslast.y,
                poslast.z
                ));
            entity.ReplaceGridID(1);

            entity.ReplaceFloorDifficulty(1);
            entity.isDestoryOnReset = true;

            if (oldlastfloor != null)
            {
                GameEntity brotherleft = null;
                if (oldlastfloor.hasFloorBrother)
                {
                    brotherleft = oldlastfloor.floorBrother.Left;
                }
                oldlastfloor.ReplaceFloorBrother(brotherleft, entity);
                entity.ReplaceFloorBrother(oldlastfloor, null);
            }

            //对于不是特殊格子的，随机一个格子类型
            //var numtype = _contexts.config.brickTable.table.NormalBrickNames.Length;
            //var randindex = UnityEngine.Random.Range(1, numtype);

            //var brickname = _contexts.config.brickTable.table.NormalBrickNames[randindex];
            if(entity.isIsLazerTowerFloor)
            {
                bool isblock = UnityEngine.Random.Range(0, 100) > 90;
                if(isblock)
                {
                    entity.ReplaceFloorType("Mech_Block");
                }
                else
                {
                    entity.ReplaceFloorType("Mech");
                }

                var towerEntity = _contexts.game.CreateEntity();
                towerEntity.AddObjectParent(entity);
                towerEntity.isLazerTower = true;
            }
            else if(entity.isIsBlockLazerFloor)
            {
                entity.ReplaceFloorType("Mech_Battery");
            }
            else
            {
                entity.ReplaceFloorType("Mech");
            }
        }

    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BossCreateFloor.Added());
    }
}

