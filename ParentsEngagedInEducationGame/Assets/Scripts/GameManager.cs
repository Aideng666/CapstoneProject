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
        print("Removed PlayerPrefs, THIS IS TEMPORARY");

        //Temp
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("GradesUnlocked", 1);
    }

    public void EnterClassroom(int grade)
    {
        hallwayEnvironment.gameObject.SetActive(false);
        classroomEnvironment.gameObject.SetActive(true);
        achievementButton.transform.localScale = new Vector3(0f, 0f, 0f);
        classroomEnvironment.InitClassroom(grade);

        currentGamestate = GameStates.Classroom;
    }

    public void ReplayLevel(int grade)
    {
        classroomEnvironment.gameObject.SetActive(false);
        classroomEnvironment.gameObject.SetActive(true);
        classroomEnvironment.InitClassroom(grade);

        currentGamestate = GameStates.Classroom;
    }

    public void Continue()
    {
        classroomEnvironment.gameObject.SetActive(false);
        hallwayEnvironment.gameObject.SetActive(true);
        achievementButton.transform.localScale = new Vector3(1f, 1f, 1f);
        Camera.main.GetComponent<CameraMovement>().ResetCamPos();

        currentGamestate = GameStates.Hallway;
    }
}

public enum GameStates
{
    Menu,
    Hallway,
    Classroom
}
