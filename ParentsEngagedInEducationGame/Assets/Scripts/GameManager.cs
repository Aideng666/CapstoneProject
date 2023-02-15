using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Hallway hallwayEnvironment;
    [SerializeField] Classroom classroomEnvironment;

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

    public void EnterClassroom(int grade)
    {
        hallwayEnvironment.gameObject.SetActive(false);
        classroomEnvironment.gameObject.SetActive(true);
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
