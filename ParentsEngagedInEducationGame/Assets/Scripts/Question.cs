using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question
{
    //Data for the questions that were read from the CSV file
    public string _question { get; private set; }
    public string _learningTip { get; private set; }
    public int _grade { get; private set; }
    public Subjects _subject { get; private set; }
    public string _correctAnswer { get; private set; }
    public string[] _wrongAnswers { get; private set; } = new string[3];
    public int _questionNum { get; private set; }
    
    public Question(string question, string learningTip, int grade, Subjects subject, string correctAnswer, string[] wrongAnswers)
    {
        _question = question;
        _learningTip = learningTip;
        _grade = grade;
        _subject = subject;
        _correctAnswer = correctAnswer;
        _wrongAnswers = wrongAnswers;
    }

    //Sets the question num for the difference in same subject questions
    public void SetQuestionNum(int num)
    {
        _questionNum = num;
    }
}
