using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpecialFloorData", menuName = "GameData/SpecialFloorData")]
public class SpecialFloorsDataScriptable : ScriptableObject, ISpecialFloor
{
    public int minlevel;
    public int maxlevel;
    public bool bossfight;
    public string bossname;
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

    private BrickTable _table = null;
    private string _bricktablename;
    const string tablepathbase = "BrickTable/";
    public void SetBrickTableName(string name)
    {
        _bricktablename = name;
    }
    public BrickTable GetBrickTable()
    {
        if(_table == null)
        {
            var tablepath = tablepathbase + _bricktablename;
            _table = Resources.Load<BrickTable>(tablepath);
        }

        return _table;
    }

    public override string ToString()
    {
        return "bossname" + bossname + " bricktablename" + _bricktablename;
    }
}
