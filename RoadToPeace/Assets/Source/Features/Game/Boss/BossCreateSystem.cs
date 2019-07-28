using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class BossCreateSystem : ReactiveSystem<GameEntity>
{
    public BossCreateSystem(Contexts contexts, Services services) :
        base(contexts.game)
    {
        ;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            //entity.
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Boss.Added());
    }
}
