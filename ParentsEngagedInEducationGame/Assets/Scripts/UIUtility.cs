using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIUtility : MonoBehaviour
{
    [Header("Canvas Groups")]
    [SerializeField] CanvasGroup startCanvasGroup;
    [SerializeField] CanvasGroup logoImg;
    [SerializeField] CanvasGroup titleCanvasGroup;
    [SerializeField] CanvasGroup titleCanvasMainGroup;

    Tween fadeTween;
    public float startFadeTime = 1f;

    void Start()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(1))
        {
            StartCoroutine(StartFade());
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(0))
        {
            StartCoroutine(LogoFade());
        }
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
        yield return new WaitForSeconds(startFadeTime);
        FadeOut(startCanvasGroup, 1f);
    }

    private IEnumerator LogoFade()
    {
        yield return new WaitForSeconds(1f);
        FadeIn(logoImg, 1f);
        yield return new WaitForSeconds(3f);
        FadeOut(logoImg, 1f);
        StartCoroutine(StartFade());
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
