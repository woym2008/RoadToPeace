using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartBtnController : MonoBehaviour
{
    private Button _btn;
    // Start is called before the first frame update
    void Start()
    {
        _btn = this.gameObject.GetComponent<Button>();
        _btn.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClick()
    {
        if(Contexts.sharedInstance.game.hasGameState)
        {
            Contexts.sharedInstance.game.ReplaceGameState(GameState.Start);
        }

        this.gameObject.SetActive(false);
    }
}
