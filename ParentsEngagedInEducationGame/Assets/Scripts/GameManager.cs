using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Hallway hallwayEnvironment;
    [SerializeField] Classroom classroomEnvironment;
    [SerializeField] GameObject achievementButton;

    public GameStates currentGamestate { get; private set; } = GameStates.Hallway;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
    }

    private void OnDestroy()
    {
        //print("Removed PlayerPrefs, THIS IS TEMPORARY");

        //Temp
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetInt("GradesUnlocked", 1);
    }

    public void EnterClassroom(int grade)
    {
        hallwayEnvironment.gameObject.SetActive(false);
        classroomEnvironment.gameObject.SetActive(true);
        achievementButton.transform.localScale = new Vector3(0f, 0f, 0f);
        classroomEnvironment.InitClassroom(grade);

        //Play Classroom theme
        AudioManager.Instance.Play("Question");
        AudioManager.Instance.Loop("Question");
        currentGamestate = GameStates.Classroom;
    }

    public void ReplayLevel(int grade)
    {
        classroomEnvironment.gameObject.SetActive(false);
        classroomEnvironment.gameObject.SetActive(true);
        classroomEnvironment.InitClassroom(grade);

        //Play Classroom theme
        AudioManager.Instance.Play("Question");
        AudioManager.Instance.Loop("Question");
        currentGamestate = GameStates.Classroom;
    }

    public void Continue()
    {
        classroomEnvironment.gameObject.SetActive(false);
        hallwayEnvironment.gameObject.SetActive(true);
        achievementButton.transform.localScale = new Vector3(0.71721f, 0.71721f, 0.71721f);
        Camera.main.GetComponent<CameraMovement>().ResetCamPos();

        //Stop classroom theme and play hallway theme
        AudioManager.Instance.Stop("Question");
        AudioManager.Instance.Play("Hallway");
        AudioManager.Instance.Loop("Hallway");
        currentGamestate = GameStates.Hallway;
    }
}

public enum GameStates
{
    Menu,
    Hallway,
    Classroom
}
