﻿/* ========================================================
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

public class UnityView : MonoBehaviour, IView
{
    private GameObject _gameObject;
    private GameEntity _entity;

    public void InitializeView(Contexts contexts, GameEntity entity)
    {
        _gameObject = this.gameObject;
        _entity = entity;
        //_transform = this.transform;
        //Id = entity.
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
}
