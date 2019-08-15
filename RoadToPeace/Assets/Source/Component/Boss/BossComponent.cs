using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

//是不是boss
[Game]
public class BossComponent : IComponent
{
}

public enum BossState
{
    Null,
    Ready,
    Debut,
    Fighting,
    ThrowTower,
    HugeLazer,
    Thinging,
    Die,
}

[Game,Unique]
public class BossStateComponent : IComponent
{
    public BossState state;
}

[Game,Unique]
public class BossDebutCountDownComponent : IComponent
{
    public float time;
}

[Game]
public class BossHugeLazer : IComponent
{
    //光柱还剩下运行大时间
    public float runningtime;

    //发射到最大射程需要到时间
    public float maxtime;
    //光柱发射到最大射成 已用的时间
    public float tomaxtime;

    //三条线上光柱大长度
    public float length_up;
    public float length_middle;
    public float length_down;
}

[Game]
public class LazerTowerComponent : IComponent
{

}
[Game]
public class ObjectParentComponent : IComponent
{
    public GameEntity parent;
}

[Game]
public class BossCreateFloorComponent : IComponent
{

}

[Game]
public class IsLazerTowerFloorComponent : IComponent
{
    
}
[Game]
public class IsBlockLazerFloorComponent : IComponent
{

}

[Game]
public class BossThinkingComponent : IComponent
{
    public int bossAttackType;
}

//boss状态间传递参数用的
[Game]
public class BossFightParamComponent : IComponent
{

}