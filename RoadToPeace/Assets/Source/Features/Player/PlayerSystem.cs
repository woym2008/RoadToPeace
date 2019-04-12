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

        Add(new PlayerJumpSystem(contexts, services));

        Add(new PlayerDieSystem(contexts, services));

        Add(new PlayerStartSystem(contexts));

        Add(new LifeChangeSystem(contexts));
    }
}
