using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIUtility : MonoBehaviour
{
    [SerializeField] CanvasGroup startCanvasGroup;
    //[SerializeField] CanvasGroup canvasGroup;
    Tween fadeTween;

    void Start()
    {
        StartCoroutine(StartFade());
    }

    // Update is called once per frame
    void Update()
    {
        TapScreen();
    }

    private void Fade(CanvasGroup canvasGroup, float endValue, float duration, TweenCallback onEnd)
    {
        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = canvasGroup.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;
    }

    public void FadeIn(CanvasGroup canvasGroup, float duration)
    {
        Fade(canvasGroup, 1f, duration, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        });
    }

    public void FadeOut(CanvasGroup canvasGroup, float duration)
    {
        Fade(canvasGroup, 0f, duration, () =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        });
    }

    private IEnumerator StartFade()
    {
        yield return new WaitForSeconds(1f);
        FadeOut(startCanvasGroup, 1f);
        //yield return new WaitForSeconds(3f);
        //FadeIn(startCanvasGroup, 1f);
    }

    public void TapScreen()
    {
        if (Input.GetMouseButtonDown(0))
        {

        }

    }
}
