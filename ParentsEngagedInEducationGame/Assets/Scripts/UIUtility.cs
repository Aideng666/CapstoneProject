using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class UIUtility : MonoBehaviour
{
    [Header("Canvas Groups")]
    [SerializeField] CanvasGroup startCanvasGroup;
    [SerializeField] CanvasGroup titleCanvasGroup;
    [SerializeField] CanvasGroup titleCanvasMainGroup;
   // [SerializeField] CanvasGroup hubCanvasGroup;
   
    Tween fadeTween;

    [Header("Edit Name Panel")] 
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text nameText;
    string username = "";
    [SerializeField] GameObject editNamePanel;
    bool hasSetName = false;
    [SerializeField] GameObject editNameButton;
    [SerializeField] Button enterButton;

    void Start()
    {
        StartCoroutine(StartFade());

        nameText.text = PlayerPrefs.GetString("username");

        if (PlayerPrefs.GetInt("hasSetName") == 1)
        {
            editNameButton.SetActive(true);
        }

        enterButton.interactable = false;
    }

    public void ShowNamePanel()
    {
        if (!hasSetName)
        {
            PlayerPrefs.GetInt("hasSetName", 0);
        }
        else
        {
            PlayerPrefs.GetInt("hasSetName", 1);
        }

        if (PlayerPrefs.GetInt("hasSetName") == 0)
        {
            // hasn't set their name, open name panel
            editNamePanel.SetActive(true);
        }
        if (PlayerPrefs.GetInt("hasSetName") == 1)
        {
            editNamePanel.SetActive(false);
            // TODO:
            // FadeOut
            // Loading Screen
            // Switch to Classroom Scene 
            // Camera zoom on door's opening?
        }
    }

    public void UpdateName()
    {
        username = inputField.text;
        nameText.text = username;
        editNameButton.SetActive(true);
        PlayerPrefs.SetString("username", username);
        PlayerPrefs.SetInt("hasSetName", 1);
        hasSetName = true;
        PlayerPrefs.Save();
        inputField.text = "";
    }

    public void CloseButton()
    {
        inputField.text = "";
    }

    void Update()
    {
        if (inputField.text == "")
        {
            enterButton.interactable = false;
        }
        else
        {
            enterButton.interactable = true;
        }
    }

    public void  DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteKey("username");
        PlayerPrefs.DeleteKey("hasSetName");
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
        yield return new WaitForSeconds(0.2f);
        FadeOut(titleCanvasGroup, 1f);
    }

    public void TapPlayButton()
    {
        StartCoroutine(PlayButtonFade());
    }
}
