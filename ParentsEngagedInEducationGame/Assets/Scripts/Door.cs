using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] int grade; // 0 = Kindergarten
    [SerializeField] Image star;
    
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
        AudioManager.Instance.Stop("Hallway");
    }

    public int GetGrade()
    {
        return grade;
    }

    public void UnlockStar()
    {
        star.fillAmount = 1f;
    }
}
