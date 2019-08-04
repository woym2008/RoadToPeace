using UnityEngine;
using System.Collections;
using Entitas;

public class BossSystem : Feature
{
    public BossSystem(Contexts contexts, Services services)
    {
        Add(new BossInitSystem(contexts, services));
        Add(new BossCreateSystem(contexts, services));
        Add(new BossReadyUpdateSystem(contexts));
        Add(new BossDebutUpdateSystem(contexts));
        Add(new BossFightUpdateSystem(contexts));
    }
}
