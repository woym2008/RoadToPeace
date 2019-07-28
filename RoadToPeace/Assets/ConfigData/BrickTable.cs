using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class BrickTable : ScriptableObject
{
    public string TableName;

    public string[] BrickNames;

    public string[] NormalBrickNames;

    private void OnEnable()
    {
        ;
    }

    public int GetIndex(string name)
    {
        for(int i=0;i<BrickNames.Length;++i)
        {
            if(name == BrickNames[i])
            {
                return i;
            }
        }
        return -1;
    }

    public string GetBrickName(int index)
    {
        if(index < BrickNames.Length && index >=0)
        {
            return BrickNames[index];
        }
        return "";
    }

    public int GetNormalIndex(string name)
    {
        for (int i = 0; i < NormalBrickNames.Length; ++i)
        {
            if (name == NormalBrickNames[i])
            {
                return i;
            }
        }
        return -1;
    }

    public string GetNormalBrickName(int index)
    {
        if (index < NormalBrickNames.Length && index >= 0)
        {
            return NormalBrickNames[index];
        }
        return "";
    }
}
