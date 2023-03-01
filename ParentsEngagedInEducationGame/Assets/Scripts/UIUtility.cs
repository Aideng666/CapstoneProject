using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIUtility : MonoBehaviour
{
    [Header("Canvas Groups")]
    [SerializeField] CanvasGroup startCanvasGroup;
    [SerializeField] CanvasGroup titleCanvasGroup;
    [SerializeField] CanvasGroup titleCanvasMainGroup;

    Tween fadeTween;

    void Start()
    {
        StartCoroutine(StartFade());
    }

    void Update()
    {
       
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
    }

    private IEnumerator PlayButtonFade()
    {
        yield return new WaitForSeconds(0.2f);
        FadeIn(titleCanvasGroup, 1f);
        yield return new WaitForSeconds(2f);
        titleCanvasMainGroup.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync("Hub");
    }

    public void TapPlayButton()
    {     
        StartCoroutine(PlayButtonFade());                
    } 
}
