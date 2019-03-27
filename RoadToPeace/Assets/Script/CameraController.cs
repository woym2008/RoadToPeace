using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour, IGameStateListener, IGameReadyListener
{
    private Transform _transform;

    private void Awake()
    {
        //Contexts.sharedInstance.game.CreateEntity().AddGameStateListener(this);
        

        //Contexts.sharedInstance.game.CreateEntity().AddGameReadyListener(this);
        _transform = this.gameObject.transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        Contexts.sharedInstance.game.gameStateEntity.AddGameStateListener(this);
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
        Debug.LogError("OnGameState");
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
    }

    IEnumerator onCameraMove(Action callback)
    {
        Vector3 target = Contexts.sharedInstance.config.cameraPos.runningpos;

        while (target.x > _transform.position.x)
        {
            _transform.position = Vector3.Lerp(_transform.position, target, Time.deltaTime);
            yield return 0;
        }
        _transform.position = target;

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
