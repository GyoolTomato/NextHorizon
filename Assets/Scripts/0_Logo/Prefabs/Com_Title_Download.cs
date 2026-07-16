using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Com_Title_Download : Com_Base
{
    //
    [SerializeField] TextMeshProUGUI _progressValue = null;
    [SerializeField] Slider _progressSlider = null;

    /// <summary>
    /// 
    /// </summary>
    public void Init()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public override void Tick()
    {
        _progressValue.text = string.Format("({0}/{1}) {2}%", Manager_Addressable.Instance.pDownloadedBytes, Manager_Addressable.Instance.pTotalBytes, Manager_Addressable.Instance.pDownloadPercent * 100f);
        _progressSlider.value = Manager_Addressable.Instance.pDownloadPercent;
    }
}
