using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DotweenManagerController : MonoBehaviour
{
    [SerializeField] private Button[] arrayButtons;


    private void OnEnable()
    {
        PointerManagerController.OnEnterPointer += ScaleButton;
        PointerManagerController.OnExitPointer += DescaleButton;

    }
    private void OnDisable()
    {
        PointerManagerController.OnEnterPointer -= ScaleButton;
        PointerManagerController.OnExitPointer -= DescaleButton;
    }


    void ScaleButton()
    {
        for (int i = 0; i < arrayButtons.Length; i++)
        {
            arrayButtons[i].transform.DOScale(new Vector3(1.1f, 1.1f, 0), 1f);
        }
    }

    void DescaleButton()
    {
        for(int i = 0; i < arrayButtons.Length; i++)
        {
            arrayButtons[i].transform.DOScale(new Vector3(1f, 1f, 0), 1f);
        }
    }
}
