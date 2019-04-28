using UnityEngine;
using System.Collections;
using Entitas;

public class GameDataSystem : Feature
{
    public GameDataSystem(Contexts contexts, Services services)
    {
        Add(new DifficultUpdataSystem(contexts));
    }
}
