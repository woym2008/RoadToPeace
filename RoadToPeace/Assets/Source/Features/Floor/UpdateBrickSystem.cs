/* ========================================================
 *	类名称：UpdateBrickSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-26 17:45:54
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

public class UpdateBrickSystem : IExecuteSystem
{
    private IGroup<GameEntity> _entityGroup;
    public UpdateBrickSystem(Contexts contexts, Services services)
    {
        _entityGroup = contexts.game.GetGroup(GameMatcher.Brick);
    }

    public void Execute()
    {
        foreach(var entity in _entityGroup)
        {
            if(entity.hasPosition && entity.brickParent.parent.hasPosition)
            {
                entity.position.position.x = entity.brickParent.parent.position.position.x;
                entity.position.position.y = entity.brickYOffset.value + entity.brickParent.parent.position.position.y;
                if (entity.hasView)
                {
                    entity.view.Value.Position = entity.position.position;
                }
            }                        
        }
    }
}