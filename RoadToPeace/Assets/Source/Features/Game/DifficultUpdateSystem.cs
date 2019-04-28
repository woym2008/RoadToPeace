using UnityEngine;
using System.Collections;
using Entitas;

public class DifficultUpdataSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    public DifficultUpdataSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Execute()
    {
        if(
        !_contexts.game.hasGameState || 
        _contexts.game.gameState.state != GameState.Running)
        {
            return;
        }

        var level = _contexts.game.difficulty.value;
        var curuptime = _contexts.game.difficultCountDown.countdown;
        var leveluptime = _contexts.config.difficultLevelup.leveluptime;

        var curspeed = _contexts.game.floorSpeed.value;
        var target = _contexts.game.floorSpeed.targetvalue;

        curuptime += Time.deltaTime;

        int newlevel = (int)(curuptime / leveluptime);
        if(newlevel != level)
        {
            _contexts.game.ReplaceDifficulty(newlevel);

            //speed
            target = target + (newlevel - level) * _contexts.config.floorSpeedUp.value;
        }

        float accuracy = target * 0.001f;

        if ((target - curspeed) > accuracy)
        {
            curspeed = Mathf.Lerp(curspeed, target, Time.deltaTime);
            _contexts.game.ReplaceFloorSpeed(curspeed, target);
        }

        _contexts.game.ReplaceDifficultCountDown(curuptime);
    }
}
