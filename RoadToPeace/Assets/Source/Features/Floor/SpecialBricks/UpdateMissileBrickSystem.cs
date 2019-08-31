using UnityEngine;
using System.Collections;
using Entitas;

public class UpdateMissileBrickSystem : IExecuteSystem
{
    Contexts _contexts;
    Services _services;
    IGroup<GameEntity> _missilebricks;
    BrickTable _table;
    int _launchedID = -1;

    Vector3 _missileoffset = new Vector3(0,9.5f,0);

    public UpdateMissileBrickSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _services = services;

        _missilebricks = _contexts.game.GetGroup(GameMatcher.Missile);

        _table = _contexts.config.brickTable.table;

        _launchedID = _table.GetIndex("Mech_MissileLaunched");
    }
    public void Execute()
    {
        foreach(var missile in _missilebricks)
        {
            //只考虑中段，因为现在写的就是三段构成的导弹，中段前后和他的位置一致，那么就是ok的，拼接为导弹
            if(missile.missile.selfmissilepos == 1)
            {
                var premissile = missile.missile.preMissileBrick;
                var postmissle = missile.missile.postMissileBrick;
                if (premissile != null && postmissle!= null &&
                premissile.hasBrickParent && postmissle.hasBrickParent)
                {
                    var middileid = missile.brickParent.parent.gridID.id - missile.brickIndex.index;
                    var headid = premissile.brickParent.parent.gridID.id - premissile.brickIndex.index;
                    var tailid = postmissle.brickParent.parent.gridID.id - postmissle.brickIndex.index;

                    if((middileid == headid)&&(middileid == tailid))
                    {
                        //这就可以生成导弹了
                        //暂时先不写生成

                        //先写改变导弹地块
                        missile.ReplaceBrickBroken(_launchedID);
                        premissile.ReplaceBrickBroken(_launchedID);
                        postmissle.ReplaceBrickBroken(_launchedID);

                        missile.RemoveMissile();
                        premissile.RemoveMissile();
                        postmissle.RemoveMissile();
                        //改变完直接跳过这帧

                        var antibossmissile = _contexts.game.CreateEntity();
                        antibossmissile.AddAntiBossMissile(1);
                        antibossmissile.AddPosition(postmissle.position.position + _missileoffset);
                        antibossmissile.AddAsset("Boss/AntiBossRocket", 0);

                        Debug.Log("Fire Missile!!!!!!!");
                        break;
                    }
                }
            }
        }
    }
}
