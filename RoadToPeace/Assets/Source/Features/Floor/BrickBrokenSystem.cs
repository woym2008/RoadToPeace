using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class BrickBrokenSystem : ReactiveSystem<GameEntity>
{
    private readonly ConfigContext _configContext;
    public BrickBrokenSystem(Contexts contexts, Services services)
        : base(contexts.game)
    {
        _configContext = contexts.config;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var bricklist = _configContext.brickTypeList.typeList;
        foreach (var brick in entities)
        {
            if(brick.brickBroken.newbricktype == -1)
            {
                if (brick.hasAsset && brick.hasBrickType)
                {
                    //var basestr = bricklist[brick.brickType.value];

                    //撞坏后应该有毁坏后的样子 资源应该加个比如说“_broken”的后缀
                    //不过目前暂时就撞成最初的样子就行
                    //brick.ReplaceAsset(basestr, brick.asset.sortid);
                }
            }
            else
            {
                if(brick.hasAsset)
                {
                    var basestr = bricklist[brick.brickBroken.newbricktype];
                    brick.ReplaceAsset(basestr, brick.asset.sortid);
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
        return context.CreateCollector(GameMatcher.BrickBroken);
    }
}
