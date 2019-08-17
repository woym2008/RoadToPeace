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
        Add(new BossHugeLazerEnterSystem(contexts));
        Add(new BossHugeLazerUpdateSystem(contexts));
        Add(new BossThrowTowerEnterSystem(contexts));
        Add(new BossThrowTowerUpdateSystem(contexts));
        Add(new BossThinkEnterSystem(contexts));
        Add(new BossThinkUpdateSystem(contexts));

        Add(new ShipBossCreateFloorSystem(contexts, services));
        Add(new TowerInitSystem(contexts, services));
        Add(new TowerUpdateSystem(contexts, services));
        Add(new OnDeleteTowerFloorSystem(contexts));
    }
}
