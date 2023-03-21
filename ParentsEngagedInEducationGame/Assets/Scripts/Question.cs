using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question
{
    public string _question { get; private set; }
    public string _learningTip { get; private set; }
    public int _grade { get; private set; }
    public Subjects _subject { get; private set; }
    public string _correctAnswer { get; private set; }
    public string[] _wrongAnswers { get; private set; } = new string[3];
    

    public Question(string question, string learningTip, int grade, Subjects subject, string correctAnswer, string[] wrongAnswers)
    {
        _question = question;
        _learningTip = learningTip;
        _grade = grade;
        _subject = subject;
        _correctAnswer = correctAnswer;
        _wrongAnswers = wrongAnswers;
    }
}
