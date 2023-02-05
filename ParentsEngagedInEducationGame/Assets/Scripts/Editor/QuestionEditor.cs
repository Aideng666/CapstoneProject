using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(QuestionScriptableObject))]
[CanEditMultipleObjects]
public class QuestionEditor : Editor
{
    //For Multiple Choice
    SerializedProperty _mcAnswersProp;
    SerializedProperty _mcCorrectIndexProp;

    //For True or False
    SerializedProperty _tfAnswerProp;

    //For Select All That Apply
    SerializedProperty _selectAllAnswersProp;
    SerializedProperty _selectAllCorrectIndicesProp;

    private void OnEnable()
    {
        _mcAnswersProp = serializedObject.FindProperty("_mcAnswers");
        _mcCorrectIndexProp = serializedObject.FindProperty("_mcCorrectAnswerIndex");
        _tfAnswerProp = serializedObject.FindProperty("_trueFalseAnswer");
        _selectAllAnswersProp = serializedObject.FindProperty("_selectAllAnswers");
        _selectAllCorrectIndicesProp = serializedObject.FindProperty("_selectAllCorrectIndices");
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        QuestionScriptableObject script = (QuestionScriptableObject)target;

        //switch (script.questionType)
        //{
        //    case QuestionTypes.MultipleChoice:

        //        EditorGUILayout.PropertyField(_mcAnswersProp, new GUIContent("List of Answers"), true);
        //        EditorGUILayout.PropertyField(_mcCorrectIndexProp, new GUIContent("Correct Answer Index"));

        //        break;

        //    case QuestionTypes.TrueOrFalse:

        //        EditorGUILayout.PropertyField(_tfAnswerProp, new GUIContent("Answer"));

        //        break;

        //    case QuestionTypes.SelectAllThatApply:

        //        EditorGUILayout.PropertyField(_selectAllAnswersProp, new GUIContent("List of Answers"), true);
        //        EditorGUILayout.PropertyField(_selectAllCorrectIndicesProp, new GUIContent("Correct Answer Indices"), true);

        //        break;
        //}

        serializedObject.ApplyModifiedProperties();
    }
}
#endif
