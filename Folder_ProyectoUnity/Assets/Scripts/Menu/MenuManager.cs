
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using DG.Tweening;
using TMPro;




public class MenuManager : MonoBehaviour
{

    [SerializeField] PlayerInput input;
    [SerializeField] TMP_Text textTitle;
    [SerializeField] TMP_Text textMessageDown;
    float valueA;
    [SerializeField] float durationFadeText;

    [SerializeField] CanvasGroup PanelIntro;
    [SerializeField] CanvasGroup PanelMenu;
    private Tween fadeTween;
    [SerializeField] float durationFade;
    [SerializeField] Button backButton;


    private void Start()
    {
        backButton.onClick.AddListener(ReverseFades);
        textTitle.DOFade(1, durationFadeText);
       
    }
    private void Update()
    {
       
            textMessageDown.color = new Color(textMessageDown.color.r, textMessageDown.color.g, textMessageDown.color.b, valueA);
            valueA = Mathf.PingPong(Time.time, 1);

    }

    public void TurnOnOff(InputAction.CallbackContext context)
    {
       
        if (context.performed)
        {
           textTitle.DOFade(0, durationFadeText);
           FadeOut(PanelIntro);
           FadeIn(PanelMenu);
            
           
           input.enabled = false;
        }
    }

    void ReverseFades()
    {
        FadeOut(PanelMenu);
        FadeIn(PanelIntro);
      
        
        textTitle.DOFade(1, durationFadeText);
        input.enabled = false;
    }

    void FadeIn(CanvasGroup canvasGroup)
    {
       
            Fade(1f, durationFade, canvasGroup, () =>
            {
                canvasGroup.interactable = true;
                canvasGroup.blocksRaycasts = true;
                input.enabled = true;
            

            });
        

    }

    void FadeOut(CanvasGroup canvasGroup)
    {
        
            Fade(0f, durationFade,canvasGroup, () =>
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
               

            });
        

    }
    private void Fade(float endValue, float duration, CanvasGroup canvasGroup, TweenCallback onEnd )
    {
        /*
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }
        */
        

        fadeTween = canvasGroup.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }

    
}

