/* ========================================================
 *	类名称：PlayerJumpSystem
 *	作 者：Zhangfan
 *	创建时间：2019-04-01 16:43:16
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

public class PlayerJumpSystem : IExecuteSystem
{
    private Contexts _contexts;
    public PlayerJumpSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
    }
    public void Execute()
    {
        //throw new NotImplementedException();
    }
}
