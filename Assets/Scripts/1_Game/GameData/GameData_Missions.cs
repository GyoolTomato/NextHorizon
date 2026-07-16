using System;
using System.Collections.Generic;
using System.Text;


/// <summary>
/// 
/// </summary>
public class DataMission
{
    //
    public _104_Missions.Values _tableInfo = null;
    public bool                 _isTake    = false;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="tableInfo"></param>
    /// <param name="isTake"></param>
    public DataMission(_104_Missions.Values tableInfo, bool isTake)
    {
        _tableInfo = tableInfo;
        _isTake    = isTake;
    }
}

/// <summary>
/// 
/// </summary>
public class GameData_Missions
{
    //
    public List<DataMission>            pMissions    { get; set; } = new List<DataMission>();
    public Dictionary<int, DataMission> pDicMissions { get; set; } = new Dictionary<int, DataMission>();


    /// <summary>
    /// 
    /// </summary>
    public void Init()
    {
        //
        pMissions.Clear();
        pDicMissions.Clear();

        //
        foreach (var item in _104_Missions.GetList())
        {
            var temp = new DataMission(item, false);
            pMissions.Add(temp);
            pDicMissions.Add(item.key, temp);
        }
    }
}