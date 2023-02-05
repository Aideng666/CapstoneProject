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

    [Header("Question Panel")]
    [SerializeField] GameObject questionPanel;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] TextMeshProUGUI[] answerTexts = new TextMeshProUGUI[4];
    [SerializeField] Toggle[] answerToggles = new Toggle[4];
    [SerializeField] int totalQuestionNum = 30;
    [SerializeField] int numOfChances = 10;

    QuestionScriptableObject[] questionBank;
    QuestionScriptableObject[] questionsToAsk;

    Dictionary<QuestionScriptableObject, bool> answeredQuestions;

    int correctAnswersNeeded = 5;
    int currentQuestionIndex = 0;
    int selectedGrade;
    bool beginGrade = false;
    bool waitingForAnswer = false;
    bool gradeComplete;

    private void OnEnable()
    {
        questionPanel.SetActive(false);
        reportCardPanel.SetActive(false);
        waitingForAnswer = false;
        gradeComplete = false;

        answeredQuestions = new Dictionary<QuestionScriptableObject, bool>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gradeComplete)
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
        }

        if (beginGrade && !gradeComplete)
        {
            if (currentQuestionIndex >= questionsToAsk.Length)
            {
                gradeComplete = true;
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
            }
            else
            {
                print("Incorrect");

                answeredQuestions.Add(currentQuestion, false);
            }

            waitingForAnswer = false;
            currentQuestionIndex++;
            questionPanel.SetActive(false);
        }
    }

    public void ReplayLevel()
    {
        //reportCardPanel.SetActive(false);
        GameManager.Instance.ReplayLevel(selectedGrade);
    }

    public void Continue()
    {
        reportCardPanel.SetActive(false);
        GameManager.Instance.Continue();
    }

    public void InitClassroom(int grade)
    {
        questionBank = new QuestionScriptableObject[totalQuestionNum];
        questionsToAsk = new QuestionScriptableObject[numOfChances];
        currentQuestionIndex = 0;
        beginGrade = false;
        selectedGrade = grade;

        switch (grade)
        {
            case -1:

                questionBank = GetQuestions<QuestionScriptableObject>("JK");

                break;

            case 0:

                questionBank = GetQuestions<QuestionScriptableObject>("SK");

                break;

            case 1:

                questionBank = GetQuestions<QuestionScriptableObject>("Grade 1");

                break;

            case 2:

                questionBank = GetQuestions<QuestionScriptableObject>("Grade 2");

                break;

            case 3:

                questionBank = GetQuestions<QuestionScriptableObject>("Grade 3");

                break;

            case 4:

                questionBank = GetQuestions<QuestionScriptableObject>("Grade 4");

                break;

            case 5:

                questionBank = GetQuestions<QuestionScriptableObject>("Grade 5");

                break;

            case 6:

                questionBank = GetQuestions<QuestionScriptableObject>("Grade 6");

                break;

            case 7:

                questionBank = GetQuestions<QuestionScriptableObject>("Grade 7");

                break;

            case 8:

                questionBank = GetQuestions<QuestionScriptableObject>("Grade 8");

                break;
        }


        for (int i = 0; i < numOfChances; i++)
        {
            int randomIndex = Random.Range(0, totalQuestionNum);
            bool alreadyPicked = false;

            for (int j = 0; j < numOfChances; j++)
            {
                if (questionBank[randomIndex] == questionsToAsk[j])
                {
                    i--;

                    alreadyPicked = true;
                    break;
                }
            }

            if (!alreadyPicked)
            {
                questionsToAsk[i] = questionBank[randomIndex];
            }
        }

        beginGrade = true;
    }


    public static T[] GetQuestions<T>(string folderName) where T : ScriptableObject
    {
        T[] instanceList = Resources.LoadAll<T>(folderName);

        return instanceList;
    }
}
