using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

public class EditorBrick
{
    public int bricktype;
}
public class EditorFloor
{
    public int startpos;
    public int floortype;
    public EditorBrick[] bricks;
    public EditorFloor()
    {
        startpos = 0;
        floortype = 0;

        bricks = new EditorBrick[3];
        for(int i=0; i <bricks.Length; ++i)
        {
            bricks[i] = new EditorBrick();
            bricks[i].bricktype = 0;
        }
    }
}
[ExecuteInEditMode]
public class SpecialFloorEditor : EditorWindow
{
    public BrickTable _brickTable;
    string _curBrickTableName;

    private GUIContent LoadBtn = new GUIContent("Load");
    private GUIContent SaveBtn = new GUIContent("Save");
    private GUIContent NewBtn = new GUIContent("New");
    private GUIContent AddBtn = new GUIContent("Add");
    private GUIContent RemoveBtn = new GUIContent("Remove");

    private Rect barRect = new Rect(5, 5, 400, 20);

    private Rect editWindowRect = new Rect(5, 50, 400, 300);

    private Rect editFloorRect = new Rect(5, 350, 400, 100);

    private Rect editBrickRect = new Rect(5, 450, 400, 100);

    private List<SpecialFloorData> datas = new List<SpecialFloorData>();

    private Vector2 bricksize = new Vector2(64, 48);
    private Vector2 startpos = new Vector2(150, 150);
    private int _startposoffset = 0;

    private int _selectFloorID = -1;
    private int _selectBrickID = -1;

    private int _maxLevel = 0;
    private int _minLevel = 0;

    [MenuItem("Window/SpecialFloorEditor")]
    static void Init()
    {
        GetWindow(typeof(SpecialFloorEditor));


    }

    private void OnGUI()
    {
        if(_brickTable == null)
        {
            _brickTable = Resources.Load<BrickTable>("BrickTable/defaultscene");
            if(_brickTable != null)
            {
                _curBrickTableName = _brickTable.TableName;
            }
        }
        GUI.BeginScrollView(new Rect(0, 0, position.width, position.height), new Vector2(0, 0), new Rect(0, 0, 200, 400));
        BeginWindows();

        barRect = GUILayout.Window(0, barRect, DoToolbarWindow, "Tool Bar");

        editWindowRect = GUILayout.Window(1, editWindowRect, DoEditWindow, "Edit Floor");

        if(_selectFloorID >= 0 && _Floors != null && _Floors.Count > _selectFloorID)
        {
            editFloorRect = GUILayout.Window(2, editFloorRect, DoFloorWindow, "Floor Data");
            if(_selectBrickID != -1)
            {
                editBrickRect = GUILayout.Window(3, editBrickRect, DoBrickWindow, "Brick Data");
            }
        }
        //
        //
        /*
        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button(SaveBtn))
        {
            ;
        }
        if(GUILayout.Button(LoadBtn))
        {

        }
        EditorGUILayout.EndHorizontal();
        */

        EndWindows();
        GUI.EndScrollView();
    }

    private void DoToolbarWindow(int wid)
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button(NewBtn))
        {
            bool enableload = false;
            if (_Floors != null)
            {
                if (EditorUtility.DisplayDialog("是否确定重建", "重新建立一组Floor", "确定", "取消"))
                {
                    enableload = true;
                }
            }
            else
            {
                enableload = true;
            }
            if (enableload)
            {
                _Floors = new List<EditorFloor>();
                _Floors.Add(new EditorFloor());
                _maxLevel = 0;
                _minLevel = 0;
            }
        }
        if (GUILayout.Button(SaveBtn))
        {
            string pathstr = EditorUtility.SaveFilePanel("Save Special Floors", "Assets/Resources/FloorsDatas", "","Asset");
            var strs = pathstr.Split('/');
            if(strs != null && strs.Length > 1)
            {
                var names = strs[strs.Length - 1].Split('.');
                SaveData(names[0]);
            }

            Debug.Log(pathstr);
        }
        if (GUILayout.Button(LoadBtn))
        {
            bool enableload = false;
            if (_Floors != null)
            {
                if (EditorUtility.DisplayDialog("警告", "是否放弃当前内容，加载其他数据", "确定", "取消"))
                {
                    enableload = true;
                }
            }
            else
            {
                enableload = true;
            }

            if(enableload)
            {
                string pathstr = EditorUtility.OpenFilePanel("Load Special Floors", "Resources/FloorsDatas", "Asset");
                var strs = pathstr.Split('/');
                if (strs != null && strs.Length > 1)
                {
                    var names = strs[strs.Length - 1].Split('.');
                    LoadData(names[0]);
                }
                Debug.Log(pathstr);
            }
        }

        if (GUILayout.Button(AddBtn))
        {
            if(_Floors != null)
            {
                _Floors.Add(new EditorFloor());
            }
        }
        if (GUILayout.Button(RemoveBtn))
        {
            if (_Floors != null && _selectFloorID < _Floors.Count && _selectFloorID >= 0)
            {
                _Floors.RemoveAt(_selectFloorID);
                _selectFloorID = -1;
                _selectBrickID = -1;
            }
        }
        EditorGUILayout.EndHorizontal();
    }
    private List<EditorFloor> _Floors;
    private void DoEditWindow(int wid)
    {
        EditorGUILayout.BeginHorizontal();
        if(_Floors != null)
        {
            var realstartpos = startpos.x + _startposoffset * bricksize.x * -1;
            var realspos_x = realstartpos - bricksize.x * _Floors.Count * 0.5f;
            for (int i = 0; i < _Floors.Count; ++i)
            {
                //EditorGUI.DrawRect(new Rect(realspos_x + i* bricksize.x,startpos.y, bricksize.x, bricksize.y), new Color(1, 1, 0));
                /*
                if(GUI.Button(new Rect(realspos_x + i * bricksize.x, startpos.y + bricksize.y + bricksize.y * (_Floors[i].startpos), bricksize.x, bricksize.y), BrickDataHelper.type[_Floors[i].bricks[0].bricktype]))
                {
                    _selectFloorID = i;
                    _selectBrickID = 0;
                }
                if (GUI.Button(new Rect(realspos_x + i * bricksize.x, startpos.y + bricksize.y * (_Floors[i].startpos), bricksize.x, bricksize.y), BrickDataHelper.type[_Floors[i].bricks[1].bricktype]))
                {
                    _selectFloorID = i;
                    _selectBrickID = 1;
                }
                if (GUI.Button(new Rect(realspos_x + i * bricksize.x, startpos.y - bricksize.y + bricksize.y * (_Floors[i].startpos), bricksize.x, bricksize.y), BrickDataHelper.type[_Floors[i].bricks[2].bricktype]))
                {
                    _selectFloorID = i;
                    _selectBrickID = 2;
                }*/
                if (GUI.Button(new Rect(realspos_x + i * bricksize.x, startpos.y + bricksize.y + bricksize.y * (_Floors[i].startpos), bricksize.x, bricksize.y), 
                _brickTable.BrickNames[_Floors[i].bricks[0].bricktype]))
                {
                    _selectFloorID = i;
                    _selectBrickID = 0;
                }
                if (GUI.Button(new Rect(realspos_x + i * bricksize.x, startpos.y + bricksize.y * (_Floors[i].startpos), bricksize.x, bricksize.y),
                _brickTable.BrickNames[_Floors[i].bricks[1].bricktype]))
                {
                    _selectFloorID = i;
                    _selectBrickID = 1;
                }
                if (GUI.Button(new Rect(realspos_x + i * bricksize.x, startpos.y - bricksize.y + bricksize.y * (_Floors[i].startpos), bricksize.x, bricksize.y),
                _brickTable.BrickNames[_Floors[i].bricks[2].bricktype]))
                {
                    _selectFloorID = i;
                    _selectBrickID = 2;
                }
            }
        }

        //bricktable
        BrickTable temptable = null;
        temptable = EditorGUILayout.ObjectField(_brickTable, typeof(BrickTable),false) as BrickTable;
        if(temptable != null && _curBrickTableName != temptable.TableName)
        {
            _curBrickTableName = temptable.TableName;
            _brickTable = temptable;
        }

        //GUI.Button()
        _maxLevel = EditorGUILayout.IntField("Max Level", _maxLevel);
        _minLevel = EditorGUILayout.IntField("Mix Level", _minLevel);
        _startposoffset = EditorGUILayout.IntSlider(_startposoffset, -10, 10);

        EditorGUILayout.EndHorizontal();
        //GUI.BeginScrollView(new Rect(0, 0, 200, 400), new Vector2(0, 0), new Rect(0, 0, 200, 400));

        //EditorGUI.DrawRect(new Rect(32, 32, 32, 32), new Color(1, 1, 0));

        //GUI.EndScrollView();
    }

    private void DoFloorWindow(int wid)
    {
        EditorGUILayout.BeginHorizontal();
        //EditorGUI.DrawRect(new Rect(startpos.x, startpos.y, bricksize.x, bricksize.y), new Color(1, 1, 0));
        //GUI.Button()
        var curfloor = _Floors[_selectFloorID];
        curfloor.startpos = EditorGUILayout.IntSlider(curfloor.startpos, -1, 1);
        curfloor.floortype = EditorGUI.Popup(new Rect(0, 0, 100, 32), curfloor.floortype, FloorDataHelper.type);

        EditorGUILayout.EndHorizontal();
    }

    int _curselecttype = 0;
    private void DoBrickWindow(int wid)
    {
        EditorGUILayout.BeginHorizontal();
        //EditorGUI.DrawRect(new Rect(startpos.x, startpos.y, bricksize.x, bricksize.y), new Color(1, 1, 0));
        //GUI.Button()
        var curfloor = _Floors[_selectFloorID];
        var curbrick = curfloor.bricks[_selectBrickID];

        if(_brickTable != null)
        {
            curbrick.bricktype = EditorGUI.Popup(new Rect(0, 0, 100, 32), curbrick.bricktype, _brickTable.BrickNames);
        }
        //curbrick.bricktype = EditorGUI.Popup(new Rect(0, 0, 100, 32), curbrick.bricktype, BrickDataHelper.type);

        EditorGUILayout.EndHorizontal();
    }


    private void SaveData(string filename)
    {
        if(filename == "")
        {
            Debug.Log("Null file name");
            return;
        }
        if (_Floors == null || _Floors.Count == 0)
        {
            Debug.Log("Null Floors data");
            return;
        }

        var asset = ScriptableObject.CreateInstance<SpecialFloorsDataScriptable>();
        asset.floors = new List<SpecialFloorData>();
        asset.maxlevel = _maxLevel;
        asset.minlevel = _minLevel;

        foreach (var edata in _Floors)
        {
            SpecialFloorData d = new SpecialFloorData();
            d.type = edata.floortype;

            //d.brick1_data = edata.bricks[0].bricktype == 0 ? "" : BrickDataHelper.type[edata.bricks[0].bricktype];
            //d.brick2_data = edata.bricks[1].bricktype == 0 ? "" : BrickDataHelper.type[edata.bricks[1].bricktype];
            //d.brick3_data = edata.bricks[2].bricktype == 0 ? "" : BrickDataHelper.type[edata.bricks[2].bricktype];

            d.brick1_data = edata.bricks[0].bricktype == 0 ? "" : _brickTable.BrickNames[edata.bricks[0].bricktype];
            d.brick2_data = edata.bricks[1].bricktype == 0 ? "" : _brickTable.BrickNames[edata.bricks[1].bricktype];
            d.brick3_data = edata.bricks[2].bricktype == 0 ? "" : _brickTable.BrickNames[edata.bricks[2].bricktype];

            asset.floors.Add(d);
        }

        asset.scene = _curBrickTableName;

        //AssetDatabase.CreateAsset(asset, string.Format("Assets/Resources/FloorsDatas/{0}_{1}_{2}.asset", "SF", "Grass",filename));
        AssetDatabase.CreateAsset(asset, string.Format("Assets/Resources/FloorsDatas/{0}_{1}_{2}.asset", "SF", _curBrickTableName, filename));
    }

    private void LoadData(string filename)
    {
        if (filename == "")
        {
            Debug.Log("Null file name");
            return;
        }
        Debug.Log(filename);


        var path = string.Format("Assets/Resources/FloorsDatas/{0}.asset", filename);
        var asset = AssetDatabase.LoadAssetAtPath<SpecialFloorsDataScriptable>(path);
        Debug.Log(path);
        _maxLevel = asset.maxlevel;
        _minLevel = asset.minlevel;

        _curBrickTableName = asset.scene;
        if(_curBrickTableName == "")
        {
            _curBrickTableName = "defaultscene";
        }
        _brickTable = Resources.Load<BrickTable>("BrickTable/" + _curBrickTableName);

        if(_brickTable != null)
        {
            _Floors = new List<EditorFloor>();
            for (int i = 0; i < asset.floors.Count; ++i)
            {
                var newdata = new EditorFloor();
                newdata.floortype = asset.floors[i].type;
                newdata.startpos = 0;

                //newdata.bricks[0].bricktype = BrickDataHelper.GetIndex(asset.floors[i].brick1_data);

                //newdata.bricks[1].bricktype = BrickDataHelper.GetIndex(asset.floors[i].brick2_data);

                //newdata.bricks[2].bricktype = BrickDataHelper.GetIndex(asset.floors[i].brick3_data);

                newdata.bricks[0].bricktype = _brickTable.GetIndex(asset.floors[i].brick1_data);
                newdata.bricks[1].bricktype = _brickTable.GetIndex(asset.floors[i].brick2_data);
                newdata.bricks[2].bricktype = _brickTable.GetIndex(asset.floors[i].brick3_data);

                _Floors.Add(newdata);
            }
        }

    }
}
