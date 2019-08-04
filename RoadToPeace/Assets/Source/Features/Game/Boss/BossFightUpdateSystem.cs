using UnityEngine;
using System.Collections;
using Entitas;

public class BossFightUpdateSystem : IExecuteSystem
{
    Contexts _contexts;

    public BossFightUpdateSystem(Contexts contexts)
    { 
        _contexts = contexts;
    }

    public void Execute()
    {
        if(_contexts.game.bossState.state == BossState.Fighting)
        {

        }
    }
}
