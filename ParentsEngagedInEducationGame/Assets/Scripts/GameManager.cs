using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject hallwayEnvironment;
    [SerializeField] GameObject classroomEnvironment;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterClassroom(int grade)
    {
        hallwayEnvironment.SetActive(false);
        classroomEnvironment.SetActive(true);
    }
}
