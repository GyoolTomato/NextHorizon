using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Com_Item_Armor_Slot : Com_Base
{
    //
    [SerializeField] Image _icon = null;
    [SerializeField] TextMeshProUGUI _part = null;
    [SerializeField] TextMeshProUGUI _tier = null;
    [SerializeField] TextMeshProUGUI _amount = null;

    //
    public _105_Armors.Values pTableInfo { private set; get; }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="tableInfo"></param>
    /// <param name="value"></param>
    public void Init(_105_Armors.Values tableInfo, long value)
    {
        //
        pTableInfo = tableInfo;

        //
        _icon.sprite = Manager_Resources.Instance.GetSprite(tableInfo.icon);

        //
        if (_part != null)
            _part.text = Manager_UI.Instance.GetTextCommon(tableInfo.tier);
            
        if (_tier != null)
            _tier.text = string.Format(Manager_UI.Instance.GetTextCommon(9000017), tableInfo.tier);

        if (_amount != null)
            _amount.text = value.ToString();
    }
}
