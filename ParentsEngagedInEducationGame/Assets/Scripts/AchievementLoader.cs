using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementLoader : MonoBehaviour
{
    [SerializeField] GameObject achievementPrefab;

    float bufferTime = 0.1f;
    float elapsedTime = 0f;
    bool isBufferComplete;

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0f;
        isBufferComplete = false;        
    }

    private void Update()
    {
        if (elapsedTime >= bufferTime && !isBufferComplete)
        {
            AchievementObject[] achievements = Classroom.GetScriptableObjects<AchievementObject>("Achievements");

            for (int i = 0; i < achievements.Length; i++)
            {
                GameObject obj = Instantiate(achievementPrefab, transform);
                achievementPrefab.GetComponentInChildren<TextMeshProUGUI>().text =
                    achievements[i].decription;
            }

            isBufferComplete = true;
        }

        elapsedTime += Time.deltaTime;
    }
}
