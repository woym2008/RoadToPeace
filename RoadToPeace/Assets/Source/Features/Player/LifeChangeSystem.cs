using UnityEngine;
using UnityEditor;
using Entitas;
using System.Collections.Generic;

public class LifeChangeSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _gameContext;

    IGroup<GameEntity> _player;

    public LifeChangeSystem(Contexts contexts)
        : base(contexts.game)
    {
        _gameContext = contexts.game;
        _player = _gameContext.GetGroup(GameMatcher.Player);
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
        var playerentity = _player.GetSingleEntity();
        if (_gameContext.hasGameState && (_gameContext.gameState.state == GameState.Running) && playerentity.hasLife && _gameContext.playerEntity.life.lifeValue<=0.0f)
        {
            _gameContext.ReplaceGameState(GameState.GameOver);


            //释放墓碑
            if(_gameContext.playerEntity != null)
            {
                _gameContext.playerEntity.ReplacePlayerState(PlayerGameState.Die);
            }

            var uitransform = _gameContext.playerUI.hpui;
            if(uitransform != null)
            {
                uitransform.gameObject.SetActive(false);
            }
        }
    }
}