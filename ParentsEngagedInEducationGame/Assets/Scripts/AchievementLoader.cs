using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AchievementLoader : MonoBehaviour
{
    [SerializeField] GameObject achievementPrefab;
    [SerializeField] Sprite greyImage;
    [SerializeField] Sprite colouredImage;

    float bufferTime = 0.1f; //Delay to make sure the achievements exist before trying to load them
    float elapsedTime = 0f; //Timer for buffer
    bool isBufferComplete; //flag so it only loops once to save resources

    AchievementObject[] achievements;
    List<GameObject> prefabList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0f;
        isBufferComplete = false;        
    }

    private void Update()
    {
        //Loops through each achievement scriptable object that exists in the project and creates a UI icon for each one in the achievements menu
        if (elapsedTime >= bufferTime && !isBufferComplete)
        {
            achievements = Classroom.GetScriptableObjects<AchievementObject>("Achievements");

            for (int i = 0; i < achievements.Length; i++)
            {
                GameObject obj = Instantiate(achievementPrefab, transform);
                obj.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = achievements[i].name;
                obj.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = achievements[i].decription;

                prefabList.Add(obj);
            }

            isBufferComplete = true;
        }

        //Updates the image background for each achievement based on if the player has gotten the achievement or not
        if (isBufferComplete)
        {
            for (int i = 0; i < prefabList.Count; i++)
            {
                if (PlayerPrefs.HasKey(achievements[i].name))
                {
                    prefabList[i].transform.GetChild(0).GetComponent<Image>().sprite = colouredImage;
                    prefabList[i].transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = achievements[i].name;
                    prefabList[i].transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = achievements[i].decription;
                }
                else
                {
                    prefabList[i].transform.GetChild(0).GetComponent<Image>().sprite = greyImage;
                    prefabList[i].transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = achievements[i].name;
                    prefabList[i].transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = achievements[i].decription;
                }
            }
        }

        elapsedTime += Time.deltaTime;
    }
}
