/* ========================================================
 *	类名称：UnityViewService
 *	作 者：Zhangfan
 *	创建时间：2019-03-19 19:09:44
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class UnityViewService : Service, IViewService
{
    private readonly Transform _root;

    public UnityViewService(Contexts contexts) : base(contexts)
    {
        _root = new GameObject("ViewRoot").transform;
    }

    public void LinkChildsToEntities(Contexts contexts, IView view, IdService idService)
    {
        throw new NotImplementedException();
    }

    public void LoadAsset(Contexts contexts, GameEntity entity, string assetName, int sortid = 0)
    {
        var viewObject = GameObject.Instantiate(Resources.Load<GameObject>(string.Format("Prefabs/{0}", assetName)), _root);
        if (viewObject == null)
            throw new NullReferenceException(string.Format("Prefabs/{0} not found!", assetName));

        var view = viewObject.GetComponent<IView>();
        if (view != null)
        {
            view.InitializeView(contexts, entity);
            entity.AddView(view);
            if(entity.hasPosition)
            {
                view.Position = entity.position.position;
            }
            view.SortID = sortid;
        }

        //viewObject.GetComponents(_eventListenerBuffer);
        //foreach (var listener in _eventListenerBuffer)
        //    listener.RegisterListeners(entity);

    }
}
