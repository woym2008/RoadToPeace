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
        var player = _contexts.game.playerEntity;
        var floorwidth = _contexts.config.floorData.floorWidth;
        if(player.hasPosition)
        {
            foreach(var floor in _floors)
            {
                if(floor.hasPosition)
                {
                    if(player.position.position.x > (floor.position.position.x - floorwidth) &&
                        player.position.position.x < (floor.position.position.x + floorwidth))
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
                        var ispassed = curbrick.isIsBrickPassed;
                        
                        if (!ispassed)
                        {
                            Debug.LogError("block!!! brick id is: " + gridid);
                            Debug.LogError("block brick object: " + curbrick.view.Value.Transform.name);
                            _contexts.game.isGameOver = true;
                        }

                        player.ReplacePlayerCurFloor(floor, gridid);

                        break;
                    }
                }
            }
        }
    }
}