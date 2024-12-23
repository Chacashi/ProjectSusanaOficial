using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ImageController : MonoBehaviour
{
    [SerializeField] Sprite[] arrayImage;
    [SerializeField] Button buttonNext;
    [SerializeField] Button SkipButton;
    [SerializeField] Image curretImage;
    [SerializeField]  int curretIndex = 0;
    static event Action OnLastImage;
    public static event Action<Sprite> OnImageLoaded;
    private void Awake()
    {
        curretImage.GetComponent<Image>();
    }
    private void Start()
    {
       
        curretImage.sprite = arrayImage[curretIndex];
        OnImageLoaded?.Invoke(arrayImage[curretIndex]); 
       
        buttonNext.onClick.AddListener(NextImage);
    }

    void NextImage()
    {
        if (curretIndex < arrayImage.Length-1)
        {
            curretIndex++;
            curretImage.sprite = arrayImage[curretIndex];
            OnImageLoaded?.Invoke(arrayImage[curretIndex]);
        }

        if(curretIndex == arrayImage.Length-1)
        {
            OnLastImage?.Invoke();
        }

    }

    private void OnEnable()
    {
        OnLastImage += HideButton;
    }

    private void OnDisable()
    {
        OnLastImage -= HideButton;
    }
    void HideButton()
    {
        SkipButton.gameObject.SetActive(false);
        buttonNext.gameObject.GetComponent<ButtonScene>().enabled = true;
    }


 
}
