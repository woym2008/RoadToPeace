/* ========================================================
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
    public GameSystem(Contexts contexts, Services services)
    {
        Add(new PlayerCreateSystem(contexts, services));
        Add(new GameResetSystem(contexts, services));        
        Add(new CreateBrickSystem(contexts, services));

        Add(new ResourcesSystem(contexts, services));

        //Add(new ApplyPositionSystem(contexts));

        Add(new MovementSystem(contexts, services));
    }

}
