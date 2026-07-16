using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Panel_Title : Panel_Base
{
    //   
    [SerializeField] Com_Title_Logo _comLogo = null;
    [SerializeField] Com_Title_Download _comDownload = null;
    [SerializeField] Com_Title_Login _comLogin = null;

    //
    public Com_Title_Login pComLogin => _comLogin;


    /// <summary>
    /// 
    /// </summary>
    protected override void Awake()
    {
        base.Awake();

        pPanelType = EPanelType.Title;
    }

    public void Init()
    {
        //
        _comLogo.gameObject.SetActive(LogoScene.pCurState.pState == ELogoState.Logo);
        _comDownload.gameObject.SetActive(LogoScene.pCurState.pState == ELogoState.Download);
        _comLogin.gameObject.SetActive(LogoScene.pCurState.pState == ELogoState.LogIn);

        switch (LogoScene.pCurState.pState)
        {
            case ELogoState.Logo    : _comLogo    .Init(); break;
            case ELogoState.Download: _comDownload.Init(); break;
            case ELogoState.LogIn   : _comLogin   .Init(); break;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public override void Tick()
    {
        switch (LogoScene.pCurState.pState)
        {
            case ELogoState.Logo    : _comLogo    .Tick(); break;
            case ELogoState.Download: _comDownload.Tick(); break;
            case ELogoState.LogIn   : _comLogin   .Tick(); break;
        }
    }
}
