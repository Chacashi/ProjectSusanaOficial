using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class MenuManagerController : MonoBehaviour
{
    [SerializeField] TMP_Text textTitle;
    [SerializeField] TMP_Text textMessageDown;
    [SerializeField] float durationFadeText;
    [SerializeField] float durationFadePanel;
    [SerializeField] CanvasGroup panelMenu;
    [SerializeField] Button buttonToMenu;
    private Tween fadeTween;
    float valueA;



    private void Start()
    {
        
        Fade(1,durationFadeText,textTitle);
        buttonToMenu.onClick.AddListener(ButtonToMenuPressed);
    }
    private void Update()
    {

        textMessageDown.color = new Color(textMessageDown.color.r, textMessageDown.color.g, textMessageDown.color.b, valueA);
        valueA = Mathf.PingPong(Time.time, 1);
    }

    private void OnEnable()
    {
        InputReader.OnPressedSpace += FadeInPanelMenu;
    }

    private void OnDisable()
    {
  
        InputReader.OnPressedSpace -= FadeInPanelMenu;
    }
  

    void FadeInPanelMenu()
    {
        FadeIn(panelMenu);
        Fade(0, durationFadeText, textTitle);

    }

    void ButtonToMenuPressed()
    {
        Fade(1, durationFadeText,textTitle);
        FadeOut(panelMenu);
    }


    public void FadeIn( CanvasGroup canvasGroup)
    {

        Fade(1f, durationFadePanel,canvasGroup, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

        });


    }

    public void FadeOut(CanvasGroup canvasGroup)
    {

        Fade(0f, durationFadePanel,canvasGroup, () =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;


        });


    }
    public void Fade(float endValue, float duration, CanvasGroup element,  TweenCallback onEnd)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = element.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }


    public void Fade(float endValue, float duration, TMP_Text element )
    {
        
        element.DOFade(endValue, duration);
    }
}
