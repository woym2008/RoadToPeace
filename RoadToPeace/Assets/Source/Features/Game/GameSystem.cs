﻿/* ========================================================
 *	类名称：GameSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-18 19:06:28
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

public class GameSystem : Feature
{
    public GameSystem(Contexts contexts)
    {
        Add(new GameResetSystem(contexts));
    }

}
