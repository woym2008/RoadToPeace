using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class PlayerJumpUpSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    public PlayerJumpUpSystem(Contexts contexts, Services services)
        : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var player in entities)
        {
            if (player.hasAnim)
            {
                var anim = player.anim.anim;
                anim.PlayAnim("jumpup");
                player.view.Value.SortID = 10;
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return (entity.playerState.state == PlayerGameState.JumpUp);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.PlayerState);
    }
}
