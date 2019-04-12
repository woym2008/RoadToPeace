using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class PlayerStartSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;
    public PlayerStartSystem(Contexts contexts)
        : base(contexts.game)
    {
        _context = contexts.game;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        if(_context.playerEntity != null)
        {
            _context.playerEntity.ReplacePlayerState(PlayerGameState.Run);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return (entity.gameState.state == GameState.Start);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameState);
    }
}
