/* ========================================================
 *	类名称：GameCameraComponent
 *	作 者：Zhangfan
 *	创建时间：2019-04-02 11:27:33
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

[Game]
[Unique]
public class GameCameraComponent : IComponent
{
    public Camera camera;
}
