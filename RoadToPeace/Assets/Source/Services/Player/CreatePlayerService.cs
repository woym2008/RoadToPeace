/* ========================================================
 *	类名称：CreatePlayerService
 *	作 者：Zhangfan
 *	创建时间：2019-03-20 19:19:47
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class CreatePlayerService : Service
{
    public CreatePlayerService(Contexts contexts)
        : base(contexts)
    {
        ;
    }

    public void CreatePlayer(int id, Vector2 position)
    {
        var e = _contexts.game.CreateEntity();

        e.isPlayer = true;
        e.AddId(id);
        e.AddAsset("Player",3);
        e.AddPosition(position);
        e.ReplaceLife(1);
    }
}
