/* ========================================================
 *	类名称：DestroySystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-26 19:15:04
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;
using UnityEngine;

public class DestroySystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _gameGroup;
    private readonly List<GameEntity> _gameBuffer;

    public DestroySystem(Contexts contexts, Services services)
    {
        _gameGroup = contexts.game.GetGroup(GameMatcher.Destroyed);
        _gameBuffer = new List<GameEntity>();
    }

    public void Execute()
    {
        foreach (var e in _gameGroup.GetEntities(_gameBuffer))
        {
            //Debug.Log(e);
            if(e.hasFloorChild)
            {
                foreach (var brick in e.floorChild.childs)
                {
                    if (brick != null && brick.isEnabled)
                    {
                        if(brick.hasBrickParent)
                        {
                            brick.RemoveBrickParent();
                        }

                        brick.isDestroyed = true;

                    }

                }
                e.RemoveFloorChild();
            }
            if(e.hasChild)
            {
                e.isDestroyed = true;
                e.RemoveChild();
            }
            e.Destroy();
        }
    }
}
