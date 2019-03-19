/* ========================================================
 *	类名称：GameStartComponent
 *	作 者：Zhangfan
 *	创建时间：2019-03-18 19:26:06
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Entitas;

public class GameResetSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    readonly GameContext game;
    IGroup<GameEntity> _deleteEntitys;

    public GameResetSystem(Contexts contexts)
        : base(contexts.game)
    {
        game = contexts.game;
        _deleteEntitys = game.GetGroup(GameMatcher.DestoryOnReset);
    }

    public void Initialize()
    {
        ;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        Debug.Log("Debug reset add Execute");
        game.isReset = false;
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isReset;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        Debug.Log("Debug reset add");
        return context.CreateCollector(GameMatcher.Reset.Added());
    }
}
