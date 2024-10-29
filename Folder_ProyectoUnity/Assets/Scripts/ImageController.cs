using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ImageController : MonoBehaviour
{
    [SerializeField] Sprite[] arrayImage;
    [SerializeField] Button buttonNext;
    [SerializeField] Button buttonBack;
    [SerializeField] Image curretImage;
    [SerializeField]  int curretIndex = 0;

    private void Awake()
    {
        curretImage.GetComponent<Image>();
    }
    private void Start()
    {
       
        curretImage.sprite = arrayImage[curretIndex];

       
            buttonNext.onClick.AddListener(NextImage);
        
       
        
            buttonBack.onClick.AddListener(BackImage);
       
    }

 



    void NextImage()
    {
        if (curretIndex < arrayImage.Length)
        {
            curretImage.sprite = arrayImage[curretIndex++];
        }
        
    }

    void BackImage()
    {

        if (curretIndex > 0)
        {
            curretImage.sprite = arrayImage[curretIndex--];
        }
        
    }
}
