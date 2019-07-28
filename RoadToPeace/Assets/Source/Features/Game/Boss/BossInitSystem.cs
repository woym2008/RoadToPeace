using UnityEngine;
using System.Collections;
using Entitas;

//用来在游戏开始的时候就初始化boss
//给一个时间，倒计时结束后，boss出现
public class BossInitSystem : IInitializeSystem
{
    Contexts _contexts;
    public BossInitSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
    }
    public void Initialize()
    {
        var debuttime = _contexts.config.bossDebutTime.debuttime;

        _contexts.game.ReplaceBossDebutCountDown(debuttime);
        //e.AddBossDebutCountDown(debuttime);
    }
}
