using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    //Dictionary of questions and achievements to check which ones have been answered correctly or achieved
    Dictionary<Question, bool> allQuestions = new Dictionary<Question, bool>(); // Bool is for if the player has ever answered it correctly
    Dictionary<AchievementObject, bool> receivedAchievements = new Dictionary<AchievementObject, bool>();

    //Array of all questions and achievements
    List<Question> questions;
    AchievementObject[] achievements;

    public static AchievementManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        //Setting player prefs when the game exits so it saves for next playthrough
        foreach (KeyValuePair<Question, bool> question in allQuestions)
        {
            if (question.Value)
            {
                PlayerPrefs.SetInt($"{question.Key._grade}_{question.Key._subject.ToString()}_{question.Key._questionNum}", 1);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        questions = QuestionReader.Instance.questionList;
        achievements = Classroom.GetScriptableObjects<AchievementObject>("Achievements");

        //Checks each question to see if it has previously been answered correctly
        foreach (Question question in questions)
        {
            if (PlayerPrefs.HasKey($"{question._grade}_{question._subject.ToString()}_{question._questionNum}"))
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
    public void AnswerQuestion(Question question, bool correct, int grade)
    {
        if (!correct)
        {
            CheckAchievements(grade);

            return;
        }

        allQuestions[question] = true;

        CheckAchievements(grade);
    }

    //Goes through all question based achievements to check if they have been completed
    public void CheckAchievements(int grade = -1)
    {
        foreach (AchievementObject achievement in Classroom.GetScriptableObjects<AchievementObject>("Achievements"))
        {
            if (achievement.grade == grade || grade == -1)
            {
                if (!PlayerPrefs.HasKey(achievement.name) && achievement.CheckCondition())
                {
                    PlayerPrefs.SetInt(achievement.name, 1);

                    print($"You Got The Achievement for {achievement.name}");
                }
            }
        }
    }

    //Checks all the questions to see if they have been answered correctly before
    public int CheckCorrectQuestions(int grade)
    {
        int numCorrect = 0;

        foreach (KeyValuePair<Question, bool> question in allQuestions)
        {
            if (question.Key._grade == grade)
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
