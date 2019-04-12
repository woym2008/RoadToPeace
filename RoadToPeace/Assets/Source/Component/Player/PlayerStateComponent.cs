using UnityEngine;
using System.Collections;
using Entitas;
using System;

public enum PlayerGameState
{
    Wait,
    Run,
    Jump,
    Die,
}

[Game]
public class PlayerStateComponent : IComponent
{
    public PlayerGameState state;
}
