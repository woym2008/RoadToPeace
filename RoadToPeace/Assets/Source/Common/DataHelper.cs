using UnityEngine;
using System.Collections;

public class FloorDataHelper
{
    static public string[] type =
    {
        "Grass_1",
        "Grass_2",
        "Wasteland_1",
        "Wasteland_2"
    };
}

public class BrickDataHelper
{
    static public string[] type =
    {
        "Normal",
        "Trap",
        "Jump",
        "Bonfire",
        "Firewood",
        "Battery",

    };

    static public int GetIndex(string typestr){
    
        for(int i=0;i<type.Length;++i){
            if(type[i] == typestr){
                return i;
            }
        }
    
        return -1;
    }
}
