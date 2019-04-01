/* ========================================================
 *	类名称：UpdatePointerSystem
 *	作 者：Zhangfan
 *	创建时间：2019-04-01 17:08:57
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public class UpdatePointerSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IInputService _inputService;
    public UpdatePointerSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _inputService = services.InputService;
    }

    public void Execute()
    {
        //_inputService.Update(_contexts.input.deltaTime.value);
        _inputService.Update(Time.deltaTime);

        var left = _contexts.input.leftSidePointerEntity;
        left.isPointerHolding = _inputService.IsHoldingLeft();
        left.isPointerStartedHolding = _inputService.IsStartedHoldingLeft();
        left.isPointerReleased = _inputService.IsReleasedLeft();
        left.ReplacePointerHoldingTime(_inputService.HoldingTimeLeft());
        left.ReplacePointerHoldingStartPos(_inputService.LeftStartHoldingPos());
        left.ReplacePointerCurrentPos(_inputService.LeftPos());
    }
}
