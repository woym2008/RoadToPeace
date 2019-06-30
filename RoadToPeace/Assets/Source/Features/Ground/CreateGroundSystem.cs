using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class CreateGroundSystem : ReactiveSystem<GameEntity>
{
    private IGroup<GameEntity> _groundgroup;
    private Contexts _contexts;
    public CreateGroundSystem(Contexts contexts, Services services)
        : base(contexts.game)
    {
        _contexts = contexts;
        _groundgroup = contexts.game.GetGroup(GameMatcher.Ground);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        float width = _contexts.config.groundData.groundWidth;
        Vector3 poslast = _contexts.config.groundData.overPos;
        foreach (var g in _groundgroup)
        {
            if (g.isLastGround)
            {
                poslast = g.position.position;
                g.isLastGround = false;
                break;
            }
        }

        GameEntity entity = _contexts.game.CreateEntity();
        entity.isGround = true;

        var index = Random.Range(0, _contexts.config.groundList.groundList.Count);
        var path = _contexts.config.groundList.groundList[index];
        entity.ReplaceAsset(path, 0);

        poslast += new Vector3(width, 0, 0);
        entity.ReplacePosition(poslast);
        entity.isLastGround = true;
        entity.isDestoryOnReset = true;
    }

    protected override bool Filter(GameEntity entity)
    {
        return (_contexts.game.gameState.state == GameState.Running) && (_groundgroup.count <= _contexts.config.groundData.numGround);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Ground.Removed());
    }
}
