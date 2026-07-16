using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Com_Slots<T> : Com_Base where T : Com_Base
{
    //
    [SerializeField] ScrollView    _scrollView   = null;
    [SerializeField] RectTransform _container    = null;
    [SerializeField] T             _createObject = null;

    //
    Stack<T> _slotPool = new Stack<T>();

    //
    public List<T> pSlots {private set; get;} = new List<T>();

    /// <summary>
    /// 
    /// </summary>
    public T ActivateSlot()
    {
        //
        T slot = default;
        if (slot != null)
        {
            Debug.LogError("T is Not found 'Com_Base'");
            return slot;
        }
        
        //
        return PopSlot();
    }

    /// <summary>
    /// 
    /// </summary>
    T PopSlot()
    {
        //
        if (_slotPool.Count == 0)
        {
            //
            T tempSlot = default;

            Instantiate(tempSlot, _container);
            tempSlot.gameObject.SetActive(true);

            return tempSlot;
        }

        //
        return _slotPool.Pop();
    }

   /// <summary>
   /// 
   /// </summary>
    void PushSlot(T slot)
    {
        //
        _slotPool.Push(slot);
        
        slot.gameObject.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    public void DeactiveSlots()
    {
        //
        foreach (T slot in _slotPool)
        {
            PushSlot(slot);
        }
    }
}
