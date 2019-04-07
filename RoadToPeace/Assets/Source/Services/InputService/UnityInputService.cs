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

public class InputData
{
    public int fingerindex;
    public Vector3 startpos;
    public Vector3 curpos;
    public bool isHolding;
    public bool isPressed;
}

public class UnityInputService : Service, IInputService
{
    private float _holdingTimeLeft;
    private bool _isHoldingLeft;
    private bool _isReleasedLeft;
    private bool _isStartedHoldingLeft;

    private Vector2 _leftstartpos;
    private Vector2 _leftcurrentpos;

    private List<InputData> _InputDatas = new List<InputData>();

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

    public InputData GetInputData(int index)
    {
        return FindInputData(index);
    }

    public InputData[] GetInputDatas()
    {
        return _InputDatas.ToArray();
    }

    public void Update(float delta)
    {
        var hitCounter = 0;

        #region Mouse

        if (Input.GetMouseButton(0))
        {
            //Debug.LogWarning("GetMouseButton");
            //if (!_isHoldingLeft)
            //    _leftstartpos = Input.mousePosition;
            //_leftcurrentpos = Input.mousePosition;

            var data = FindInputData(0);
            if (data == null)
            {
                data = new InputData();
                data.startpos = Input.mousePosition;
                data.curpos = Input.mousePosition;
                data.fingerindex = 0;
                data.isHolding = false;
                data.isPressed = true;
                AddInputData(data);
            }
            else
            {
                data.curpos = Input.mousePosition;
                data.isHolding = true;
            }

            hitCounter++;
        }

        #endregion

        #region Touch
        if (Input.touches.Length > 0)
        {
            foreach (var touch in Input.touches)
            {
                var data = FindInputData(touch.fingerId);
                if(data == null)
                {
                    data = new InputData();
                    data.startpos = touch.position;
                    data.curpos = touch.position;
                    data.fingerindex = touch.fingerId;
                    data.isHolding = false;
                    data.isPressed = true;
                    AddInputData(data);
                }
                else
                {
                    data.curpos = touch.position;
                    data.isHolding = true;
                }

                hitCounter++;
            }
            //Input.touches[0].fingerId
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

    private InputData FindInputData(int index)
    {
        foreach(var data in _InputDatas)
        {
            if(data.fingerindex == index)
            {
                return data;
            }
        }
        return null;
    }

    private bool HasInputData(int index)
    {
        foreach (var data in _InputDatas)
        {
            if (data.fingerindex == index)
            {
                return true;
            }
        }

        return false;
    }

    private void AddInputData(InputData data)
    {
        _InputDatas.Add(data);
    }

    private void ClearInputDAta()
    {
        for (int i=_InputDatas.Count; i>=0; --i)
        {
            if (_InputDatas[i].isPressed == false)
            {
                _InputDatas.Remove(_InputDatas[i]);
            }
            else
            {
                _InputDatas[i].isPressed = false;
            }
        }
    }
}
