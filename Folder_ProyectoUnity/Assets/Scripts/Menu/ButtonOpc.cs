using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonOpc : ButtonController
{
    [SerializeField] private CanvasGroup canvasGroupObjective;
    [SerializeField] private CanvasGroup[] arrayCanvasGroup;
    [SerializeField] private float durationFade;
    private Tween fadeTween;



    protected override void Interactue()
    {

        if (canvasGroupObjective.alpha == 0)
        {
            for (int i = 0; i < arrayCanvasGroup.Length; i++)
            {
                arrayCanvasGroup[i].alpha = 0;
                arrayCanvasGroup[i].interactable = false;
                arrayCanvasGroup[i].blocksRaycasts = false;
            }
            FadeIn();
            
           
        }
 
    }

    public void Fade(float endValue, float duration, TweenCallback onEnd)
    {

        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }



        fadeTween = canvasGroupObjective.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }
    public void Fade(float endValue, float duration)
    {
        canvasGroupObjective.DOFade(endValue, duration);
    }
    public void FadeIn()
    {

        Fade(1f, durationFade, () =>
        {
            canvasGroupObjective.interactable = true;
            canvasGroupObjective.blocksRaycasts = true;

        });
    }

    public void FadeOut()
    {

        canvasGroupObjective.interactable = false;
        canvasGroupObjective.blocksRaycasts = false;


        Fade(0f, durationFade);

    }
}
