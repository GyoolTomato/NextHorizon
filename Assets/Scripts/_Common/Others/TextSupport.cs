using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextSupport : MonoBehaviour
{
    //
    [SerializeField] int _key = 0;

    //
    int _appliedKey = 0;
    TextMeshProUGUI _text = null;


    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        ChangeText();
    }

    /// <summary>
    /// 
    /// </summary>
    void OnEnable()
   {
        ChangeText();
    }

    void ChangeText()
    {
        //
        if (_text == null)
            return;

        //
        if (_key == 0 || _appliedKey != _key)
        {
            _appliedKey = _key;
            _text.text = Manager_UI.Instance.GetTextCommon(_key);
        }
    }
}
