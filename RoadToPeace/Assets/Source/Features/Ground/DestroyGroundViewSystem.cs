using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class DestroyGroundViewSystem : ReactiveSystem<GameEntity>
{
    Contexts _contexts;
    Services _services;
    IGroup<GameEntity> _views;

    public DestroyGroundViewSystem(Contexts contexts, Services services) :
        base(contexts.game)
    {
        _contexts = contexts;
        _services = services;

        _views = _contexts.game.GetGroup(GameMatcher.GroundView);
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var ground in entities)
        {
            foreach (var entity in _views)
            {
                if (entity.groundParent.parent == ground)
                {
                    //Debug.Log(brickentity);

                    entity.isDestroyed = true;
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Ground.Removed());
    }
}
