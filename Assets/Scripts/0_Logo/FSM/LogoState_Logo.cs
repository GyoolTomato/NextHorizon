using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoState_Logo : LogoState
{
    

    //
    public LogoState_Logo(ELogoState state) : base(state)
    {
        
    }

    //
    override public void Enter()
    {
        var panel = Manager_UI.Instance.ShowPanel(EPanelType.Title) as Panel_Title;
        panel.Init();
    }

    //
    override public void Exit()
    {

    }

    //
    override public void Update()
    {
        
    }
}
