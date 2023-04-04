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
        if (PlayerPrefs.GetInt("GradesUnlocked") > grade + 1)
        {
            star.fillAmount = 1f;
        }
        else
        {
            star.fillAmount = 0f;
        }
    }

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
