using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        editNameButton.transform.localScale = new Vector3(0f, 0f, 0f);

        if (PlayerPrefs.GetInt("hasSetName") == 1)
        {
            editNameButton.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    //opens the name panel
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
            SceneManager.LoadScene("Main");
        }
    }

    //Changes the users name
    public void UpdateUserName()
    {
        username = inputField.text;
        nameText.text = username;
        editNameButton.SetActive(true);
        editNameButton.transform.localScale = new Vector3(1f, 1f, 1f);
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
        //Makes sure the pplayer has a name set before entering the game
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
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("GradesUnlocked", 1);
    }
}
