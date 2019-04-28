using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

//用来更新缓存的当前可以随机用到的所有特殊块
public class SpecialFloorUpdate : ReactiveSystem<GameEntity>
{
    readonly private Contexts _contexts;
    readonly private Services _services;
    private IGroup<GameEntity> _groups;

    public SpecialFloorUpdate(Contexts contexts, Services services)
        : base(contexts.game)
    {
        _contexts = contexts;
        _services = services;
        _groups = _contexts.game.GetGroup(GameMatcher.SpecialFloor);
    }
    protected override void Execute(List<GameEntity> entities)
    {
        var curlevel = _contexts.game.difficulty.value;
        //保证难度上升一定等级后，一些特殊块就会被放弃，这个2是临时的，可以做成变量保存在config中
        //var minlevel = curlevel - 2;
        //minlevel = minlevel > 0 ? minlevel : 0;
        //难度发生了变化 
        foreach (var data in _groups)
        {
            var maxlevel = data.specialFloor.floordata.GetMaxLevel();
            if (maxlevel < curlevel && maxlevel < 999)
            {
                data.isDestroyed = true;
            }
        }

        var datas = _services.SpecialFloorService.GetFloorData(curlevel);
        foreach(var data in datas)
        {
            var specialfloorEntity = _contexts.game.CreateEntity();
            specialfloorEntity.ReplaceSpecialFloor(data);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasDifficulty;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Difficulty);
    }
}
