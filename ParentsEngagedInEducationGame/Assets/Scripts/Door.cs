using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    [SerializeField] int grade; // 0 = Kindergarten
    [SerializeField] Image star;

    // Update is called once per frame
    void Update()
    {
        //If a grade has been completed it will fill the star on top of the door
        if (PlayerPrefs.GetInt("GradesUnlocked") > grade + 1)
        {
            star.fillAmount = 1f;
        }
        else
        {
            star.fillAmount = 0f;
        }
    }

    //Enters the selected grade's classroom
    public void EnterGrade()
    {
        GetComponent<Animator>().SetTrigger("DoorOpened");

        GameManager.Instance.EnterClassroom(grade);
    }

    public int GetGrade()
    {
        return grade;
    }
}
