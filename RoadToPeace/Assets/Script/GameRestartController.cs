﻿using UnityEngine;
using System.Collections;

public class GameRestartController : MonoBehaviour, IGameStateListener
{
    GameContext _context;
    public void OnGameState(GameEntity entity, GameState state)
    {
        if ((state == GameState.Ready) && (_context.isGameStart))
        {
            //_colddown = true;
            StartCoroutine(WaitRestart());
        }
    }

    // Use this for initialization
    void Start()
    {
        _context = Contexts.sharedInstance.game;
        _context.gameStateEntity.AddGameStateListener(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator WaitRestart()
    {
        yield return new WaitForSeconds(1);

        _context.ReplaceGameState(GameState.Running);
    }
}
