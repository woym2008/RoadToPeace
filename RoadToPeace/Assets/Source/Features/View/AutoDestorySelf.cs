using UnityEngine;
using System.Collections;

public class AutoDestorySelf : MonoBehaviour, IAutoDestorySelf
{
    private GameEntity _entity;

    public float DestoryTime = 1;

    private float _curtime = 0;
    public void SetEntity(GameEntity entity)
    {
        _entity = entity;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_entity != null && !_entity.isDestroyed)
        {
            if (_curtime > 0)
            {
                _curtime -= Time.deltaTime;
            }
            else
            {
                //Debug.LogError("Destory effect mono");
                _entity.isDestroyed = true;
            }
        }

    }

    private void OnEnable()
    {
        _curtime = DestoryTime;
    }
}
