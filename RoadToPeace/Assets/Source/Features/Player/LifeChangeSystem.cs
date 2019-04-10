using UnityEngine;
using UnityEditor;
using Entitas;
using System.Collections.Generic;

public class LifeChangeSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext game;
    public LifeChangeSystem(Contexts contexts)
        : base(contexts.game)
    {
        game = contexts.game;

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
        if (game.hasGameState && (game.gameState.state == GameState.Running) && game.hasLife)
        {
            game.ReplaceGameState(GameState.GameOver);
        }
    }
}