using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway : MonoBehaviour
{
    [SerializeField] List<Door> doors = new List<Door>();
    Dictionary<Door, bool> unlockedDoors; //To check if each door has been unlocked or not in the hallway

    [SerializeField] UITweening tweenScript;

    public static Hallway Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
    }

    private void OnEnable()
    {
        //Checks which achievements that the player has unlocked already
        if (AchievementManager.Instance != null)
        {
            AchievementManager.Instance.CheckAchievements();
        }

        Camera cam = Camera.main;
        cam.transform.position = new Vector3(-2f, cam.transform.position.y, cam.transform.position.z);
    }

    // Start is called before the first frame update
    // Initializes the lists and dictionary based on playerprefs
    void Start()
    {
        unlockedDoors = new Dictionary<Door, bool>();

        if (!PlayerPrefs.HasKey("GradesUnlocked"))
        {
            PlayerPrefs.SetInt("GradesUnlocked", 1);
        }

        for (int i = 0; i < PlayerPrefs.GetInt("GradesUnlocked"); i++)
        {
            unlockedDoors.Add(doors[i], true);
        }

        for (int i = PlayerPrefs.GetInt("GradesUnlocked"); i < doors.Count; i++)
        {
            unlockedDoors.Add(doors[i], false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Door selectedDoor = null;

        //Activates input when the hallway is active
        if (!tweenScript.isPanelOpen)
        {
            InputHandler.Instance.DetectDrag();
            InputHandler.Instance.DetectMouseDrag();

            selectedDoor = InputHandler.Instance.DetectDoorTap();
        }

        //Checks if the player has tapped on and plays the respective animation before entering the grade
        if (selectedDoor != null)
        {
            foreach (KeyValuePair<Door, bool> door in unlockedDoors)
            {
                if (selectedDoor == door.Key)
                {
                    if (door.Value)
                    {
                        selectedDoor.GetComponent<Animator>().SetTrigger("DoorOpened");
                        StartCoroutine(DelayGradeEntry(selectedDoor));
                        AudioManager.Instance.Stop("Hallway");
                        AudioManager.Instance.Play("Door Open");

                    }
                    else
                    {
                        AudioManager.Instance.Play("Door Lock");
                    }
                }
            }
        }
    }

    //Makes sure the animation is done playing before entering the grade
    IEnumerator DelayGradeEntry(Door door)
    {
        while (door.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.3f || door.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return null;
        }

        door.EnterGrade();

        yield return null;
    }

    //public void UnlockNextGrade()
    //{
    //    foreach (Door door in doors)
    //    {
    //        if (!unlockedDoors[door])
    //        {
    //            unlockedDoors[door] = true;

    //            //door.UnlockStar();

    //            PlayerPrefs.SetInt("GradesUnlocked", PlayerPrefs.GetInt("GradesUnlocked") + 1);

    //            return;
    //        }
    //    }
    //}

    //Unlocks the given grade for the player
    public void UnlockGrade(int grade)
    {
        foreach (Door door in doors)
        {
            if (door.GetGrade() == grade)
            {
                if (PlayerPrefs.GetInt("GradesUnlocked") == grade)
                {
                    unlockedDoors[door] = true;

                    //door.UnlockStar();

                    PlayerPrefs.SetInt("GradesUnlocked", PlayerPrefs.GetInt("GradesUnlocked") + 1);

                    return;
                }
            }
        }
    }

    public Dictionary<Door, bool> GetUnlockedDoors()
    {
        return unlockedDoors;
    }

    public List<Door> GetDoors()
    {
        return doors;
    }
}
