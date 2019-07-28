using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class CreateMissileBrickSystem : ReactiveSystem<GameEntity>
{
    Contexts _contexts;
    Services _services;
    BrickTable _table;
    public CreateMissileBrickSystem(Contexts contexts, Services services) :
        base(contexts.game)

    {
        _contexts = contexts;
        _services = services;
        _table = _contexts.config.brickTable.table;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            var parentfloor = entity.brickParent.parent;
            //parentfloor.
            int missilepos = 0;
            GameEntity premissile = null;

            if(parentfloor.hasFloorBrother)
            {
                var left = parentfloor.floorBrother.Left;
                if (left != null)
                {
                    var bricks = left.floorChild.childs;
                    foreach (var b in bricks)
                    {
                        if (b.hasMissile)
                        {
                            b.ReplaceMissile(
                            b.missile.selfmissilepos,
                            b.missile.preMissileBrick,
                            entity
                            );

                            premissile = b;

                            break;
                        }
                    }
                }
            }


            //var brickname = _table.GetBrickName(entity.brickType.value);
            var brickname = entity.brickName.name;
            switch (brickname)
            {
                case "Mech_MissileHead":
                    {
                        missilepos = 0;
                    }
                    break;
                case "Mech_MissileMiddle":
                    {
                        missilepos = 1;
                    }
                    break;
                case "Mech_MissileTail":
                    {
                        missilepos = 2;
                    }
                    break;
            }
            entity.ReplaceMissile(
            missilepos,
            premissile,
            null
                );
        }

    }

    protected override bool Filter(GameEntity entity)
    {
        //var brickname = _table.GetBrickName(entity.brickType.value);
        var brickname = entity.brickName.name;
        Debug.Log(brickname);
        return _contexts.game.gameState.state == GameState.Running&&(brickname == "Mech_MissileHead" || brickname == "Mech_MissileMiddle" || brickname == "Mech_MissileTail");
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BrickName.Added());
    }
}
