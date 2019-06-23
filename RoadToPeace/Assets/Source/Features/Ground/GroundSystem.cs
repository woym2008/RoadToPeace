using UnityEngine;
using System.Collections;

public class GroundSystem : Feature
{
    public GroundSystem(Contexts contexts, Services services)
    {
        Add(new FirstCreatGroundSystem(contexts, services));
        Add(new CreateGroundSystem(contexts, services));

        Add(new MoveGroundSystem(contexts, services));
    }
}
