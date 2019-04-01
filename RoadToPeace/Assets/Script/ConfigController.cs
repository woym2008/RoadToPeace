/* ========================================================
 *	类名称：ConfigController
 *	作 者：Zhangfan
 *	创建时间：2019-03-26 16:18:37
 *	版 本：V1.0.0
 *	描 述：
* ========================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ConfigController : MonoBehaviour
{
    public List<string> BrickRes = new List<string>();
    public Transform FirstPos;
    public Transform OverPos;
    public float FloorWidth;
    public float FloorHeight;
    public int NumFloor = 10;

    public float FloorSpeed = 1.0f;


    public Transform PlayerPos;
    public Transform PlayerRunPos;

    public Transform CameraRunningPos;
    public Transform CameraTitlePos;

    private void Awake()
    {
        var contexts = Contexts.sharedInstance;
        contexts.config.ReplaceFloorData(
            FloorWidth,
            FloorHeight,
            FirstPos.position,
            OverPos.position,
            NumFloor
            );

        contexts.config.ReplaceBrickTypeList(BrickRes);

        contexts.config.ReplaceStartPlayerPosition(PlayerPos.position);

        contexts.config.ReplaceRunPlayerPosition(PlayerRunPos.position);

        contexts.config.ReplaceBrickTypeCount(BrickRes.Count);

        contexts.config.ReplaceCameraPos(CameraRunningPos.position, CameraTitlePos.position);

        contexts.game.SetFloorSpeed(FloorSpeed);
    }
    private void Start()
    {
        
    }
}
