using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] int grade; // -1 = JK | 0 = SK

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnterGrade()
    {
        GetComponent<Animator>().SetTrigger("DoorOpened");

        GameManager.Instance.EnterClassroom(grade);
    }
}
