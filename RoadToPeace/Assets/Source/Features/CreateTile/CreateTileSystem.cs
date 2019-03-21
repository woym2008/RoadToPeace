/* ========================================================
 *	类名称：CreateTileSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-21 19:07:45
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

public class CreateTileSystem : IExecuteSystem
{
    private Contexts _contexts;
    public CreateTileSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
    }
    public void Execute()
    {
        throw new NotImplementedException();
    }
}
