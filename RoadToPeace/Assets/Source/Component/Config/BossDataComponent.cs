using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Config,Unique]
public class BossDataComponent : IComponent
{
    public Vector3 startpos;
    public Vector3 fightpos;

    public float bosshp;

    public float readytime;
    public float thinktime;

}

[Config,Unique]
public class BossNamesComponent : IComponent
{
    public List<string> bossnames;

}

[Config,Unique]
public class BossDebutTimeComponent : IComponent
{
    public float debuttime;
}