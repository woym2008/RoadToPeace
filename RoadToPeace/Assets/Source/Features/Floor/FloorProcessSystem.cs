using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class FloorProcessSystem : ReactiveSystem<GameEntity>
{
    Contexts _contexts;
    public FloorProcessSystem(Contexts contexts) :
        base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if(_contexts.game.gameState.state == GameState.Running)
        {
            if(!_contexts.game.hasFloorCount)
            {
                _contexts.game.SetFloorCount(0);
            }
            _contexts.game.floorCount.value++;

            if(_contexts.game.floorCount.value >= 50)
            {
                _contexts.game.isBossFighting = true;
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {   
            return (_contexts.game.isBossFighting == false);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Floor.Added());
    }
}
