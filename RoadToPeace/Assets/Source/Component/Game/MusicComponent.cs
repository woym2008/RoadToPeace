using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class MusicComponent : IComponent
{

}

[Game][Unique]
public class BgmComponent : IComponent
{
    public AudioSource value;
}

[Game][Unique]
public class SFXComponent : IComponent
{
    public AudioSource storelazer;
    public AudioSource firelazer;
    public AudioSource missileboom;
}