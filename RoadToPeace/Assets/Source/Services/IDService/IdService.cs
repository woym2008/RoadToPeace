﻿/* ========================================================
 *	类名称：IdService
 *	作 者：Zhangfan
 *	创建时间：2019-03-19 18:52:50
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IdService
{
    private int _id;

    public IdService(Contexts contexts)
    {

    }

    public int GetNext()
    {
        _id++;
        return _id;
    }

    public void Reset()
    {
        _id = 0;
    }
}
