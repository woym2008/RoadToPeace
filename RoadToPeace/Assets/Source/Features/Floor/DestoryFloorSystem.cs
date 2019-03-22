/* ========================================================
 *	类名称：DestoryFloorSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-22 14:59:27
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

public class DestoryFloorSystem : ReactiveSystem<GameEntity>
{
    public DestoryFloorSystem(Contexts contexts, Services services)
        : base(contexts.game)
    {

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
        throw new NotImplementedException();
    }
}
