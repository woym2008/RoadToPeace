/* ========================================================
 *	类名称：GameOverSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-18 19:07:58
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

public class GameOverSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext game;
    public GameOverSystem(Contexts contexts)
        : base(contexts.game)
    {
        game = contexts.game;
    }

    protected override bool Filter(GameEntity entity)
    {
        return (entity.gameState.state == GameState.GameOver);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameState);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        //temp
        //game.ReplaceGameState(GameState.Ready);
        //game.isReset = true;
    }
}
