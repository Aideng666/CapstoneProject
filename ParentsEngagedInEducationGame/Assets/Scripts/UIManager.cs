using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text nameText;
    string username = "";
    [SerializeField] GameObject namePanel;
    bool hasSetName = false;
    [SerializeField] GameObject editNameBtn;
    [SerializeField] Button confirmNameBtn;

    [SerializeField] SceneManagement sceneManagement;

    private void Start()
    {
        nameText.text = PlayerPrefs.GetString("username");

        if (PlayerPrefs.GetInt("hasSetName") == 1)
        {
            editNameBtn.SetActive(true);
        }

        confirmNameBtn.interactable = false;
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
        inputField.text = "";
    }

    public void CloseButton()
    {
        inputField.text = "";
    }

    private void Update()
    {
        Debug.Log("PLAYER NAME: " + PlayerPrefs.GetString("username").ToString());
        Debug.Log("HAS SET NAME: " + PlayerPrefs.GetInt("hasSetName").ToString());

        if (inputField.text == "")
        {
            confirmNameBtn.interactable = false;
        }
        else
        {
            confirmNameBtn.interactable = true;
        }
    }

    public void DeletePlayerPref()
    {
        PlayerPrefs.DeleteKey("username");
        PlayerPrefs.DeleteKey("hasSetName");
    }
}
