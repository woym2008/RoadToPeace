using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class BossCreateSystem : ReactiveSystem<GameEntity>
{
    //string _bosspath = "";
    Contexts _contexts;
    Services _services;
    public BossCreateSystem(Contexts contexts, Services services) :
        base(contexts.game)
    {
        _contexts = contexts;   
        _services = services;
    }
    protected  override void Execute(List<GameEntity> entities)
    {
        foreach (var entity in entities)
        {
            var id = _services.Idservice.GetNext();
            var startpos = _contexts.config.bossData.startpos;
            _services.BossService.CreateBoss(id,startpos);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.bossState.state == BossState.Ready;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BossState);
    }
}
