using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpdateName : MonoBehaviour
{
    [Header("Edit Name Panel")]
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Text nameText;
    string username = "";
    [SerializeField] GameObject editNamePanel;
    [SerializeField] GameObject editNameButton;
    [SerializeField] Button enterButton;

    [SerializeField] GameObject hubCanvasObj;

    // Start is called before the first frame update
    void Start()
    {
        nameText.text = PlayerPrefs.GetString("username");

        if (PlayerPrefs.GetInt("hasSetName") == 1)
        {
            editNameButton.SetActive(true);
        }
    }

    public void ShowNamePanel()
    {     
        if (PlayerPrefs.GetInt("hasSetName") == 0)
        {
            // hasn't set their name, open name panel
            editNamePanel.SetActive(true);
        }
        if (PlayerPrefs.GetInt("hasSetName") == 1)
        {
            editNamePanel.SetActive(false);
            LevelManager.Instance.LoadScene("Main");
            hubCanvasObj.SetActive(false);
            
            // TODO:
            // Camera zoom on door's opening?
        }
    }

    public void UpdateUserName()
    {
        username = inputField.text;
        nameText.text = username;
        editNameButton.SetActive(true);
        PlayerPrefs.SetString("username", username);
        PlayerPrefs.SetInt("hasSetName", 1);
        PlayerPrefs.Save();
        inputField.text = "";
    }

    public void CloseButton()
    {
        inputField.text = "";
    }

    // Update is called once per frame
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

        nameText.text = PlayerPrefs.GetString("username");
    }

    public void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteKey("username");
        PlayerPrefs.DeleteKey("hasSetName");
    }
}
