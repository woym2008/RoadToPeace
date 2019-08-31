﻿using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

//这个类的目的是 在boss阶段通知floor创建一个新的floor，但是要标记一下，下次删了一个floor并不立刻创建一个floor

public class ShipBossCreateFloorSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    private Services _services;

    private IGroup<GameEntity> _gamegroup;

    private IGroup<GameEntity> _specialfloors;

    public ShipBossCreateFloorSystem(Contexts contents, Services services):
        base(contents.game)
    {
        _contexts = contents;
        _services = services;

        _gamegroup = _contexts.game.GetGroup(GameMatcher.Floor);
        _specialfloors = _contexts.game.GetGroup(GameMatcher.SpecialFloor);
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            //创建missile
            //if(entity.isCreateMissileFloor)
            //{
                 
            //}
            //创建block
            //else
            {
                var floorentity = _contexts.game.CreateEntity();

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
                floorentity.isFloor = true;
                floorentity.isLastFloor = true;
                floorentity.ReplacePosition(new Vector3(
                    poslast.x + width,
                    poslast.y,
                    poslast.z
                    ));
                floorentity.ReplaceGridID(1);

                floorentity.ReplaceFloorDifficulty(1);
                floorentity.isDestoryOnReset = true;

                if (oldlastfloor != null)
                {
                    GameEntity brotherleft = null;
                    if (oldlastfloor.hasFloorBrother)
                    {
                        brotherleft = oldlastfloor.floorBrother.Left;
                    }
                    oldlastfloor.ReplaceFloorBrother(brotherleft, floorentity);
                    floorentity.ReplaceFloorBrother(oldlastfloor, null);
                }

                //对于不是特殊格子的，随机一个格子类型
                //var numtype = _contexts.config.brickTable.table.NormalBrickNames.Length;
                //var randindex = UnityEngine.Random.Range(1, numtype);

                //var brickname = _contexts.config.brickTable.table.NormalBrickNames[randindex];
                if (entity.isIsLazerTowerFloor)
                {
                    bool isblock = UnityEngine.Random.Range(0, 100) > 90;
                    if (isblock)
                    {
                        floorentity.ReplaceFloorType("Mech_Block");
                    }
                    else
                    {
                        floorentity.ReplaceFloorType("Mech");
                    }

                    var towerEntity = _contexts.game.CreateEntity();
                    towerEntity.AddObjectParent(floorentity);
                    towerEntity.isLazerTower = true;
                }
                else if (entity.isIsBlockLazerFloor)
                {
                    floorentity.ReplaceFloorType("Mech_Battery");
                }
                else if(entity.isMissileFloor)
                {
                    var missilefloor_2 = _contexts.game.CreateEntity();
                    var missilefloor_3 = _contexts.game.CreateEntity();

                    floorentity.ReplaceFloorType("Mech_MissileHead");
                    floorentity.isLastFloor = false;
                    GameEntity brotherleft = null;
                    if (floorentity.hasFloorBrother)
                    {
                        brotherleft = floorentity.floorBrother.Left;
                    }
                    floorentity.ReplaceFloorBrother(brotherleft, missilefloor_2);
                    missilefloor_2.ReplaceFloorBrother(floorentity, missilefloor_3);
                    missilefloor_3.ReplaceFloorBrother(missilefloor_2, null);

                    missilefloor_2.isFloor = true;
                    missilefloor_2.ReplacePosition(new Vector3(
                        poslast.x + width*2,
                        poslast.y,
                        poslast.z
                        ));
                    missilefloor_2.ReplaceGridID(1);

                    missilefloor_2.ReplaceFloorDifficulty(1);
                    missilefloor_2.isDestoryOnReset = true;


                    missilefloor_2.ReplaceFloorType("Mech_MissileMiddle");


                    missilefloor_3.isFloor = true;
                    missilefloor_3.isLastFloor = true;
                    missilefloor_3.ReplacePosition(new Vector3(
                        poslast.x + width * 3,
                        poslast.y,
                        poslast.z
                        ));
                    missilefloor_3.ReplaceGridID(1);

                    missilefloor_3.ReplaceFloorDifficulty(1);
                    missilefloor_3.isDestoryOnReset = true;
                    missilefloor_3.ReplaceFloorType("Mech_MissileTail");
                    missilefloor_3.isLastFloor = true;
                }
                else
                {
                    floorentity.ReplaceFloorType("Mech");
                }
            }

            entity.isDestroyed = true;
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

