using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class FirstCreatGroundSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public FirstCreatGroundSystem(Contexts contexts, Services services)
        : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var curpos = _contexts.config.groundData.firstPos;

        for (int i = 0; i < _contexts.config.groundData.numGround; ++i)
        {
            var groundEntity = _contexts.game.CreateEntity();
            groundEntity.isDestoryOnReset = true;            
            groundEntity.isGround = true;
            groundEntity.ReplacePosition(curpos);
            //var index = Random.Range(0, _contexts.config.groundList.groundList.Count);
            //var path = _contexts.config.groundList.groundList[index];
            //groundEntity.ReplaceAsset(path,0);

            if (i == (_contexts.config.groundData.numGround - 1))
            {
                groundEntity.isLastGround = true;
            }

            curpos = curpos + new Vector3(
                _contexts.config.groundData.groundWidth,
                0,
                0
                );

            //Debug.Log("width: " + curpos);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        //return !_contexts.game.isGameOver;
        return (_contexts.game.gameState.state == GameState.Ready);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        //return context.CreateCollector(GameMatcher.GameStart);
        return context.CreateCollector(GameMatcher.GameState);
    }
}
