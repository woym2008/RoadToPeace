using UnityEngine;
using System.Collections;
using Entitas;


public class BossDebutUpdateSystem : IExecuteSystem
{
    Contexts _contexts;
    Vector3 _startpos;
    Vector3 _fightpos;
    float _curtime;
    float _flytime;

    IGroup<GameEntity> _boss;

    public BossDebutUpdateSystem(Contexts contexts)
    {
        _contexts = contexts;

        _startpos = _contexts.config.bossData.startpos;
        _fightpos = _contexts.config.bossData.fightpos;
        _flytime = _contexts.config.bossData.readytime;

        _boss = _contexts.game.GetGroup(GameMatcher.Boss);
    }
    public void Execute()
    {
        if(_contexts.game.bossState.state == BossState.Debut)
        {
            _curtime += Time.deltaTime;
            if(_curtime >= _flytime)
            {
                _contexts.game.ReplaceBossState(BossState.HugeLazer);
            }
            float t = Mathf.Min(_curtime / _flytime, 1);
            foreach(var b in _boss)
            {
                var newpos = Vector3.Lerp(_startpos, _fightpos, t);
                b.ReplacePosition(newpos);
                if(b.hasView)
                    b.view.Value.Position = b.position.position;
            }
        }
    }
}
