using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IInputService
{
    bool IsHoldingLeft();
    bool IsStartedHoldingLeft();
    float HoldingTimeLeft();
    bool IsReleasedLeft();
    Vector3 LeftPos();
    Vector3 LeftStartHoldingPos();

    void Update(float delta);

    InputData GetInputData(int index);

    InputData[] GetInputDatas();
}
