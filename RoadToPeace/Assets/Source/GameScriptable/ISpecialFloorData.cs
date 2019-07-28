using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SpecialFloorData
{
    public int type;
    public string brick1_data;
    public string brick2_data;
    public string brick3_data;
}

public interface ISpecialFloor
{
    SpecialFloorData[] GetFloorData();
    int GetMaxLevel();
    int GetMinLevel();
    string GetScene();//用去区分哪个场景使用这个块
    BrickTable GetBrickTable();
}
