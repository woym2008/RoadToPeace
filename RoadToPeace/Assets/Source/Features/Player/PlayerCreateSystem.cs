/* ========================================================
 *	类名称：PlayerCreateSystem
 *	作 者：Zhangfan
 *	创建时间：2019-03-20 19:15:41
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using Entitas;

public class PlayerCreateSystem : IInitializeSystem
{
    private readonly Contexts _contexts;
    private readonly Services _services;

    public PlayerCreateSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _services = services;
    }

    public void Initialize()
    {
        var id = _services.Idservice.GetNext();

        _services.CreatePlayerService.CreatePlayer(id, _contexts.config.startPlayerPosition.value);

        //
    }
}
