/* ========================================================
 *	类名称：UnityInputService
 *	作 者：Zhangfan
 *	创建时间：2019-03-19 18:27:36
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class UnityInputService : Service, IInputService
{
    private float _holdingTimeLeft;
    private bool _isHoldingLeft;
    private bool _isReleasedLeft;
    private bool _isStartedHoldingLeft;

    private Vector2 _leftstartpos;
    private Vector2 _leftcurrentpos;

    public UnityInputService(Contexts contexts)
        : base(contexts)
    {

    }

    public float HoldingTimeLeft()
    {
        return _holdingTimeLeft;
    }

    public bool IsHoldingLeft()
    {
        return _isHoldingLeft;
    }

    public bool IsReleasedLeft()
    {
        return _isReleasedLeft;
    }

    public bool IsStartedHoldingLeft()
    {
        return _isStartedHoldingLeft;
    }

    public Vector3 LeftPos()
    {
        return _leftcurrentpos;
    }

    public Vector3 LeftStartHoldingPos()
    {
        return _leftstartpos;
    }

    public void Update(float delta)
    {
        var hitCounter = 0;

        #region Mouse

        if (Input.GetMouseButton(0))
        {
            //Debug.LogWarning("GetMouseButton");
            if (!_isHoldingLeft)
                _leftstartpos = Input.mousePosition;
            _leftcurrentpos = Input.mousePosition;
            hitCounter++;
        }

        #endregion

        if (hitCounter > 0)
        {
            if (_isHoldingLeft)
            {
                _holdingTimeLeft += delta;
                _isStartedHoldingLeft = false;
            }
            else
            {
                _holdingTimeLeft = 0f;
                _isStartedHoldingLeft = true;
            }

            _isHoldingLeft = true;
            _isReleasedLeft = false;
        }
        else
        {
            if (_isHoldingLeft)
            {
                _isHoldingLeft = false;
                _isReleasedLeft = true;
            }
            else
            {
                _isReleasedLeft = false;
            }
        }


    }
}
