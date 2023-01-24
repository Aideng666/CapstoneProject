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
    public int _grade;
    public Subjects _subject;
    public QuestionTypes _questionType;
    public string _question;
    public string _learningTip;

    [Header("Multiple Choice Variables")]
    [HideInInspector] public string[] _mcAnswers = new string[4];
    [Range(0, 3)]
    [HideInInspector] public int _mcCorrectAnswerIndex = 0;

    [Header("True or False Variables")]
    [HideInInspector] public bool _trueFalseAnswer;

    [Header("Select All The Apply Variables")]
    [HideInInspector] public string[] _selectAllAnswers = new string[4];
    [HideInInspector] public List<int> _selectAllCorrectIndices = new List<int>();
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
