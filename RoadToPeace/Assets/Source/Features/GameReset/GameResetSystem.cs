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
    Services _services;

    public GameResetSystem(Contexts contexts, Services servers)
        : base(contexts.game)
    {
        game = contexts.game;
        _deleteEntitys = game.GetGroup(GameMatcher.DestoryOnReset);

        _services = servers;
    }

    public void Initialize()
    {
        ;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        game.isReset = false;

        //显示button reset

        //先destroy之前游戏的所有
        foreach(var obj in _deleteEntitys)
        {
            obj.isDestroyed = true;
        }

        game.ReplaceGameState(GameState.Ready);

        if(game.playerEntity != null)
        {
            game.playerEntity.ReplacePlayerState(PlayerGameState.Wait);
        }

        _services.CreatePlayerService.ResetPlayer();
        
        _services.BossService.ResetBoss();
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isReset;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Reset.Added());
    }
}
