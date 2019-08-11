using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

public class BossFightUpdateSystem : IExecuteSystem
{
    Contexts _contexts;

    public BossFightUpdateSystem(Contexts contexts)
    { 
        _contexts = contexts;
    }

    public void Execute()
    {
        if(_contexts.game.bossState.state == BossState.Fighting)
        {
            
        }
    }
}
public class BossThrowTowerUpdateSystem : IExecuteSystem
{
    Contexts _contexts;

    public BossThrowTowerUpdateSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if (_contexts.game.bossState.state == BossState.ThrowTower)
        {
            //create tower
        }
    }
}
public class BossHugeLazerUpdateSystem : IExecuteSystem
{
    Contexts _contexts;

    float _accumulateTime = 1;
    float _launchTime = 1;
    float _reduceTime = 1;

    float _maxlength = 0;

    IGroup<GameEntity> _blockbricks;
    IGroup<GameEntity> _hugelazer;
    IGroup<GameEntity> _boss;

    public BossHugeLazerUpdateSystem(Contexts contexts)
    {
        _contexts = contexts;

        _blockbricks = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.BrickType, GameMatcher.BrickYOffset, GameMatcher.Position, GameMatcher.BrickParent));
        _hugelazer = contexts.game.GetGroup(GameMatcher.BossHugeLazer);
        _boss = _contexts.game.GetGroup(GameMatcher.Boss);
    }

    public void Execute()
    {

        if (_contexts.game.bossState.state == BossState.HugeLazer)
        {
            var lazer = _hugelazer.GetSingleEntity();
            if (lazer.hasView)
            {
                GameEntity lastbrick_up = null;
                GameEntity lastbrick_middle = null;
                GameEntity lastbrick_down = null;

                float tempup_xoffset = -999;
                float tempmiddle_xoffset = -999;
                float tempdown_xoffset = -999;

                var hlc = _hugelazer.GetSingleEntity().view.Value.Transform.GetComponent<HugeLazerController>();
                var bossentity = _boss.GetSingleEntity();
                var bosscontroller = bossentity.view.Value.Transform.GetComponent<LazerShipController>();

                foreach (var b in _blockbricks)
                {
                    var floor = b.brickParent.parent;
                    var xoffset = floor.position.position.x;
                    if(xoffset > hlc.transform.position.x)
                    {
                        continue;
                    }
                    if(b.brickType.value == "Mech")
                    {
                        continue;
                    }

                    //gridid 是上下移动的位置 brickindex是brick在floor中的位置
                    //-1 ~ 1之间的数是中间三行
                    var index = floor.gridID.id - b.brickIndex.index;

                    switch(index)
                    {
                        //上面
                        case 1:
                            {
                                if(tempup_xoffset < xoffset)
                                {
                                    tempup_xoffset = xoffset;
                                    lastbrick_up = b;
                                }
                            }
                            break;
                        //中间
                        case 0:
                            {
                                if (tempmiddle_xoffset < xoffset)
                                {
                                    tempmiddle_xoffset = xoffset;
                                    lastbrick_middle = b;
                                }
                            }
                            break;
                        //下面
                        case -1:
                            {
                                if (tempdown_xoffset < xoffset)
                                {
                                    tempdown_xoffset = xoffset;
                                    lastbrick_down = b;
                                }
                            }
                            break;
                    }
                }

                var updis = hlc.maxlength;
                var middledis = hlc.maxlength;
                var downdis = hlc.maxlength;
                if (lastbrick_up != null)
                {
                    //updis = Vector3.Distance(lastbrick_up.position.position, bosscontroller.HugeLazerStartPoint.position);
                    updis = Mathf.Abs(lastbrick_up.position.position.x - bosscontroller.HugeLazerStartPoint.position.x);
                }
                if (lastbrick_middle != null)
                {
                    //middledis = Vector3.Distance(lastbrick_middle.position.position, bosscontroller.HugeLazerStartPoint.position);
                    middledis = Mathf.Abs(lastbrick_middle.position.position.x - bosscontroller.HugeLazerStartPoint.position.x);
                }
                if (lastbrick_down != null)
                {
                    //downdis = Vector3.Distance(lastbrick_down.position.position, bosscontroller.HugeLazerStartPoint.position);
                    downdis = Mathf.Abs(lastbrick_down.position.position.x - bosscontroller.HugeLazerStartPoint.position.x);
                }

                var lazerdata = lazer.bossHugeLazer;
                lazer.view.Value.Position = lazer.position.position;
                if (lazerdata.tomaxtime < lazerdata.maxtime)
                {
                    lazerdata.tomaxtime += Time.deltaTime;
                    float t = lazerdata.tomaxtime / lazerdata.maxtime;

                    float up_t = updis / hlc.maxlength;
                    float middle_t = middledis / hlc.maxlength;
                    float down_t = downdis / hlc.maxlength;
                    up_t = Mathf.Min(up_t, t);
                    middle_t = Mathf.Min(middle_t, t);
                    down_t = Mathf.Min(down_t, t);

                    hlc.SetUpLazerLength(up_t);
                    hlc.SetMiddleLazerLength(middle_t);
                    hlc.SetDownLazerLength(down_t);
                    //需要算起点到最后一个brick与起点到终点的比值

                    //再取这个值和t的最小者最为传入的t
                }
                else
                {
                    float up_t = updis / hlc.maxlength;
                    float middle_t = middledis / hlc.maxlength;
                    float down_t = downdis / hlc.maxlength;
                    up_t = Mathf.Min(up_t, 1);
                    middle_t = Mathf.Min(middle_t, 1);
                    down_t = Mathf.Min(down_t, 1);

                    hlc.SetUpLazerLength(up_t);
                    hlc.SetMiddleLazerLength(middle_t);
                    hlc.SetDownLazerLength(down_t);
                }
            }

        }
    }
}
//--------------------------------------------------------------------------
public class BossThrowTowerEnterSystem : ReactiveSystem<GameEntity>
{
    Contexts _contexts;

    public BossThrowTowerEnterSystem(Contexts contexts) :
        base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            //e.ReplaceBossState(BossState.Debut);

            //计时结束 记得remove 计时属性
            //e.RemoveHugeLazerUpdateData();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.bossState.state == BossState.ThrowTower;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BossState);
    }
}
public class BossHugeLazerEnterSystem : ReactiveSystem<GameEntity>
{
    Contexts _contexts;

    public BossHugeLazerEnterSystem(Contexts contexts) :
        base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        //准备发射一个大激光
        //激光特效开始准备发射
        //倒计时开始

        var e = _contexts.game.CreateEntity();
        e.AddBossHugeLazer(5, 0.5f, 0, 0, 0, 0);
        e.AddAsset("Boss/Skill/HugeLazer",0);

        var bossentity = _contexts.game.GetGroup(GameMatcher.Boss).GetSingleEntity();
        var startpoint = bossentity.view.Value.Transform.GetComponent<LazerShipController>().HugeLazerStartPoint;
        e.ReplacePosition(startpoint.position);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.bossState.state == BossState.HugeLazer;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BossState);
    }
}