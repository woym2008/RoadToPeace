using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDebugController : MonoBehaviour
{
    Contexts _contexts;

    // Start is called before the first frame update
    void Start()
    {
        _contexts = Contexts.sharedInstance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        if(_contexts.game != null && _contexts.game.playerEntity != null)
        {
            GUI.skin.label.fontSize = 32;
            GUI.Label(new Rect(0, 0, 200, 100), _contexts.game.playerEntity.life.lifeValue.ToString());
        }
    }
}
