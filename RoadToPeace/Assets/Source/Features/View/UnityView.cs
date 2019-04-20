/* ========================================================
 *	类名称：UnityView
 *	作 者：Zhangfan
 *	创建时间：2019-03-19 18:32:01
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class UnityView : MonoBehaviour, IView, IDestroyedListener
{
    private GameObject _gameObject;
    private GameEntity _entity;

    public void InitializeView(Contexts contexts, GameEntity entity)
    {
        _gameObject = this.gameObject;
        _entity = entity;
        _entity.AddDestroyedListener(this);
        //_transform = this.transform;
        //Id = entity.
    }

    public void OnDestroyed(GameEntity entity)
    {
        Destroy(_gameObject);
    }

    public void DestroyImmediate()
    {
        _entity.RemoveDestroyedListener(this);
        //Debug.Log("Destory " + this.gameObject.name);
        Destroy(_gameObject);
    }

    public int Id { get; set; }

    public bool Enabled
    {
        get
        {
            return _gameObject.activeSelf;
        }
        set
        {
            _gameObject.SetActive(value);
        }
    }

    public Vector2 Position
    {
        get { return _gameObject.transform.position; }
        set { _gameObject.transform.position = value; }
    }

    public Transform Transform
    {
        get { return _gameObject.transform; }
    }

    public int SortID
    {
        get
        {
            var objrenderer = gameObject.GetComponent<SpriteRenderer>();
            if (objrenderer != null)
            {
                return objrenderer.sortingLayerID;
            }
            return 0;
        }
        set
        {
            var objrenderer = gameObject.GetComponent<SpriteRenderer>();
            if (objrenderer != null)
            {
                objrenderer.sortingOrder = value;

                //if(gameObject.transform.childCount > 0)
                //{
                //    gameObject.transform.getc
                //  }
            }
        }
    }
}
