using UnityEngine;
using System.Collections;
using Entitas;

public class PlayerJumpOffUpdateSystem : IExecuteSystem
{
    private Contexts _contexts;
    public PlayerJumpOffUpdateSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var player = _contexts.game.playerEntity;
        var jumpoffspeed = _contexts.config.playerData.jumpoffspeed;
        if (!player.hasPlayerState)
        {
            return;
        }
        if (player.playerState.state != PlayerGameState.JumpOff)
        {
            return;
        }

        var curheight = player.position.position.y + jumpoffspeed * Time.deltaTime;
        if(curheight <= _contexts.config.runPlayerPosition.value.y)
        {
            curheight = _contexts.config.runPlayerPosition.value.y;
            player.ReplacePlayerState(PlayerGameState.Run);
        }
        player.ReplacePosition(new Vector3(
            player.position.position.x,
            curheight,
            player.position.position.z)
            );

        _contexts.game.playerEntity.view.Value.Position = _contexts.game.playerEntity.position.position;
    }
}
