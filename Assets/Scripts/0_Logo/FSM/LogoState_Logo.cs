using Data;
using Newtonsoft.Json;
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
        //
        var textSystem = Resources.Load<TextAsset>("Tables/_999_TextSystem");
        if (textSystem == null)
        {
            Debug.LogError("Not found '_999_TextSystem'");
        }
        else
        {
            var temp_999_TextSystem = JsonConvert.DeserializeObject<List<_999_TextSystem.Values>>(textSystem.text);
            foreach (var item in temp_999_TextSystem)
            {
                TableDataLoader.Instance._list_999_TextSystem.Add(item);
                TableDataLoader.Instance._dic_999_TextSystem.Add(item.key, item);
            }
        }

        //
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
