using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    //Dictionary of questions and achievements to check which ones have been answered correctly or achieved
    Dictionary<QuestionScriptableObject, bool> allQuestions = new Dictionary<QuestionScriptableObject, bool>(300); // Bool is for if the player has ever answered it correctly
    Dictionary<AchievementObject, bool> receivedAchievements = new Dictionary<AchievementObject, bool>(49);

    //Array of all questions and achievements
    QuestionScriptableObject[] questions;
    AchievementObject[] achievements;

    public static AchievementManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        //Setting player prefs when the game exits so it saves for next playthrough
        foreach (KeyValuePair<QuestionScriptableObject, bool> question in allQuestions)
        {
            if (question.Value)
            {
                PlayerPrefs.SetInt(question.Key.name, 1);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        questions = Classroom.GetQuestions<QuestionScriptableObject>("Questions");
        achievements = Classroom.GetQuestions<AchievementObject>("Achievements");

        //Checks each question to see if it has previously been answered correctly
        foreach (QuestionScriptableObject question in questions)
        {
            if (PlayerPrefs.HasKey(question.name))
            {
                allQuestions.Add(question, true);
            }
            else
            {
                allQuestions.Add(question, false);
            }
        }

        //Checks each achievement to see if it has previously been answered correctly
        foreach (AchievementObject achievement in achievements)
        {
            if (PlayerPrefs.HasKey(achievement.name))
            {
                receivedAchievements.Add(achievement, true);
            }
            else
            {
                receivedAchievements.Add(achievement, false);
            }
        }
    }

    //Performs updates only every time a question is answered in the game
    public void AnswerQuestion(QuestionScriptableObject question, bool correct, int grade)
    {
        if (!correct)
        {
            return;
        }

        allQuestions[question] = true;

        CheckAchievements();
    }

    //Goes through all question based achievements to check if they have been completed
    public void CheckAchievements()
    {
        foreach (AchievementObject achievement in Classroom.GetQuestions<AchievementObject>("Achievements"))
        {
            if (!PlayerPrefs.HasKey(achievement.name) && achievement.CheckCondition())
            {
                PlayerPrefs.SetInt(achievement.name, 1);

                print($"You Got The Achievement for {achievement.name}");
            }
        }
    }

    //Checks all the questions to see if they have been answered correctly before
    public int CheckCorrectQuestions(int grade)
    {
        int numCorrect = 0;

        foreach (KeyValuePair<QuestionScriptableObject, bool> question in allQuestions)
        {
            if (question.Key.grade == grade)
            {
                if (question.Value)
                {
                    numCorrect++;
                }
            }
        }

        return numCorrect;
    }
}
