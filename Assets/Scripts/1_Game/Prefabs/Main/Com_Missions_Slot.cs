using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Com_Missions_Slot : Com_Slots<Com_Item_Slot>
{
    //
    [SerializeField] TextMeshProUGUI _title = null;

    //
    DataMission _data = null;


    /// <summary>
    /// 
    /// </summary>
    public void Init(DataMission data)
    {
        //
        _data = data;

        //
        _title.text = Manager_UI.Instance.GetTextMissions(_data._tableInfo.title);

        DeactiveSlots();
    }

    /// <summary>
    /// 
    /// </summary>
    public void OnBtnConfirm()
    {

    }
}
