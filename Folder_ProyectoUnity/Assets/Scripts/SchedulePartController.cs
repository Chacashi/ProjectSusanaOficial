using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using TMPro;

public class SchedulePartController : MonoBehaviour
{
    Image _compImage;
    TMP_Text textImage;

    private void Awake()
    {
        _compImage = GetComponent<Image>();
        textImage =  transform.GetChild(0).GetComponent<TMP_Text>();
    }

    public void SetNewSprite( Sprite newSprite)
    {
        _compImage.sprite = newSprite;
    }

    public void SetNewText( string text)
    {
        textImage.text = text;
    }
}
