using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Manager_UI : Singleton<Manager_UI>
{
    //
    ELanguage _language;

    //
    Dictionary<EPanelType, Panel_Base> _dicPanels = new Dictionary<EPanelType, Panel_Base>();
    List<Com_Base> _coms = new List<Com_Base>();

    Transform _board_0;
    Transform _board_1;
    Transform _board_2;

    //
    GameObject _panelTitleObj;
    GameObject _panelMessageBoxObj;

    //
    AssetReference SpawnablePrefab;


    /// <summary>
    /// 
    /// </summary>
    public void Init()
    {
        _language = ELanguage.Korean;

        _board_0 = GameObject.Find("Board_0").transform;
        _board_1 = GameObject.Find("Board_1").transform;
        _board_2 = GameObject.Find("Board_2").transform;

        Clear();

        _panelTitleObj = Resources.Load<GameObject>("Prefabs/Panel_Title");
        _panelMessageBoxObj = Resources.Load<GameObject>("Prefabs/Panel_MessageBox");
    }

    /// <summary>
    /// 
    /// </summary>
    public void Clear()
    {
        _dicPanels.Clear();
    }

    /// <summary>
    /// 
    /// </summary>
    public bool CreatePanel(EPanelType panelType)
    {
        GameObject loadObject = null;

        if (panelType == EPanelType.Title)
        {
            loadObject = _panelTitleObj;
        }
        else if (panelType == EPanelType.MessageBox)
        {
            loadObject = _panelMessageBoxObj;
        }
        else
        {
            loadObject = Manager_Addressable.Instance.GetPanel(panelType);
        }

        var createObject = GameObject.Instantiate(loadObject, _board_0);
        if (createObject == null)
        {
            Debug.LogError("CreatePanel Create Fail! Panel Type : " + panelType);
            return false;
        }
        createObject.transform.localPosition = Vector3.zero;

        var panelBase = createObject.GetComponent<Panel_Base>();
        if (panelBase == null)
        {
            Debug.LogError("CreatePanel GetComponent Fail! Panel Type : " + panelType);
            return false;
        }

        _dicPanels.Add(panelType, panelBase);

        return true;
    }

    ///<summary>
    ///
    ///</summary>
    public Panel_Base GetPanel(EPanelType panelType)
    {        
        //
        if (_dicPanels.ContainsKey(panelType) == false)
        {
            CreatePanel(panelType);
        }

        //
        return _dicPanels[panelType];
    }

    ///<summary>
    ///
    ///</summary>
    public Panel_Base ShowPanel(EPanelType panelType)
    {
        //
        var panel = GetPanel(panelType);
        if (panel != null)
        {            
            panel.pIsShow = true;
            panel.OnShowPanel();
        }
        else
        {
            Debug.LogError("ShowPanel GetPanel Fail! Panel Type : " + panelType);
        }

        //
        return panel;
    }

    /// <summary>
    /// 
    /// </summary>
    public void HidePanel(EPanelType panelType)
    {
        //
        var panel = GetPanel(panelType);
        if (panel == null)
            return;
        //
        if (panel.pIsShow == true)
        {            
            panel.gameObject.SetActive(false);
            panel.OnHidePanel();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void UpdateTicks()
    {
        foreach (var panel in _dicPanels.Values)
        {
            if (panel.pIsShow == true)
            {
                panel.Tick();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void UpdateTicks_Sec()
    {
        foreach (var panel in _dicPanels.Values)
        {
            if (panel.pIsShow == true)
            {
                panel.Tick_Sec();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetTextCommon(int key)
    {
        var temp = _900_TextCommon.GetItem(key);
        if (temp == null)
            return string.Empty;

        switch (_language)
        {
            case ELanguage.Korean  : return temp.korean;
            case ELanguage.Japanese: return temp.japanese;
            default                : return temp.english;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetTextCharacter(int key)
    {
        var temp = _901_TextCharacter.GetItem(key);
        if (temp == null)
            return string.Empty;

        switch (_language)
        {
            case ELanguage.Korean: return temp.korean;
            case ELanguage.Japanese: return temp.japanese;
            default: return temp.english;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetTextSkill(int key)
    {
        var temp = _905_TextSkills.GetItem(key);
        if (temp == null)
            return string.Empty;

        switch (_language)
        {
            case ELanguage.Korean: return temp.korean;
            case ELanguage.Japanese: return temp.japanese;
            default: return temp.english;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetTextNotice(int key)
    {
        var temp = _902_TextNotice.GetItem(key);
        if (temp == null)
            return string.Empty;

        switch (_language)
        {
            case ELanguage.Korean: return temp.korean;
            case ELanguage.Japanese: return temp.japanese;
            default: return temp.english;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetTextMissions(int key)
    {
        var temp = _903_TextMissions.GetItem(key);
        if (temp == null)
            return string.Empty;

        switch (_language)
        {
            case ELanguage.Korean: return temp.korean;
            case ELanguage.Japanese: return temp.japanese;
            default: return temp.english;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetTextItems(int key)
    {
        var temp = _904_TextItems.GetItem(key);
        if (temp == null)
            return string.Empty;

        switch (_language)
        {
            case ELanguage.Korean: return temp.korean;
            case ELanguage.Japanese: return temp.japanese;
            default: return temp.english;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="stat"></param>
    /// <returns></returns>
    public string GetTextCharacterStats(ECharacterStats stat)
    {
        //
        var result = string.Empty;

        //
        switch (stat)
        {
            case ECharacterStats.HP           : result = GetTextCommon(9000020); break;
            case ECharacterStats.HP_Level     : result = GetTextCommon(9000021); break;
            case ECharacterStats.ATK          : result = GetTextCommon(9000022); break;
            case ECharacterStats.ATK_Level    : result = GetTextCommon(9000023); break;
            case ECharacterStats.DEF          : result = GetTextCommon(9000024); break;
            case ECharacterStats.DEF_Level    : result = GetTextCommon(9000025); break;
            case ECharacterStats.Avoid        : result = GetTextCommon(9000026); break;
            case ECharacterStats.Avoid_Level  : result = GetTextCommon(9000027); break;
            case ECharacterStats.Focus        : result = GetTextCommon(9000028); break;
            case ECharacterStats.Focus_level  : result = GetTextCommon(9000029); break;
            case ECharacterStats.AtkSpd       : result = GetTextCommon(9000030); break;
            case ECharacterStats.AtkSpd_level : result = GetTextCommon(9000031); break;
            case ECharacterStats.Speed        : result = GetTextCommon(9000032); break;
            case ECharacterStats.Crirate      : result = GetTextCommon(9000033); break;
            case ECharacterStats.Crirate_level: result = GetTextCommon(9000034); break;
            case ECharacterStats.Cridmg       : result = GetTextCommon(9000035); break;
            case ECharacterStats.Cridmg_level : result = GetTextCommon(9000036); break;
            case ECharacterStats.ActiveSkill  : result = GetTextCommon(9000037); break;
            case ECharacterStats.PassiveSkill : result = GetTextCommon(9000038); break;
        }

        //
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public string GetNotice(int key)
    {
        var temp = _902_TextNotice.GetItem(key);
        if (temp == null)
            return string.Empty;

        switch (_language)
        {
            case ELanguage.Korean: return temp.korean;
            case ELanguage.Japanese: return temp.japanese;
            default: return temp.english;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="colorCode"></param>
    /// <returns></returns>
    public Color GetColorHexaCode(string colorCode)
    {
        //
        if (ColorUtility.TryParseHtmlString(colorCode, out Color color))
        {
            return color;
        }

        //
        Debug.LogError("GetColorHexaCode() - Invalid color code: " + colorCode);

        return Color.white;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="messageKey"></param>
    /// <param name="type"></param>
    /// <param name="onConfirm"></param>
    /// <param name="onCancel"></param>
    public void ShowMessageBox(string message, Panel_MessageBox.EType type, Action onConfirm = null, Action onCancel = null)
    {
        var panel = ShowPanel(EPanelType.MessageBox) as Panel_MessageBox;
        panel.Init(message, type, onConfirm, onCancel);
    }
}
