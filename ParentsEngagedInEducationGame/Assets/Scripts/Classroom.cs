using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Classroom : MonoBehaviour
{
    [Header("Report Card Panel")]
    [SerializeField] GameObject reportCardPanel;
    [SerializeField] TextMeshProUGUI mathMarkText;
    [SerializeField] TextMeshProUGUI scienceMarkText;
    [SerializeField] TextMeshProUGUI literacyMarkText;
    [SerializeField] TextMeshProUGUI letterGradeText;

    [Header("Question Panel")]
    [SerializeField] GameObject questionPanel;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] TextMeshProUGUI[] answerTexts = new TextMeshProUGUI[4];
    [SerializeField] Toggle[] answerToggles = new Toggle[4];
    [SerializeField] int totalQuestionNum = 30;
    [SerializeField] int numOfChances = 10;

    List<QuestionScriptableObject> questionBank;
    QuestionScriptableObject[] questionsToAsk;

    Dictionary<QuestionScriptableObject, bool> answeredQuestions;

    int currentQuestionIndex = 0;
    bool beginGrade = false;
    bool waitingForAnswer = false;
    bool gradeComplete;
    int correctAnswersThisAttempt;

    public int selectedGrade { get; private set; }
    public int correctAnswerStreak { get; private set; }

    public static Classroom Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        questionPanel.SetActive(false);
        reportCardPanel.SetActive(false);
        waitingForAnswer = false;
        gradeComplete = false;
        correctAnswerStreak = 0;
        currentQuestionIndex = 0;
        correctAnswersThisAttempt = 0;

        answeredQuestions = new Dictionary<QuestionScriptableObject, bool>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gradeComplete && !reportCardPanel.activeInHierarchy)
        {
            ShowReportCard();
        }

        if (beginGrade && !gradeComplete)
        {
            if (currentQuestionIndex >= questionsToAsk.Length || correctAnswersThisAttempt >= 5)
            {
                gradeComplete = true;
                correctAnswersThisAttempt = 0;

                return;
            }

            QuestionScriptableObject currentQuestion = questionsToAsk[currentQuestionIndex];

            if (!waitingForAnswer)
            {
                questionPanel.SetActive(true);

                questionText.text = currentQuestion.question;
                answerTexts[0].text = $"A) {currentQuestion.mcAnswers[0]}";
                answerTexts[1].text = $"B) {currentQuestion.mcAnswers[1]}";
                answerTexts[2].text = $"C) {currentQuestion.mcAnswers[2]}";
                answerTexts[3].text = $"D) {currentQuestion.mcAnswers[3]}";

                waitingForAnswer = true;
            }
        }
    }

    public void ConfirmAnswer()
    {
        QuestionScriptableObject currentQuestion = questionsToAsk[currentQuestionIndex];
        int answer = -1;

        for (int i = 0; i < answerToggles.Length; i++)
        {
            if (answerToggles[i].isOn)
            {
                answer = i;
            }
        }

        if (answer != -1)
        {
            if (answer == currentQuestion.mcCorrectAnswerIndex)
            {
                print("Correct!");

                answeredQuestions.Add(currentQuestion, true);
                correctAnswerStreak++;
                correctAnswersThisAttempt++;

                AchievementManager.Instance.AnswerQuestion(currentQuestion, true, selectedGrade);
            }
            else
            {
                print("Incorrect");

                answeredQuestions.Add(currentQuestion, false);
                correctAnswerStreak = 0;
            }

            waitingForAnswer = false;
            currentQuestionIndex++;
            questionPanel.SetActive(false);
        }
    }

    public void ShowReportCard()
    {
        questionPanel.SetActive(false);
        reportCardPanel.SetActive(true);

        Dictionary<QuestionScriptableObject, bool> mathQuestionsAnswered = new Dictionary<QuestionScriptableObject, bool>();
        Dictionary<QuestionScriptableObject, bool> scienceQuestionsAnswered = new Dictionary<QuestionScriptableObject, bool>();
        Dictionary<QuestionScriptableObject, bool> literacyQuestionsAnswered = new Dictionary<QuestionScriptableObject, bool>();

        int mathQuestionsCorrect = 0;
        int scienceQuestionsCorrect = 0;
        int literacyQuestionsCorrect = 0;

        foreach (KeyValuePair<QuestionScriptableObject, bool> questionAnswered in answeredQuestions)
        {
            switch (questionAnswered.Key.subject)
            {
                case Subjects.Math:

                    mathQuestionsAnswered.Add(questionAnswered.Key, questionAnswered.Value);

                    if (questionAnswered.Value)
                    {
                        mathQuestionsCorrect++;
                    }

                    break;

                case Subjects.Science:

                    scienceQuestionsAnswered.Add(questionAnswered.Key, questionAnswered.Value);

                    if (questionAnswered.Value)
                    {
                        scienceQuestionsCorrect++;
                    }

                    break;

                case Subjects.Literacy:

                    literacyQuestionsAnswered.Add(questionAnswered.Key, questionAnswered.Value);

                    if (questionAnswered.Value)
                    {
                        literacyQuestionsCorrect++;
                    }

                    break;
            }
        }

        mathMarkText.text = $"Math:    {mathQuestionsCorrect}  /  {mathQuestionsAnswered.Count}";
        scienceMarkText.text = $"Science:    {scienceQuestionsCorrect}  /  {scienceQuestionsAnswered.Count}";
        literacyMarkText.text = $"Literacy:    {literacyQuestionsCorrect}  /  {literacyQuestionsAnswered.Count}";

        CalculateGrade();
    }

    void CalculateGrade()
    {
        int questionsCorrect = 0;

        foreach (KeyValuePair<QuestionScriptableObject, bool> questionAnswered in answeredQuestions)
        {
            if (questionAnswered.Value)
            {
                questionsCorrect++;
            }
        }

        float percentage = (float)questionsCorrect / (float)answeredQuestions.Count;

        if (percentage >= 0.5f && selectedGrade == PlayerPrefs.GetInt("GradesUnlocked") - 1)
        {
            Hallway.Instance.UnlockNextGrade();
        }

        switch (percentage)
        {
            case >= 0.9f:

                letterGradeText.text = "A+";

                break;

            case >= 0.85f:

                letterGradeText.text = "A";

                break;

            case >= 0.8f:

                letterGradeText.text = "A-";

                break;

            case >= 0.77f:

                letterGradeText.text = "B+";

                break;

            case >= 0.74f:

                letterGradeText.text = "B";

                break;

            case >= 0.7f:

                letterGradeText.text = "B-";

                break;

            case >= 0.67f:

                letterGradeText.text = "C+";

                break;

            case >= 0.64f:

                letterGradeText.text = "C";

                break;

            case >= 0.6f:

                letterGradeText.text = "C-";

                break;

            case >= 0.57f:

                letterGradeText.text = "D+";

                break;

            case >= 0.54f:

                letterGradeText.text = "D";

                break;

            case >= 0.5f:

                letterGradeText.text = "D-";

                break;
        }
    }

    public void ReplayLevel()
    {
        GameManager.Instance.ReplayLevel(selectedGrade);
    }

    public void Continue()
    {
        reportCardPanel.SetActive(false);
        GameManager.Instance.Continue();
    }

    public void InitClassroom(int grade)
    {
        questionBank = new List<QuestionScriptableObject>(30);
        questionsToAsk = new QuestionScriptableObject[totalQuestionNum];
        currentQuestionIndex = 0;
        beginGrade = false;
        selectedGrade = grade;
        letterGradeText.text = "";

        //Loops through every questions and selects every questions from the given grade to be in the question bank
        foreach (QuestionScriptableObject question in GetScriptableObjects<QuestionScriptableObject>("Questions"))
        {
            if (question.grade == grade)
            {
                questionBank.Add(question);

                print("Adding Question To Bank");
            }
        }

        //loops through the question bank and picks out a select amount at random to be part of the current round of the game
        for (int i = 0; i < totalQuestionNum; i++)
        {
            int randomIndex = Random.Range(0, questionBank.Count);
            bool alreadyPicked = false;

            //For error prevention of duplicate questions
            for (int j = 0; j < totalQuestionNum; j++)
            {
                if (questionsToAsk[j] != null && questionBank[randomIndex] == questionsToAsk[j])
                {
                    i--;

                    alreadyPicked = true;
                    break;
                }
            }

            //Adds the randomly selected question into the current round
            if (!alreadyPicked)
            {
                questionsToAsk[i] = questionBank[randomIndex];
            }
        }

        beginGrade = true;
    }


    public static T[] GetScriptableObjects<T>(string folderName) where T : ScriptableObject
    {
        T[] instanceList = Resources.LoadAll<T>(folderName);

        return instanceList;
    }
}
