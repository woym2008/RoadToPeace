using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour, IGameStateListener, IGameReadyListener
{
    private Transform _transform;

    public float movetime = 2.0f;
    public float curtime = 0;
    public Vector3 cachepos;

    private void Awake()
    {
        //Contexts.sharedInstance.game.CreateEntity().AddGameStateListener(this);
        

        //Contexts.sharedInstance.game.CreateEntity().AddGameReadyListener(this);
        _transform = this.gameObject.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        var gamecontext = Contexts.sharedInstance.game;
        gamecontext.gameStateEntity.AddGameStateListener(this);
        gamecontext.ReplaceGameCamera(this.gameObject.GetComponent<Camera>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameState(GameEntity entity, GameState state)
    {
        //if(entity.isGameReady)
        //{
        //    StartCoroutine(onCameraMove(onFinish));
        //}
        //Debug.LogError("OnGameState");
        if(state == GameState.Start)
        {
            //临时的 应该是当有button触发后 为 start 则 继续
            //Contexts.sharedInstance.game.ReplaceGameState(GameState.Start);

            StartCoroutine(onCameraMove(onFinish));
        }
    }

    private void onFinish()
    {
        Contexts.sharedInstance.game.ReplaceGameState(GameState.Running);

        //First run
        Contexts.sharedInstance.game.isGameStart = true;
    }

    IEnumerator onCameraMove(Action callback)
    {
        Vector3 target = Contexts.sharedInstance.config.cameraPos.runningpos;

        cachepos = Contexts.sharedInstance.config.cameraPos.titlepos;

        //while (target.x > _transform.position.x)
        //{
        //    _transform.position = Vector3.Lerp(_transform.position, target, Time.deltaTime);
        //    yield return 0;
        //}
        float dis = target.x - cachepos.x;
        curtime = 0;
        movetime = dis*0.73f / Contexts.sharedInstance.game.floorSpeed.value;

        while (curtime < movetime)
        {
            _transform.position = Vector3.Lerp(cachepos, target, curtime/movetime);

            curtime += Time.deltaTime;

            yield return 0;
        }

        _transform.position = target;

        //while(!Contexts.sharedInstance.game.isPlayerReady)
        //{
        //    yield return 0;
        //}

        if(callback != null)
        {
            callback.Invoke();
        }
    }

    public void OnGameReady(GameEntity entity)
    {
        throw new NotImplementedException();
    }
}
