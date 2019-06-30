using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class MoveGroundSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly Services _services;
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _groundgroup;

    List<GameEntity> listtest = new List<GameEntity>();

    public MoveGroundSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _services = services;
        _game = _contexts.game;
        _groundgroup = contexts.game.GetGroup(GameMatcher.Ground);
    }

    public void Execute()
    {
        var player = _contexts.game.playerEntity;
        if (player != null && player.hasPosition)
        {
            if (_game.hasGameState && _game.gameState.state == GameState.Running)
            {
                foreach(var g in _groundgroup)
                {
                    g.position.position.x -= _contexts.game.floorSpeed.value * Time.fixedDeltaTime;

                    if (g.hasView)
                    {
                        g.view.Value.Position = g.position.position;
                    }

                    if (g.position.position.x < _contexts.config.groundData.overPos.x)
                    {
                        //g.isGround = false;
                        g.isDestroyed = true;
                        //减去一个entity 再创建一个新的
                        //Debug.Log("Destory one floor");
                        continue;
                    }
                }
            }
        }
    }
}
