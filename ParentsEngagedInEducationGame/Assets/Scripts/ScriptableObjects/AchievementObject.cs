using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AchievementObject : ScriptableObject
{
    public AchievementTypes achievementType;
    public string decription;
    public int grade;
    public int achievementThreshold; // The number needed to meet the achievement condition

    public bool CheckCondition()
    {
        if (achievementType == AchievementTypes.TotalCorrect)
        {
            if (AchievementManager.Instance.CheckCorrectQuestions(grade) >= achievementThreshold)
            {
                return true;
            }
        }
        else if (achievementType == AchievementTypes.InARow)
        {

        }
        else if (achievementType == AchievementTypes.Unlock)
        {

        }

        return false;
    }
}

public enum AchievementTypes
{
    TotalCorrect,
    InARow,
    Unlock
}
