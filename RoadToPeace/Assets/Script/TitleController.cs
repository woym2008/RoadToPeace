using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour, IGameStateListener
{
    public Image _titleImage; 

    public void OnGameState(GameEntity entity, GameState state)
    {
        Debug.LogWarning("TitleController start game 0");
        if (_titleImage.gameObject.activeSelf)
        {
            if(state == GameState.Start)
            {
                Debug.LogWarning("TitleController start game");

                StartCoroutine(FadeOut(onFinish));
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        var gamecontext = Contexts.sharedInstance.game;
        gamecontext.gameStateEntity.AddGameStateListener(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void onFinish()
    {
        Debug.LogWarning("Title Fade Finish");
    }

    private IEnumerator FadeOut(Action onfinish)
    {
        float curtime = 3.0f;
        _titleImage.gameObject.GetComponent<Graphic>().CrossFadeAlpha(0, curtime, false);

        yield return new WaitForSeconds(curtime);

        _titleImage.gameObject.SetActive(false);

        if(onfinish != null)
        {
            onfinish.Invoke();
        }
    }
}
