using UnityEngine;
using System.Collections;
using Entitas;

public class UpdateGroundViewSystem : IExecuteSystem
{
    private readonly Services _services;
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _groundviewgroup;

    public UpdateGroundViewSystem(Contexts contexts, Services services)
    {
        _game = contexts.game;
        _services = services;

        _groundviewgroup = _game.GetGroup(GameMatcher.GroundView);
    }

    public void Execute()
    {
        foreach(var groundview in _groundviewgroup)
        {
            if(groundview.hasView && groundview.groundParent.parent.hasPosition)
            {
                groundview.ReplacePosition(
                new Vector3
                (groundview.groundParent.parent.position.position.x,
                groundview.groundParent.parent.position.position.y,
                groundview.position.position.z)
                    );
                groundview.view.Value.Position = groundview.position.position;
            }
        }
    }
}
