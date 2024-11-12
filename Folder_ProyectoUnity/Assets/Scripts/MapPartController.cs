using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class MapPartController : MonoBehaviour
{
    Image _compImage;

    private void Awake()
    {
        _compImage = GetComponent<Image>();
    }

    public void SetNewSprite( Sprite newSprite)
    {
        _compImage.sprite = newSprite;
    }
}
