using UnityEngine;
using System.Collections;
using Entitas;
using System;

public enum PlayerGameState
{
    Wait,
    Run,
    JumpUp,
    JumpOff,    
    Die,
}

[Game]
public class PlayerStateComponent : IComponent
{
    public PlayerGameState state;
}
