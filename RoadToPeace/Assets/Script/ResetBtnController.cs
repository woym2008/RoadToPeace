using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetBtnController : MonoBehaviour, IGameStateListener
{
    public Button _btn;
    // Start is called before the first frame update
    void Start()
    {
        _btn.gameObject.SetActive(false);
        _btn.onClick.AddListener(OnClick);

        var gamecontext = Contexts.sharedInstance.game;
        gamecontext.gameStateEntity.AddGameStateListener(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGameState(GameEntity entity, GameState state)
    {
        //Debug.LogWarning("GameOver Btn Show" + state);
        if (state == GameState.GameOver)
        {
            _btn.gameObject.SetActive(true);
            //Debug.LogWarning("GameOver Btn Show");
        }
    }

    private void OnClick()
    {
        //Debug.LogWarning("Btn OnClick");
        _btn.gameObject.SetActive(false);

        var gamecontext = Contexts.sharedInstance.game;
        gamecontext.isReset = true;
    }
}
