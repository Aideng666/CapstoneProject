using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIManager : MonoBehaviour
{
    public float fadeTime = 1f;
    public CanvasGroup canvasGroup;
    public RectTransform rectTransform;

    public List<GameObject> items = new List<GameObject>();

    public TMP_InputField inputField;
    public TMP_Text nameText;
    string username = "";
    [SerializeField] GameObject namePanel;
    bool hasSetName = false;
    [SerializeField] GameObject editNameBtn;

    [SerializeField] SceneManagement sceneManagement;

    private void Start()
    {
        nameText.text = PlayerPrefs.GetString("username");

        if (PlayerPrefs.GetInt("hasSetName") == 1)
        {
            editNameBtn.SetActive(true);
        }
    }

    public void PanelFadeIn()
    {
        canvasGroup.alpha = 0f;
        rectTransform.transform.localPosition = new Vector3(0f, -1000f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, 0f), fadeTime, false).SetEase(Ease.OutElastic);
        canvasGroup.DOFade(1, fadeTime);
        StartCoroutine("ItemsAnimation");
    }

    public void PanelFadeOut()
    {
        canvasGroup.alpha = 1f;
        rectTransform.transform.localPosition = new Vector3(0f, 0f, 0f);
        rectTransform.DOAnchorPos(new Vector2(0f, -1000f), fadeTime, false).SetEase(Ease.InOutQuint);
        canvasGroup.DOFade(0, fadeTime);
    }

    IEnumerator ItemsAnimation()
    {
        foreach (GameObject item in items)
        {
            item.transform.localScale = Vector3.zero;
        }

        foreach (GameObject item in items)
        {
            item.transform.DOScale(1f, fadeTime).SetEase(Ease.OutBounce);
            yield return new WaitForSeconds(0.25f);
        }
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
            namePanel.SetActive(true);
        }
        if (PlayerPrefs.GetInt("hasSetName") == 1)
        {
            namePanel.SetActive(false);
            sceneManagement.canProceed = true;
            sceneManagement.FadeToScene();
        }
    }

    public void UpdateName()
    {
        username = inputField.text;
        nameText.text = username;
        editNameBtn.SetActive(true);
        PlayerPrefs.SetString("username", username);
        PlayerPrefs.SetInt("hasSetName", 1);
        hasSetName = true;
        PlayerPrefs.Save();     
    }


    private void Update()
    {
        Debug.Log("PLAYER NAME: " + PlayerPrefs.GetString("username").ToString());
        Debug.Log("HAS SET NAME: " + PlayerPrefs.GetInt("hasSetName").ToString());
    }

    public void DeletePlayerPref()
    {
        PlayerPrefs.DeleteKey("username");
        PlayerPrefs.DeleteKey("hasSetName");
    }
}
