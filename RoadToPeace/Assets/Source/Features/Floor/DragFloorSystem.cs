/* ========================================================
 *	类名称：DragFloorSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-22 14:51:02
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

public class DragFloorSystem : ReactiveSystem<GameEntity>
{
    public DragFloorSystem(Contexts contexts, Services services)
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
