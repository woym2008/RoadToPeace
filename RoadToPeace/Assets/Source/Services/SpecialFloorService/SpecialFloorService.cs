using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpecialFloorService : Service
{
    private List<SpecialFloorsDataScriptable> _specialFloorsRes;
    private string specialpath = "FloorsDatas"; 
    public SpecialFloorService(Contexts contexts) : base(contexts)
    {
        LoadData();
    }

    public ISpecialFloor[] GetFloorData(int level)
    {
        List<ISpecialFloor> finddatas = new List<ISpecialFloor>();
        foreach(var data in _specialFloorsRes)
        {
            if(data.GetMinLevel() == level)
            {
                finddatas.Add(data);
            }
        }

        return finddatas.ToArray();
    }

    public void LoadData()
    {
        _specialFloorsRes = new List<SpecialFloorsDataScriptable>();
        var floorobjs = Resources.LoadAll<SpecialFloorsDataScriptable>(specialpath);
        foreach (var floorobj in floorobjs)
        {
            _specialFloorsRes.Add(floorobj);

            Debug.Log("Load Special Floor" + floorobj.name);
        }
        Debug.Log("Load Data Finish");
    }
}
