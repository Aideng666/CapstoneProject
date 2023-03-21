using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class QuestionScriptableObject : ScriptableObject
{
    [Header("Base Variables")]
    public int grade;
    public int questionNum; //number of the question for each grade, this should align with the number at the end of the name of each scriptable object u make
    public Subjects subject;
    //public QuestionTypes questionType;
    [TextArea(3, 8)]
    public string question;
    [TextArea(3, 8)]
    public string learningTip;

    [Header("Multiple Choice Variables")]
    public string[] mcAnswers = new string[4];
    [Range(0, 3)]
    public int mcCorrectAnswerIndex = 0;
}

public enum Subjects
{
    None,
    Math,
    Science,
    Literacy
}
