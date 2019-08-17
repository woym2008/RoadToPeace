using UnityEngine;
using System.Collections;
using Entitas;

public class TimerSystem : IExecuteSystem
{
    Contexts _contexts;
    IGroup<GameEntity> _timers;

    public TimerSystem(Contexts contexts)
    {
        _contexts = contexts;

        _timers = contexts.game.GetGroup(GameMatcher.Timer);
    }

    public void Execute()
    {
        foreach(var timer in _timers)
        {
            timer.timer.passedTime += Time.deltaTime;
        }
    }
}
