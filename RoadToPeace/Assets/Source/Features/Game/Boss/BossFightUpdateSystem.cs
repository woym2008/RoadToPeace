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

public class BossThinkEnterSystem : ReactiveSystem<GameEntity>
{
    Contexts _contexts;

    IGroup<GameEntity> _boss;
    public BossThinkEnterSystem(Contexts contexts)
        : base(contexts.game)
    {
        _contexts = contexts;
        _boss = contexts.game.GetGroup(GameMatcher.Boss);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var boss = _boss.GetSingleEntity();
        //var bossthinking = _contexts.game.CreateEntity();
        boss.AddTimer(0);

        int randtype = UnityEngine.Random.Range(0, 2);
        boss.AddBossThinking(randtype);


        //在开始思考的时候放置一组missile 可能不太对 但先放在这
        var missilefloorentity = _contexts.game.CreateEntity();
        missilefloorentity.isCreateMissileFloor = true;
        missilefloorentity.isBossCreateFloor = true;
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.bossState.state == BossState.Thinging;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.BossState);
    }
}

public class BossThinkUpdateSystem : IExecuteSystem
{
    Contexts _contexts;
    IGroup<GameEntity> _bossthinkentity;

    float _thinktime = 3;

    public BossThinkUpdateSystem(Contexts contexts)
    {
        _contexts = contexts;
        _bossthinkentity = _contexts.game.GetGroup(GameMatcher.BossThinking);
    }
    public void Execute()
    {
        if(_contexts.game.bossState.state == BossState.Thinging)
        {
            var thinkentity = _bossthinkentity.GetSingleEntity();
            if(thinkentity != null)
            {
                if(thinkentity.timer.passedTime > _thinktime)
                {

                    switch(thinkentity.bossThinking.bossAttackType)
                    {
                        //lazer
                        case 0:
                            {
                                _contexts.game.ReplaceBossState(BossState.HugeLazer);
                            }
                            break;
                        //tower
                        case 1:
                            {
                                _contexts.game.ReplaceBossState(BossState.ThrowTower);
                            }
                            break;
                    }
                    thinkentity.RemoveBossThinking();
                    thinkentity.RemoveTimer();

                }
            }
        }
    }
}

public class BossThrowTowerUpdateSystem : IExecuteSystem
{
    Contexts _contexts;

    IGroup<GameEntity> _param;

    float _towerstatetime = 5;

    public BossThrowTowerUpdateSystem(Contexts contexts)
    {
        _contexts = contexts;
        _param = contexts.game.GetGroup(GameMatcher.BossFightParam);
    }

    public void Execute()
    {
        if (_contexts.game.bossState.state == BossState.ThrowTower)
        {
            var e = _param.GetSingleEntity();
            if(e.timer.passedTime > _towerstatetime)
            {
                _contexts.game.ReplaceBossState(BossState.Thinging);

                e.isDestroyed = true;
            }

        }
    }
}
public class BossHugeLazerUpdateSystem : IExecuteSystem
{
    Contexts _contexts;

    float _accumulateTime = 3;
    float _launchTime = 2;
    float _reduceTime = 1;

    float _maxlength = 0;
     
    int _lazerstate = 0;//0 finish 1 accumulate  2 launch  3reduce

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
            bool isLazerHitPlayer = false;

            var player = _contexts.game.playerEntity;

            //更新激光射击到到位置
            var lazer = _hugelazer.GetSingleEntity();
            if(lazer == null || !lazer.hasTimer)
            {
                return;
            }
            var passedtime = lazer.timer.passedTime;

            //开始蓄力
            if(_lazerstate == 0)
            {
                _lazerstate = 1;
                //Debug.LogWarning("ready");
            }
            //蓄力完成 发射
            if (passedtime > _accumulateTime && _lazerstate == 1)
            {
                _lazerstate = 2;

                //Debug.LogWarning("fire");
            }
            //发射完成 开始减弱
            if (passedtime > (_accumulateTime + _launchTime) && _lazerstate == 2)
            {
                _lazerstate = 3;

                //Debug.LogWarning("reduce");
            }
            //状态完成
            if (passedtime > (_accumulateTime + _launchTime + _reduceTime) && _lazerstate == 3)
            {
                //Debug.LogWarning("finish");

                _lazerstate = 0;

                lazer.isDestroyed = true;

                _contexts.game.ReplaceBossState(BossState.Thinging);
            }

            switch(_lazerstate)
            {
                case 1:
                    if (lazer.hasView)
                    {
                        var hlc = _hugelazer.GetSingleEntity().view.Value.Transform.GetComponent<HugeLazerController>();
                        hlc.SetUpLazerLength(0);
                        hlc.SetMiddleLazerLength(0);
                        hlc.SetDownLazerLength(0);
                    }
                    break;
                case 2:
                    {
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
                                if(!floor.hasPosition)
                                {
                                    continue;
                                }
                                var xoffset = floor.position.position.x;
                                if (xoffset > hlc.transform.position.x)
                                {
                                    continue;
                                }
                                if (b.brickType.value == "Mech")
                                {
                                    continue;
                                }

                                //gridid 是上下移动的位置 brickindex是brick在floor中的位置
                                //-1 ~ 1之间的数是中间三行
                                var index = floor.gridID.id - b.brickIndex.index;

                                switch (index)
                                {
                                    //上面
                                    case 1:
                                        {
                                            if (tempup_xoffset < xoffset)
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
                            //中间的比较特殊，因为是人走的地方，要判断人和阻挡物谁在前
                            if (lastbrick_middle != null)
                            {
                                var finalx = lastbrick_middle.position.position.x;
                                if (player.position.position.x > lastbrick_middle.position.position.x)
                                {
                                    finalx = player.position.position.x;

                                    //走到了这里 说明主角被大激光打中了
                                    isLazerHitPlayer = true;
                                }
                                //middledis = Vector3.Distance(lastbrick_middle.position.position, bosscontroller.HugeLazerStartPoint.position);
                                middledis = Mathf.Abs(finalx - bosscontroller.HugeLazerStartPoint.position.x);
                            }
                            else
                            {
                                middledis = Mathf.Abs(player.position.position.x - bosscontroller.HugeLazerStartPoint.position.x);
                                isLazerHitPlayer = true;
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
                            //------------------------------------
                            //------------------------------------
                        }
                    }
                    break;
                case 3:
                    {

                    }
                    break;
            }

            //处理主角受到打击
            if(isLazerHitPlayer)
            {
                if(player.hasLife)
                {
                    player.ReplaceLife(player.life.lifeValue - 0.02f);
                }
            }
        }
    }
}
//--------------------------------------------------------------------------
public class BossDieSystem : ReactiveSystem<GameEntity>
{
    Contexts _contexts;
    public BossDieSystem(Contexts contexts) :
        base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var boss = entities.SingleEntity();

        _contexts.game.ReplaceBossState(BossState.Ready);

        _contexts.game.ReplaceBossDebutCountDown(10);
    }

    protected override bool Filter(GameEntity entity)
    {
        return (entity.life.lifeValue <= 0);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.AllOf(GameMatcher.Boss,GameMatcher.Life));
    }
}
//--------------------------------------------------------------------------
public class BossThrowTowerEnterSystem : ReactiveSystem<GameEntity>
{
    Contexts _contexts;

    IGroup<GameEntity> _floors;

    int numtolast = 10;
    int numtower = 3;

    public BossThrowTowerEnterSystem(Contexts contexts) :
        base(contexts.game)
    {
        _contexts = contexts;

        _floors = _contexts.game.GetGroup(GameMatcher.Floor);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        /*
        //在新的floor上创建tower       
        //创建多少个tower 就是创建多少个floor
        //中间可以隔着个floor
        //目前写死5个
        for(int i=0; i<5; ++i)
        {
            var entityTower = _contexts.game.CreateEntity();
            entityTower.isBossCreateFloor = true;
            entityTower.isIsLazerTowerFloor = true;

            var entityEmpty = _contexts.game.CreateEntity();
            entityEmpty.isBossCreateFloor = true;
        }
        */

        //直接在现有的floor上创建tower
        //find lastest
        GameEntity findfloor = null;
        foreach(var f in _floors)
        {
            if(f.isLastFloor)
            {
                findfloor = f;
                break;
            }
        }

        if(findfloor != null)
        {
            for(int i=0;i<numtolast; ++ i)
            {
                Debug.Log(i);
                if(findfloor.hasFloorBrother)
                {
                    findfloor = findfloor.floorBrother.Left;
                }

            }


            for(int i=0;i<numtower; ++i)
            {
                if(findfloor != null && findfloor.hasFloorBrother && findfloor.floorBrother.Right != null)
                {
                    findfloor.isIsLazerTowerFloor = true;

                    var towerEntity = _contexts.game.CreateEntity();
                    towerEntity.AddObjectParent(findfloor);
                    towerEntity.isLazerTower = true;
                    findfloor.AddChild(towerEntity);

                    findfloor = findfloor.floorBrother.Right;
                    if(findfloor.hasFloorBrother)
                        findfloor = findfloor.floorBrother.Right;
                }
            }
        }
        //----------------
        var e = _contexts.game.CreateEntity();
        e.isBossFightParam = true;
        e.AddTimer(0);
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
        e.ReplaceTimer(0.0f);

        var blocklazerfloor = _contexts.game.CreateEntity();
        blocklazerfloor.isBossCreateFloor = true;
        blocklazerfloor.isIsBlockLazerFloor = true;


        var missilefloor = _contexts.game.CreateEntity();
        missilefloor.isBossCreateFloor = true;
        missilefloor.isMissileFloor = true;
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

public class TowerInitSystem : ReactiveSystem<GameEntity>
{
    Contexts _contexts;
    Services _services;
    public TowerInitSystem(Contexts contexts, Services services) :
        base(contexts.game)
    {
        _contexts = contexts;
    }
    protected override void Execute(List<GameEntity> entities)
    {
        var height = _contexts.config.bossData.lazertowerheight;

        foreach(var e in entities)
        {
            e.AddAsset("Boss/Skill/Lazer_Tower",0);
            e.AddHp(1);
            e.AddPosition(new Vector3(0, height, 0));

            //var effectEntity = _contexts.game.CreateEntity();
            //e.AddChild(effectEntity);
            //effectEntity.AddAsset("Boss/Effect/Spark",0);

            //effectEntity.AddPosition(new Vector3(0, height, 0));
            //effectEntity.isBossTowerEffect = true;
            //需要给effect加个名字 下面update的时候找到他

        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.LazerTower.Added());
    }
}

public class TowerUpdateSystem : IExecuteSystem
{
    Contexts _contexts;
    Services _services;

    IGroup<GameEntity> _towers;

    float _distance;

    public TowerUpdateSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _services = services;

        _towers = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.LazerTower,GameMatcher.View));

        _distance = _contexts.config.groundData.groundHeight;
    }
    public void Execute()
    {
        foreach(var e in _towers)
        {
            var floor = e.objectParent;
            if(floor.parent.hasPosition)
            {
                e.view.Value.Position = new Vector3(floor.parent.position.position.x, e.position.position.y, _distance);
                if(e.hasChild && e.child.value.hasPosition)
                {
                    e.child.value.position.position = e.view.Value.Position;
                    if(e.child.value.hasView)
                    {
                        e.child.value.view.Value.Position = e.view.Value.Position;
                    }
                }
            }

            //判读是否击毁
            if (floor.parent.gridID.id == 2)
            {
                e.hp.hp -= Time.deltaTime;
                if(e.hp.hp <= 0)
                {
                    e.isDestroyed = true;
                }

                if (e.hasChild && e.child.value.hasView && !e.child.value.view.Value.Enabled)
                {
                    e.child.value.view.Value.Enabled = true;
                }
            }
            else
            {
                if (e.hasChild && e.child.value.hasView && e.child.value.view.Value.Enabled)
                {
                    e.child.value.view.Value.Enabled = false;
                }
            }

            //对block，顺便判断下激光能打到第几个brick


            //激光判定
            //对主角
            var player = _contexts.game.playerEntity;
            var halffloorwidth = _contexts.config.floorData.floorWidth * 0.5f;
            if (player.position.position.x > (floor.parent.position.position.x - halffloorwidth) &&
                        player.position.position.x < (floor.parent.position.position.x + halffloorwidth))
            {
                //暂时写成 激光打中这个floor 就击中了player

                if (player.hasLife)
                {
                    player.ReplaceLife(player.life.lifeValue - 0.01f);
                }
            }


        }
    }
}
public class OnDeleteTowerFloorSystem : ReactiveSystem<GameEntity>
{
    Contexts _contexts;
    IGroup<GameEntity> _towers;
    public OnDeleteTowerFloorSystem(Contexts contexts) :
        base(contexts.game)
    {
        _contexts = contexts;
        _towers = _contexts.game.GetGroup(GameMatcher.LazerTower);
    }
    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var floor in entities)
        { 
            foreach(var tower in _towers)
            {
                if(tower.objectParent.parent == floor)
                {
                    tower.isDestroyed = true;
                }
            }
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.IsLazerTowerFloor.Removed());
    }
}

public class AntiBossMissileSystem : IExecuteSystem
{
    IGroup<GameEntity> _missiles;
    Contexts _contexts;
    private IGroup<GameEntity> _floors;
    private IGroup<GameEntity> _boss;

    Vector3 _speed = new Vector3(3,0,0);
    float _bossedgeoffset = 2;
    public AntiBossMissileSystem(Contexts contexts)
    {
        _contexts = contexts;

        _missiles = _contexts.game.GetGroup(GameMatcher.AntiBossMissile);

        _floors = _contexts.game.GetGroup(GameMatcher.Floor);

        _boss = _contexts.game.GetGroup(GameMatcher.Boss);
    }

    public void Execute()
    {
        var halffloorwidth = _contexts.config.floorData.floorWidth * 0.5f;
        var floorheight = _contexts.config.floorData.floorHeight;

        foreach (var missile in _missiles)
        {
            missile.position.position += _speed * Time.deltaTime;

            if (missile.hasView)
            {
                missile.view.Value.Transform.position = missile.position.position;


                foreach (var floor in _floors)
                {
                    if (floor.hasPosition)
                    {
                        #region collide floor
                        if (missile.position.position.x > (floor.position.position.x - halffloorwidth) &&
                            missile.position.position.x < (floor.position.position.x + halffloorwidth))
                        {
                            //enter this floor
                            var gridid = floor.gridID.id;

                            if (missile.hasPlayerCurFloor)
                            {
                                var missilefloor = missile.playerCurFloor.curFloor;
                                if (missilefloor == floor && gridid == missilefloor.gridID.id)
                                {
                                    break;
                                }
                            }

                            var childs = floor.floorChild.childs;
                            var curbrick = childs[gridid];
                            //var type = curbrick.brickType;
                            //var ispassed = curbrick.isIsBrickPassed;
                            if (curbrick.hasWayOfPassBrick && curbrick.wayOfPassBrick.value == PassBrickWay.AirCollision)
                            {
                                //导弹爆炸
                                //释放爆炸特效
                                //
                                missile.isDestroyed = true;
                            }

                            missile.ReplacePlayerCurFloor(floor, gridid);

                        }
                        #endregion

                        #region collide boss
                        var boss = _boss.GetSingleEntity();
                        if(boss != null)
                        {
                            var bosspos = boss.position.position;
                            if (missile.position.position.x > (bosspos.x - _bossedgeoffset))
                            {
                                if (missile.position.position.x < (bosspos.x + _bossedgeoffset))
                                {
                                    //击中boss 之所以加个这个，是因为可能出现导弹开始时候就拼好了的情况，就不要打中boss了
                                    //释放爆炸特效
                                    //boss掉血
                                    boss.ReplaceLife(boss.life.lifeValue - missile.antiBossMissile.power);
                                }
                                missile.isDestroyed = true;
                            }
                        }
                        #endregion

                        break;
                    }

                }
            }
        }
    }
}
