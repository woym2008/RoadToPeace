using UnityEngine;
using System.Collections;
using Entitas;

public class PlayerSystem : Feature
{
    public PlayerSystem(Contexts contexts, Services services)
    {
        Add(new PlayerFirstMoveSystem(contexts, services));

        Add(new PlayerCollideSystem(contexts, services));

        Add(new PlayerWaitSystem(contexts, services));

        Add(new PlayerRunSystem(contexts, services));

        Add(new PlayerJumpUpSystem(contexts, services));

        Add(new PlayerJumpOffSystem(contexts, services));

        Add(new PlayerJumpUpUpdateSystem(contexts, services));

        Add(new PlayerJumpOffUpdateSystem(contexts, services));

        Add(new PlayerDieSystem(contexts, services));

        Add(new PlayerStartSystem(contexts));

        Add(new LifeChangeSystem(contexts));
    }
}
