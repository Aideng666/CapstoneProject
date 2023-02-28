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
            return AchievementManager.Instance.CheckCorrectQuestions(grade) >= achievementThreshold;
        }
        else if (achievementType == AchievementTypes.InARow)
        {
            return Classroom.Instance.correctAnswerStreak >= achievementThreshold && grade == Classroom.Instance.selectedGrade;
        }
        else if (achievementType == AchievementTypes.Unlock)
        {
            return grade != 8 && Hallway.Instance.GetUnlockedDoors()[Hallway.Instance.GetDoors()[grade]];
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
