using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

public interface IViewService
{
    void LoadAsset(Contexts contexts, GameEntity entity, string assetName);
    void LinkChildsToEntities(Contexts contexts, IView view, IdService idService);
}
