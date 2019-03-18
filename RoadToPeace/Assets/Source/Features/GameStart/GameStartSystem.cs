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
using Entitas;

public class GameStartSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    readonly GameContext game;
    IGroup<GameEntity> _deleteEntitys;

    public GameStartSystem(Contexts contexts)
        : base(contexts.game)
    {
        game = contexts.game;
        //_deleteEntitys = game.GetGroup(GameMatcher.)
    }

    public void Initialize()
    {
        ;
    }

    protected override void Execute(List<GameEntity> entities)
    {
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return new Collector<GameEntity>(
            new[] { context.GetGroup(GameMatcher.GameObject) },
            new[] { GroupEvent.Removed }
        );
    }
}
