/* ========================================================
 *	类名称：PlayerJumpSystem
 *	作 者：Zhangfan
 *	创建时间：2019-04-01 16:43:16
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

public class PlayerJumpUpUpdateSystem : IExecuteSystem
{
    private Contexts _contexts;
    public PlayerJumpUpUpdateSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
    }
    public void Execute()
    {
        var player = _contexts.game.playerEntity;
        var jumpupspeed = _contexts.config.playerData.jumpupspeed;
        if (!player.hasPlayerState)
        {
            return;
        }
        if (player.playerState.state != PlayerGameState.JumpUp)
        {
            return;
        }

        var curheight = player.position.position.y + jumpupspeed * Time.deltaTime;
        if (curheight >= (_contexts.config.startPlayerPosition.value.y + _contexts.config.playerData.jumpheight))
        {
            curheight = _contexts.config.startPlayerPosition.value.y + _contexts.config.playerData.jumpheight;
            player.ReplacePlayerState(PlayerGameState.JumpOff);
        }
        player.ReplacePosition(new Vector3(
            player.position.position.x,
            curheight,
            player.position.position.z)
            );

        _contexts.game.playerEntity.view.Value.Position = _contexts.game.playerEntity.position.position;
    }
}
