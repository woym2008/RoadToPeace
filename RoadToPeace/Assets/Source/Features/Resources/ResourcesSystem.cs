/* ========================================================
 *	类名称：ResourcesSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-21 19:15:11
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entitas;

public class ResourcesSystem : ReactiveSystem<GameEntity>
{
    private IViewService _viewservice;
    private Contexts _contexts;
    public ResourcesSystem(Contexts contexts, Services services)
        : base(contexts.game)
    {
        _viewservice = services.ViewService;
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var entity in entities)
        {
            _viewservice.LoadAsset(_contexts, entity, entity.asset.name, entity.asset.sortid);
            entity.isAssetLoaded = true;
        }

    }

    protected override bool Filter(GameEntity entity)
    {
        //return entity.hasAsset && !entity.isAssetLoaded;
        return entity.hasAsset;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Asset.Added());
    }
}
