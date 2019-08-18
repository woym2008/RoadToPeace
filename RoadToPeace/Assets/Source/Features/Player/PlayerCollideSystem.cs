using UnityEngine;
using UnityEditor;
using Entitas;

public class PlayerCollideSystem : IExecuteSystem
{
    private Contexts _contexts;
    private Services _serivces;
    private IGroup<GameEntity> _floors;
    public PlayerCollideSystem(Contexts contexts, Services services)
    {
        _contexts = contexts;
        _serivces = services;

        _floors = _contexts.game.GetGroup(GameMatcher.Floor);
    }

    public void Execute()
    {
        if(_contexts.game.gameState.state != GameState.Running)
        {
            return;
        }
        var player = _contexts.game.playerEntity;
        var halffloorwidth = _contexts.config.floorData.floorWidth * 0.5f;
        var floorheight = _contexts.config.floorData.floorHeight;
        if (player.hasPosition)
        {
            foreach(var floor in _floors)
            {
                if(floor.hasPosition)
                {
                    if(player.position.position.x > (floor.position.position.x - halffloorwidth) &&
                        player.position.position.x < (floor.position.position.x + halffloorwidth))
                    {
                        //enter this floor
                        var gridid = floor.gridID.id;

                        if (player.hasPlayerCurFloor)
                        {
                            var playerfloor = player.playerCurFloor.curFloor;
                            if (playerfloor == floor && gridid == playerfloor.gridID.id)
                            {
                                break;
                            }
                        }                        

                        var childs = floor.floorChild.childs;
                        var curbrick = childs[gridid];
                        var type = curbrick.brickType;
                        //var ispassed = curbrick.isIsBrickPassed;
                        if(curbrick.hasWayOfPassBrick)
                        {
                            var passway = curbrick.wayOfPassBrick.value;
                            switch(passway)
                            {
                                case PassBrickWay.Jump:
                                    {
                                        if (player.playerState.state == PlayerGameState.Run)
                                        {
                                            player.ReplacePlayerState(PlayerGameState.JumpUp);
                                        }
                                    }
                                    break;
                                case PassBrickWay.Collision:
                                    {
                                        if (player.playerState.state == PlayerGameState.Run)
                                        {
                                            //if (_contexts.game.hasLife)
                                            //{
                                            //    _contexts.game.ReplaceLife(0);
                                            //}
                                            if(player.hasLife)
                                            {
                                                player.ReplaceLife(player.life.lifeValue - 1);
                                            }
                                            //curbrick.isBrickBroken = true;
                                            curbrick.ReplaceBrickBroken(-1);
                                            //_serivces.CreateEffectService.CreateEffect("Dust", curbrick.position.position +
                                            //new Vector3(0, floorheight * 0.5f, 0), 10);
                                        }
                                    }
                                    break;
                            }
                        }

                        player.ReplacePlayerCurFloor(floor, gridid);

                        break;
                    }
                }
            }
        }
    }
}