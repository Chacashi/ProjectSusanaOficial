using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class ButtonDotween : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private  Vector3 ScaleVector;
    [SerializeField] private  float timeScale;
    private Vector3 InitialScale;


   void Start()
    {
        InitialScale = transform.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Scale(ScaleVector);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Scale(InitialScale);
    }


    void Scale(Vector3 toScale)
    {
        transform.DOScale(toScale, timeScale);
    }
}
