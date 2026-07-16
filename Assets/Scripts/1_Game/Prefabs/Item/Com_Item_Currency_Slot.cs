using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Com_Item_Currency_Slot : Com_Base
{
    //
    [SerializeField] Image _icon = null;
    [SerializeField] TextMeshProUGUI _amount = null;

    //
    public _101_Items.Values pTableInfo { private set; get; }

    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="tableInfo"></param>
    /// <param name="value"></param>
    public void Init(_101_Items.Values tableInfo, long value)
    {
        //
        pTableInfo = tableInfo;

        //
        _icon.sprite = Manager_Resources.Instance.GetSprite("");

        //
        if (_amount != null)
            _amount.text = value.ToString();
    }
}
