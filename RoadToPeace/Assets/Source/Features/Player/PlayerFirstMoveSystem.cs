/* ========================================================
 *	类名称：PlayerFirstMoveSystem
 *	作 者：Zhangfan
 *	创建时间：2019-04-01 15:35:15
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

public class PlayerFirstMoveSystem : IExecuteSystem
{
    private readonly GameContext _game;
    private readonly ConfigContext _config;
    public PlayerFirstMoveSystem(Contexts contexts, Services services)
    {
        _game = contexts.game;
        _config = contexts.config;
    }

    public void Execute()
    {
        if(_game.gameState.state == GameState.Start && _game.isPlayerReady == false)
        {
            if (_game.playerEntity != null)
            {
                Vector3 target = _config.runPlayerPosition.value;
                float speed = _game.floorSpeed.value;

                Vector3 nextpos = _game.playerEntity.position.position + new Vector3(1,0,0) * speed * Time.deltaTime;

                if(nextpos.x > target.x)
                {
                    nextpos = target;
                    _game.isPlayerReady = true;
                }
                _game.playerEntity.ReplacePosition(nextpos);

                _game.playerEntity.view.Value.Position = _game.playerEntity.position.position;
            }
        }
    }
}
