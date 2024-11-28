using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class PointerManagerController : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public static event Action OnEnterPointer; 
    public static event Action OnExitPointer; 

     public void OnPointerEnter(PointerEventData eventData)
    {
        OnEnterPointer.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnExitPointer.Invoke();
    }
    
}
