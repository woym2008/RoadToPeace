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
    public List<string> RealBrickPath = new List<string>();
    public List<string> NormalBrickRes = new List<string>();
    public List<string> NormalBrickPath = new List<string>();
    public Transform FirstPos;
    public Transform OverPos;
    public float FloorWidth;
    public float FloorHeight;
    public int NumFloor = 10;
    //----------------------------------
    public BrickTable BrickReses;
    //----------------------------------
    public Transform GameDirectPoint;
    //----------------------------------

    public Transform GroundFirstPos;
    public Transform GroundOverPos;
    public float GroundWidth;
    public float GroundHieght;
    public int NumGround = 10;

    public int NumGroundRow = 2;
    //----------------------------------
    public List<string> GroundRes = new List<string>();
    public List<string> GroundPath = new List<string>();
    //----------------------------------

    public float FloorSpeed = 1.0f;
    public float FloorSpeedUpValue = 0.5f;

    public Transform PlayerPos;
    public Transform PlayerRunPos;

    public Transform CameraRunningPos;
    public Transform CameraTitlePos;

    public float PlayerJumpUpSpeed = 1;
    public float PlayerJumpOffSpeed = 1;
    public float PlayerJumpHeight = 1;

    public float DifficultLevelUpTime = 20.0f;
    //----------------------------------
    //boss
    public float BossDebutTime = 4.0f;
    //---
    public Transform BossStartPoint;
    public Transform BossEndPoint;
    public float BossReadyTime = 5.0f;
    public float BossThinkTime = 1.0f;
    public float BossHp = 10.0f;

    public List<string> BossNames = new List<string>();
    //----------------------------------
    private void Awake()
    {
        var contexts = Contexts.sharedInstance;
        contexts.config.ReplaceGameForward(GameDirectPoint);

        contexts.config.ReplaceFloorData(
            FloorWidth,
            FloorHeight,
            FirstPos.position,
            OverPos.position,
            NumFloor
            );
        /*
        for(int i=0;i<BrickRes.Count;++i)
        {
            RealBrickPath.Add("Brick/" + BrickRes[i]);
        }*/
        for (int i = 0; i < BrickReses.BrickNames.Length; ++i)
        {
            RealBrickPath.Add("Brick/" + BrickReses.BrickNames[i]);
        }
        for (int i = 0; i < BrickReses.NormalBrickNames.Length; ++i)
        {
            NormalBrickPath.Add("Brick/" + BrickReses.NormalBrickNames[i]);
        }


        for (int i= 0; i<GroundRes.Count; ++i)
        {
            GroundPath.Add("Ground/" + GroundRes[i]);
        }

        contexts.config.ReplaceGroundList(GroundPath);
        contexts.config.ReplaceGroundData(GroundWidth, GroundHieght,
        GroundFirstPos.position, GroundOverPos.position, NumGround,
            NumGroundRow);

        contexts.config.ReplaceBrickResBase("Brick/");
        contexts.config.ReplaceBrickTypeList(RealBrickPath);
        contexts.config.ReplaceNormalBrickTypeList(NormalBrickPath);

        contexts.config.ReplaceStartPlayerPosition(PlayerPos.position);

        contexts.config.ReplaceRunPlayerPosition(PlayerRunPos.position);

        //contexts.config.ReplaceBrickTypeCount(BrickRes.Count);
        contexts.config.ReplaceBrickTypeCount(BrickReses.BrickNames.Length);
        contexts.config.ReplaceBrickTable(BrickReses);

        contexts.config.ReplaceCameraPos(CameraRunningPos.position, CameraTitlePos.position);

        //初始化 速度和目标速度都一样
        contexts.game.SetFloorSpeed(FloorSpeed, FloorSpeed);
        contexts.config.SetFloorBaseSpeed(FloorSpeed);

        contexts.config.ReplacePlayerData(
            PlayerJumpUpSpeed,
            PlayerJumpOffSpeed,
            PlayerJumpHeight
            );

        contexts.config.ReplaceDifficultLevelup(DifficultLevelUpTime);

        contexts.config.ReplaceFloorSpeedUp(FloorSpeedUpValue);
        //------------------------------------------------------
        contexts.config.ReplaceBossDebutTime(BossDebutTime);

        contexts.config.ReplaceBossData(
        BossStartPoint.position,
        BossEndPoint.position,
        BossHp,
        BossReadyTime,
        BossThinkTime
            );

        contexts.config.ReplaceBossNames(BossNames);

        //contexts.config.ReplaceBossDebutTime(BossDebutTime);

        contexts.game.ReplaceBossState(BossState.Null);
    }
    private void Start()
    {
        
    }
}
