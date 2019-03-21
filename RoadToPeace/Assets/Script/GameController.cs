using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class GameController : MonoBehaviour
{
    GameSystem _gamesystem;

    GameContext _gamecontext;
    // Start is called before the first frame update
    void Start()
    {
        var contexts = Contexts.sharedInstance;
        _gamesystem = new GameSystem(contexts, new Services(contexts));
        _gamesystem.Initialize();

        _gamecontext = contexts.game;
    }

    // Update is called once per frame
    void Update()
    {
        _gamesystem.Execute();

        if (Input.GetKeyDown(KeyCode.A))
        {
            _gamecontext.isReset = true;
        }
    }
}
