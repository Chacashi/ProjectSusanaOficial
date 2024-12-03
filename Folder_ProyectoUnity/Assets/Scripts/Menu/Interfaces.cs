using DG.Tweening;
using UnityEngine;

public interface IFade
{
    void Fade(float endValue, float duration, TweenCallback onEnd);
    void Fade(float endValue, float duration);
    void FadeIn();
    void FadeOut();
}