/* ========================================================
 *	类名称：FloorSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-22 14:43:04
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

public class FloorSystem : Feature
{
    public FloorSystem(Contexts contexts, Services services)
    {
        Add(new FirstCreateFloorSystem(contexts, services));
        Add(new CreateFloorSystem(contexts, services));
        Add(new CreateBrickSystem(contexts, services));

        Add(new BrickBrokenSystem(contexts, services));

        //Add(new DragFloorSystem(contexts, services));
        Add(new MoveFloorSystem(contexts, services));
        Add(new DestoryFloorSystem(contexts, services));
        Add(new UpdateBrickSystem(contexts, services));
    }
}
