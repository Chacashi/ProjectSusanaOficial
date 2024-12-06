
using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;
using System;

public class InputReaderGameplay: MonoBehaviour
{
    
   
    Tween fadeTween;
    [SerializeField] CanvasGroup canvasGroup;
    [SerializeField] float durationFadePanel;
    Vector2 movement;
    public static event Action<Vector2> GetValueMovement;
    bool isScape=false;





    public void Movement(InputAction.CallbackContext context)
    {
        if (isScape == false)
        {
            movement = context.ReadValue<Vector2>();
            GetValueMovement?.Invoke(movement);
        }
       
    }

    public void ButtonEsc(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

            if (canvasGroup.alpha == 0)
            {
                isScape = true;
                FadeIn(canvasGroup);

            }
            else
            {
                isScape = false;
                FadeOut(canvasGroup);
            }

        }
    }

    public void FadeIn(CanvasGroup canvasGroup)
    {
    
        Fade(1f, durationFadePanel, canvasGroup, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

        });


    }

    public void FadeOut(CanvasGroup canvasGroup)
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    
        Fade(0f, durationFadePanel, canvasGroup, () =>
        {
            
        });


    }
    public void Fade(float endValue, float duration, CanvasGroup element, TweenCallback onEnd)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = element.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }

}
