using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

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
    /*[HideInInspector] */public string[] mcAnswers = new string[4];
    [Range(0, 3)]
    /*[HideInInspector]*/ public int mcCorrectAnswerIndex = 0;

    //[Header("True or False Variables")]
    //[HideInInspector] public bool _trueFalseAnswer;

    //[Header("Select All The Apply Variables")]
    //[HideInInspector] public string[] _selectAllAnswers = new string[4];
    //[HideInInspector] public List<int> _selectAllCorrectIndices = new List<int>();
}

public enum Subjects
{
    Math,
    Science,
    Literacy
}

public enum QuestionTypes
{
    MultipleChoice,
    TrueOrFalse,
    SelectAllThatApply,
    FillInBlank
}
