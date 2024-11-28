using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GalleryController : MonoBehaviour
{

    DoubleCircleList<Sprite> ListImages = new DoubleCircleList<Sprite>();
    [SerializeField] Image currentImage;
    [SerializeField] Button buttonNext;
    [SerializeField] Button buttonBack;
    int indexImage = 0;



    private void Awake()
    {
        currentImage = GetComponent<Image>();
    }
    private void Start()
    {
        currentImage.sprite = ListImages.GetValueAtStart();
        buttonNext.onClick.AddListener(NextImage);
        buttonBack.onClick.AddListener(BackImage);
    }


    void NextImage()
    {
        if(indexImage <ListImages.GetCount())
        {
            indexImage++;
            currentImage.sprite = ListImages.GetValueAtPosition(indexImage);
        }
        
    }

    void BackImage()
    {
        if (indexImage > 0)
        {
            indexImage--;
            currentImage.sprite = ListImages.GetValueAtPosition(indexImage);
        }
        
    }
    private void OnEnable()
    {
        ImageController.OnImageLoaded += AddImage;
        
    }

    private void OnDisable()
    {
        ImageController.OnImageLoaded -= AddImage;
    }
    public void AddImage(Sprite sprite)
    {
        ListImages.AddAtEnd(sprite);
    }







    
}
