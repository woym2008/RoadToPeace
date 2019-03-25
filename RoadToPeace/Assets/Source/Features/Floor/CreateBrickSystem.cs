/* ========================================================
 *	类名称：CreateBrickSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-21 19:07:45
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

public class CreateBrickSystem : ReactiveSystem<GameEntity>
{
    private Contexts _contexts;
    public CreateBrickSystem(Contexts contexts, Services services)
        : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        throw new NotImplementedException();
    }

    protected override bool Filter(GameEntity entity)
    {
        throw new NotImplementedException();
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Floor.Added());
    }
}
