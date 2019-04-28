using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpecialFloorData", menuName = "GameData/SpecialFloorData")]
public class SpecialFloorsDataScriptable : ScriptableObject, ISpecialFloor
{
    public int minlevel;
    public int maxlevel;
    public List<SpecialFloorData> floors;
    public string scene;

    public SpecialFloorData[] GetFloorData()
    {
        return floors.ToArray();
    }

    public int GetMaxLevel()
    {
        return maxlevel;
    }

    public int GetMinLevel()
    {
        return minlevel;
    }

    public string GetScene()
    {
        return scene;
    }
}
