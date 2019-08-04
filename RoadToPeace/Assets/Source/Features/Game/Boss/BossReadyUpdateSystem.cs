using UnityEngine;
using System.Collections;
using Entitas;

public class BossReadyUpdateSystem : IExecuteSystem
{
    Contexts _contexts;
    public BossReadyUpdateSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if(_contexts.game.bossState.state == BossState.Ready)
        { 
            var countdown = _contexts.game.bossDebutCountDown.time;
            countdown -= Time.deltaTime;
            if(countdown <= 0)
            {
                countdown = 0;
                _contexts.game.ReplaceBossState(BossState.Debut);

                //var boss = _contexts.game.CreateEntity();
                //boss.isBoss = true;
            }
            _contexts.game.ReplaceBossDebutCountDown(countdown);


        }
    }
}
