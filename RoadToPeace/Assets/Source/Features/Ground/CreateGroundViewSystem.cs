using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class CreateGroundViewSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public CreateGroundViewSystem(Contexts contexts, Services services)
        : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var view_up = _contexts.game.CreateEntity();
            var view_down = _contexts.game.CreateEntity();

            view_up.isGroundView = true;
            view_up.isDestoryOnReset = true;
            view_down.isGroundView = true;
            view_down.isDestoryOnReset = true;

            var childs = new GameEntity[2];
            childs[0] = view_up;
            childs[1] = view_down;

            //entity.ReplaceGroundChild(childs);

            var height = _contexts.config.groundData.groundHeight;

            var index = Random.Range(0, _contexts.config.groundList.groundList.Count);
            var path = _contexts.config.groundList.groundList[index];
            view_up.ReplaceAsset(path, 0);
            view_up.ReplacePosition(entity.position.position + new Vector3(0, 0, height*0.5f));
            view_up.ReplaceGroundParent(entity);

            index = Random.Range(0, _contexts.config.groundList.groundList.Count);
            path = _contexts.config.groundList.groundList[index];
            view_down.ReplaceAsset(path, 0);
            view_down.ReplacePosition(entity.position.position + new Vector3(0, 0, -height * 0.5f));
            view_down.ReplaceGroundParent(entity);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Ground.Added());
    }
}
