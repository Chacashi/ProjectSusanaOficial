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
        InputReader.OnPressedSpace += FadeOutTitle;
        InputReader.OnPressedSpace += FadeInPanelMenu;
    }

    private void OnDisable()
    {
        InputReader.OnPressedSpace -= FadeOutTitle;
        InputReader.OnPressedSpace -= FadeInPanelMenu;
    }
    void FadeOutTitle()
    {
        Fade(0,durationFadeText,textTitle);
    }

    void FadeInPanelMenu()
    {
        FadeIn(panelMenu);
    }

    void ButtonToMenuPressed()
    {
        Fade(1, durationFadeText,textTitle);
        FadeOut(panelMenu);
    }


    public void FadeIn( CanvasGroup canvasGroup)
    {

        Fade<CanvasGroup>(1f, durationFadePanel,canvasGroup, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

        });


    }

    public void FadeOut(CanvasGroup canvasGroup)
    {

        Fade<CanvasGroup>(0f, durationFadePanel,canvasGroup, () =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;


        });


    }
    public void Fade<T>(float endValue, float duration, T element,  TweenCallback onEnd)
    {
        dynamic aux = element;
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = aux.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }


    public void Fade<T>(float endValue, float duration,T element )
    {
        dynamic aux = element;
        aux.DOFade(endValue, duration);
    }
}
