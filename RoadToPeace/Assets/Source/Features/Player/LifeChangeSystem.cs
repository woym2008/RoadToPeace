using UnityEngine;
using UnityEditor;
using Entitas;
using System.Collections.Generic;

public class LifeChangeSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _gameContext;
    public LifeChangeSystem(Contexts contexts)
        : base(contexts.game)
    {
        _gameContext = contexts.game;

    }
    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Life);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (_gameContext.hasGameState && (_gameContext.gameState.state == GameState.Running) && _gameContext.hasLife)
        {
            _gameContext.ReplaceGameState(GameState.GameOver);


            //释放墓碑
            if(_gameContext.playerEntity != null)
            {
                _gameContext.playerEntity.ReplacePlayerState(PlayerGameState.Die);
            }
        }
    }
}