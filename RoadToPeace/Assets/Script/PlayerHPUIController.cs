using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUIController : MonoBehaviour, ILifeListener
{
    private Text _wordText;

    IGroup<GameEntity> _playerEntity;

    bool findlistener = false;

    private void Awake()
    {
        var gamecontext = Contexts.sharedInstance.game;
        _wordText = this.transform.Find("hptext").GetComponent<Text>();
        _playerEntity = gamecontext.GetGroup(GameMatcher.Player);

        findlistener = false;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnEnable()
    {
        if(!findlistener)
        {
            var es = _playerEntity.GetEntities();
            if(es.Length == 0)
            {
                return;
            }
            var player = _playerEntity.GetSingleEntity();
            player.AddLifeListener(this);
            findlistener = true;
        }
    }

    public void OnLife(GameEntity entity, float lifeValue)
    {
        if(entity.isPlayer)
        {
            if(_wordText != null)
            {
                lifeValue = lifeValue < 0 ? 0 : lifeValue;
                _wordText.text = ((int)lifeValue).ToString();
            }
        }
    }
}
