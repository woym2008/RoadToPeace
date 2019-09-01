using UnityEngine;
using System.Collections;

public class CreateBossService : Service
{
    const string bosspathbase = "boss/";
    public CreateBossService(Contexts contexts)
        : base(contexts)
    {
        ;
    }

    public void CreateBoss(int id, Vector2 position)
    {
        var e = _contexts.game.CreateEntity();

        var bossname = _contexts.config.bossNames.bossnames[0];

        e.isBoss = true;
        e.AddId(id);
        e.AddAsset(bosspathbase + bossname, 3);
        e.AddPosition(position);
        e.ReplaceLife(10);
        e.isDestoryOnReset = true;
        //e.ReplaceBossState(BossState.Ready);
        //_contexts.game.ReplaceBossState(BossState.Ready);
    }

    public void ResetBoss()
    {
        var boss = _contexts.game.GetGroup(GameMatcher.Boss);
        if(boss.count > 0)
        {
            var e = boss.GetSingleEntity();
            _contexts.game.ReplaceBossState(BossState.Ready);
        }
        _contexts.game.ReplaceBossDebutCountDown(10);
    }
}
