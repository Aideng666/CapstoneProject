using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway : MonoBehaviour
{
    [SerializeField] List<Door> doors = new List<Door>();
    Dictionary<Door, bool> unlockedDoors;

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
        if (AchievementManager.Instance != null)
        {
            AchievementManager.Instance.CheckAchievements();
        }

        //Camera cam = Camera.main;
        //cam.transform.position = new Vector3(-2f, cam.transform.position.y, cam.transform.position.z);
    }

    // Start is called before the first frame update
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

        if (!tweenScript.isPanelOpen)
        {
            InputHandler.Instance.DetectDrag();

            selectedDoor = InputHandler.Instance.DetectDoorTap();
        }

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
                        //selectedDoor.EnterGrade();
                        AudioManager.Instance.Stop("Hallway");
                        AudioManager.Instance.Play("Door Open");

                    }
                    else
                    {
                        //Let the user know that the door they selected is locked somehow
                        //Probs some animation or smth
                        print("This door is locked");
                        AudioManager.Instance.Play("Door Lock");

                    }
                }
            }
        }
    }

    IEnumerator DelayGradeEntry(Door door)
    {
        while (door.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime < 1.3f || door.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            yield return null;
        }

        door.EnterGrade();

        yield return null;
    }

    public void UnlockNextGrade()
    {
        foreach (Door door in doors)
        {
            if (!unlockedDoors[door])
            {
                unlockedDoors[door] = true;

                //door.UnlockStar();

                PlayerPrefs.SetInt("GradesUnlocked", PlayerPrefs.GetInt("GradesUnlocked") + 1);

                return;
            }
        }
    }

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
