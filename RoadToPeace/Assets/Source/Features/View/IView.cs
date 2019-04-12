/* ========================================================
 *	类名称：IView
 *	作 者：Zhangfan
 *	创建时间：2019-03-19 18:30:10
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;
using UnityEngine;

public interface IView
{
    bool Enabled { get; set; }
    int Id { get; set; }
    Vector2 Position { get; set; }
    Transform Transform { get; }
    int SortID { set; }

    void InitializeView(Contexts contexts, GameEntity entity);
    void DestroyImmediate();
}
