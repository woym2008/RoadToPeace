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