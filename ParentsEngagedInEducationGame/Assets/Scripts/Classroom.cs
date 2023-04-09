using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using Newtonsoft.Json.Serialization;

public class Classroom : MonoBehaviour
{
    [SerializeField] GameObject[] teachers = new GameObject[3];
    [SerializeField] GameObject[] classrooms = new GameObject[3];

    //UI References
    [Header("Report Card Panel")]
    [SerializeField] TextMeshProUGUI mathMarkText;
    [SerializeField] TextMeshProUGUI scienceMarkText;
    [SerializeField] TextMeshProUGUI literacyMarkText;
    [SerializeField] TextMeshProUGUI letterGradeText;
    [SerializeField] GameObject shadePanel;
    [SerializeField] GameObject reportCard;
    [SerializeField] GameObject reportCardResultText;
    [SerializeField] GameObject globalCanvas;

    [Header("Question Panel")]
    [SerializeField] GameObject questionPanel;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] TextMeshProUGUI[] answerTexts = new TextMeshProUGUI[4];
    [SerializeField] Toggle[] answerToggles = new Toggle[4];
    [SerializeField] int totalQuestionNum = 30;
    [SerializeField] int numOfChances = 10;

    [SerializeField] GameObject answersPanel;
    [SerializeField] GameObject learningPanel;
    [SerializeField] GameObject answerResultText;

    [SerializeField] GameObject confirmButton;
    [SerializeField] GameObject[] scienceSummary;
    [SerializeField] TextMeshProUGUI gradeLabel;

    //List<QuestionScriptableObject> questionBank;
    //QuestionScriptableObject[] questionsToAsk;
    Question[] questionsToAsk;

    Dictionary<Question, bool> answeredQuestions;

    int currentQuestionIndex = 0;
    bool beginGrade = false;
    bool reportCardShown = false;
    bool waitingForAnswer = false;
    bool gradeComplete;
    int correctAnswersThisAttempt;
    int correctAnswerIndex;

    float answerResultDuration = 0.8f;
    float answerResultTweenDuration = 0.5f;

    int currentClassroomIndex;

    Camera cam;

    public int selectedGrade { get; private set; }
    public int correctAnswerStreak { get; private set; }

    public static Classroom Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    //Resets the classroom environment when it becomes enables
    private void OnEnable()
    {
        questionPanel.SetActive(false);
        shadePanel.SetActive(false);
        waitingForAnswer = false;
        gradeComplete = false;
        reportCardShown = false;
        answersPanel.SetActive(false);
        correctAnswerStreak = 0;
        currentQuestionIndex = 0;
        correctAnswersThisAttempt = 0;
        correctAnswerIndex = 0;
        answeredQuestions = new Dictionary<Question, bool>();

        confirmButton.SetActive(false);

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(-2f, cam.transform.position.y, cam.transform.position.z);

        //Sets the correct classroom environment to be active
        if (selectedGrade == 0 ) 
        {
            currentClassroomIndex = 0;
        }
        if (selectedGrade >= 1 && selectedGrade <= 3)
        {
            currentClassroomIndex = 1;
        }
        else if (selectedGrade >= 4 && selectedGrade <= 6)
        {
            currentClassroomIndex = 2;
        }
        else if (selectedGrade >= 7 && selectedGrade <= 8)
        {
            currentClassroomIndex = 3;
        }

        for (int i = 0; i < classrooms.Length; i++)
        {
            if (currentClassroomIndex == i)
            {
                classrooms[i].SetActive(true);
                //teachers[i].SetActive(true);
            }
            else
            {
                classrooms[i].SetActive(false);
                //teachers[i].SetActive(false);
            }
        }

        UpdateGradeLabel();

        if (gradeComplete && !reportCardShown)
        {
            ShowReportCard();

            reportCardShown = true;
        }    

        if (beginGrade && !gradeComplete)
        {
            //Finishes the grade after answering all necessary questions
            if (currentQuestionIndex >= questionsToAsk.Length || correctAnswersThisAttempt >= 5)
            {          
                gradeComplete = true;
                correctAnswersThisAttempt = 0;
                
                answerResultText.SetActive(false);
                learningPanel.SetActive(false);
                PlayReportCardSequence(reportCard);

                return;
            }        

            //Current question to ask in the game
            Question currentQuestion = questionsToAsk[currentQuestionIndex];

            //Opens the panel to view the question and answer options
            if (!waitingForAnswer)
            {
                questionPanel.SetActive(true);
                answersPanel.SetActive(true);

                questionText.text = currentQuestion._question;

                //Puts each answer in a random spot every time
                List<int> answerIndices = new List<int>() { 0, 1, 2, 3};
                int randomCorrectIndex = Random.Range(0, answerIndices.Count);
                correctAnswerIndex = answerIndices[randomCorrectIndex];

                answerTexts[answerIndices[randomCorrectIndex]].text = $"{currentQuestion._correctAnswer}";
                answerIndices.RemoveAt(randomCorrectIndex);

                for (int i = 0; i < currentQuestion._wrongAnswers.Length; i++)
                {
                    int randomIndex = Random.Range(0, answerIndices.Count);

                    answerTexts[answerIndices[randomIndex]].text = $"{currentQuestion._wrongAnswers[i]}";

                    answerIndices.RemoveAt(randomIndex);
                }

                waitingForAnswer = true;
            }
        }   
        
        // Hide science for Kindergarten and Grade 1 as there are no science questions
        if (selectedGrade == 0 || selectedGrade == 1)
        {
            foreach(GameObject sci in scienceSummary)
            {
                sci.SetActive(false);
            }
        }
        else
        {
            foreach (GameObject sci in scienceSummary)
            {
                sci.SetActive(true);
            }
        }
    }

    //When confirming the answer in game this checks if the selected answer was correct and plays the UI sequence
    public void ConfirmAnswer()
    {
        confirmButton.SetActive(false);

        Question currentQuestion = questionsToAsk[currentQuestionIndex];
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
            learningPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = questionsToAsk[currentQuestionIndex]._learningTip;

            if (answer == correctAnswerIndex)
            {
                answerResultText.GetComponent<TextMeshProUGUI>().text = "Correct!";

                answeredQuestions.Add(currentQuestion, true);
                correctAnswerStreak++;
                correctAnswersThisAttempt++;

                AudioManager.Instance.Play("Correct");
                //teachers[currentClassroomIndex].GetComponent<Animator>().SetTrigger("Correct");
                StartCoroutine(PlayTeacherLearningTipPose());

                PlayAnswerResultSequence();

                AchievementManager.Instance.AnswerQuestion(currentQuestion, true, selectedGrade);
            }
            else
            {
                answerResultText.GetComponent<TextMeshProUGUI>().text = "Incorrect";

                AudioManager.Instance.Play("Incorrect");
                //teachers[currentClassroomIndex].GetComponent<Animator>().SetTrigger("Incorrect");
                StartCoroutine(PlayTeacherLearningTipPose());

                PlayAnswerResultSequence();

                answeredQuestions.Add(currentQuestion, false);
                correctAnswerStreak = 0;
            }

            waitingForAnswer = false;
            currentQuestionIndex++;
            questionPanel.SetActive(false);
            answersPanel.SetActive(false);
        }
    }

    public void ShowReportCard()
    {
        questionPanel.SetActive(false);
        shadePanel.SetActive(true);
        globalCanvas.SetActive(false);
        answersPanel.SetActive(false);

        Dictionary<Question, bool> mathQuestionsAnswered = new Dictionary<Question, bool>();
        Dictionary<Question, bool> scienceQuestionsAnswered = new Dictionary<Question, bool>();
        Dictionary<Question, bool> literacyQuestionsAnswered = new Dictionary<Question, bool>();

        int mathQuestionsCorrect = 0;
        int scienceQuestionsCorrect = 0;
        int literacyQuestionsCorrect = 0;

        foreach (KeyValuePair<Question, bool> questionAnswered in answeredQuestions)
        {
            switch (questionAnswered.Key._subject)
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

        mathMarkText.text = $"{mathQuestionsCorrect} / {mathQuestionsAnswered.Count}";
        scienceMarkText.text = $"{scienceQuestionsCorrect} / {scienceQuestionsAnswered.Count}";
        literacyMarkText.text = $"{literacyQuestionsCorrect} / {literacyQuestionsAnswered.Count}";     

        CalculateGrade();    
    }

    void CalculateGrade()
    {
        int questionsCorrect = 0;

        //Checks for every answer and if it was correct
        foreach (KeyValuePair<Question, bool> questionAnswered in answeredQuestions)
        {
            if (questionAnswered.Value)
            {
                questionsCorrect++;
            }
        }

        //Calculates pass or fail and if the next grade should be unlocked or not
        float percentage = (float)questionsCorrect / (float)answeredQuestions.Count;

        if (percentage >= 0.5f && selectedGrade == PlayerPrefs.GetInt("GradesUnlocked") - 1)
        {
            Hallway.Instance.UnlockGrade(selectedGrade + 1);                       
        }

        if (percentage >= 0.5f)
        {
            reportCardResultText.GetComponent<TextMeshProUGUI>().text = "Grade Complete!";
            AudioManager.Instance.Play("Congratz");
            AudioManager.Instance.Stop("Question");

            //Hallway.Instance.GetDoors()[selectedGrade].UnlockStar();
        }
        else if (percentage < 0.5f)
        {
            reportCardResultText.GetComponent<TextMeshProUGUI>().text = "Try Again!";
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
        ResetActives();

        questionPanel.SetActive(true);
        answersPanel.SetActive(true);

        GameManager.Instance.ReplayLevel(selectedGrade);
    }

    public void Continue()
    {
        if (selectedGrade == 8 && gradeComplete)
        {
            questionPanel.SetActive(false);
            answersPanel.SetActive(false);
            SceneManager.LoadScene("Graduation");
        }
        else
        { 
            ResetActives();
            questionPanel.SetActive(false);
            answersPanel.SetActive(false);
            GameManager.Instance.Continue();
        }          
    }

    //Creates the classroom entering a grade for it to be ready to be played in
    public void InitClassroom(int grade)
    {
        List<Question> questionBank = QuestionReader.Instance.questionsByGrade[grade];
        questionsToAsk = new Question[totalQuestionNum];
        currentQuestionIndex = 0;
        beginGrade = false;
        selectedGrade = grade;
        letterGradeText.text = "";

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

    //Global function for finding all instances of any scriptable object type
    public static T[] GetScriptableObjects<T>(string folderName) where T : ScriptableObject
    {
        T[] instanceList = Resources.LoadAll<T>(folderName);

        return instanceList;
    }

    //Tweens the report card UI
    public void PlayReportCardSequence(GameObject reportCardPanel)
    {
        Sequence sequence = DOTween.Sequence();

        // Tween in Result Message
        sequence.Append(reportCardResultText.transform.DOScale(1f, 1f).SetEase(Ease.InSine))
            // Wait 1 frame
            .AppendInterval(1f)
            // Tween out Result Message
            .Append(reportCardResultText.transform.DOScale(0f, 1f).SetEase(Ease.OutSine))
            // Wait 1 frame
            .AppendInterval(1f)
            // Tween in the Report Card Panel
            .Append(reportCardPanel.transform.DOScale(1f, 1f).SetEase(Ease.InSine))
            // Wait 1 frame
            .AppendInterval(1f);
    }

    //Tweens the answer result UI
    public void PlayAnswerResultSequence()
    {
        Sequence sequence = DOTween.Sequence();

        // Scale out the questions and answers
        sequence.Append(questionPanel.transform.DOScale(0f, 0f).SetEase(Ease.OutSine))
            .Append(answersPanel.transform.DOScale(0f, 0f).SetEase(Ease.OutSine))
            // Pop in the result text                  
            .Append(answerResultText.transform.DOScale(1f, answerResultTweenDuration).SetEase(Ease.InSine))
            // Linger for 0.8 seconds
            .AppendInterval(answerResultDuration)
            // Pop out the result text
            .Append(answerResultText.transform.DOScale(0f, answerResultTweenDuration).SetEase(Ease.InSine))
            .Append(learningPanel.transform.DOScale(1f, 0.5f).SetEase(Ease.InSine));
    }

    IEnumerator PlayTeacherLearningTipPose()
    {
        yield return new WaitForSeconds(answerResultDuration + (answerResultTweenDuration * 2));

        //teachers[currentClassroomIndex].GetComponent<Animator>().SetTrigger("LearningTip");
    }

    //Goes to the next questions
    public void ResumeFromLearningTip()
    {
        //teachers[currentClassroomIndex].GetComponent<Animator>().SetTrigger("Question");

        learningPanel.transform.DOScale(0f, 0.5f).SetEase(Ease.OutSine);
        questionPanel.transform.DOScale(1f, 0f).SetEase(Ease.InSine);
        answersPanel.transform.DOScale(1f, 0f).SetEase(Ease.InSine);                   
    }

    private void ResetActives()
    {
        shadePanel.SetActive(false);
        globalCanvas.SetActive(true);
        reportCardResultText.transform.localScale = new Vector3(0f, 0f, 0f);
        reportCard.transform.localScale = new Vector3(0f, 0f, 0f);
        questionPanel.transform.localScale = new Vector3(1f, 1f, 1f);
        gradeComplete = false;
        answersPanel.transform.localScale = new Vector3(1f, 1f, 1f);
        answerResultText.SetActive(true);
        answerResultText.transform.localScale = new Vector3(0f, 0f, 0f);
        learningPanel.SetActive(true);
        learningPanel.transform.localScale = new Vector3(0f, 0f, 0f);
        confirmButton.SetActive(false);
    }

    //public void HighlightAnswer()
    //{
    //    if (answerToggles[0].isOn)
    //    {
    //        answerTexts[0].color = Color.white;
    //        answerTexts[1].color = Color.black;
    //        answerTexts[2].color = Color.black;
    //        answerTexts[3].color = Color.black;
    //    }
    //    else if(answerToggles[1].isOn)
    //    {
    //        answerTexts[0].color = Color.black;
    //        answerTexts[1].color = Color.white;
    //        answerTexts[2].color = Color.black;
    //        answerTexts[3].color = Color.black;
    //    }
    //    else if (answerToggles[2].isOn)
    //    {
    //        answerTexts[0].color = Color.black;
    //        answerTexts[1].color = Color.black;
    //        answerTexts[2].color = Color.white;
    //        answerTexts[3].color = Color.black;
    //    }
    //    else if (answerToggles[3].isOn)
    //    {
    //        answerTexts[0].color = Color.black;
    //        answerTexts[1].color = Color.black;
    //        answerTexts[2].color = Color.black;
    //        answerTexts[3].color = Color.white;
    //    }
    //}

    public void UpdateGradeLabel()
    {
        switch (selectedGrade)
        {
            case 0:
                gradeLabel.text = "Kindergarten";
                break;
            case 1:
                gradeLabel.text = "Grade 1";
                break;
            case 2:
                gradeLabel.text = "Grade 2";
                break;
            case 3:
                gradeLabel.text = "Grade 3";
                break;
            case 4:
                gradeLabel.text = "Grade 4";
                break;
            case 5:
                gradeLabel.text = "Grade 5";
                break;
            case 6:
                gradeLabel.text = "Grade 6";
                break;
            case 7:
                gradeLabel.text = "Grade 7";
                break;
            case 8:
                gradeLabel.text = "Grade 8";
                break;
        }
    }
}
