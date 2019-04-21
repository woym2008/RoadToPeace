using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class PlayerJumpOffSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    public PlayerJumpOffSystem(Contexts contexts, Services services)
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
                anim.PlayAnim("jumpoff");
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return (entity.playerState.state == PlayerGameState.JumpOff);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.PlayerState);
    }
}
