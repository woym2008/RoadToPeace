using UnityEngine;
using System.Collections;

[CreateAssetMenu]
public class BrickTable : ScriptableObject
{
    public string TableName;

    public string[] BrickNames;

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
}
