using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway : MonoBehaviour
{
    [SerializeField] List<Door> doors = new List<Door>();
    Dictionary<Door, bool> unlockedDoors;

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
        AchievementManager.Instance.CheckAchievements();
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
        InputHandler.Instance.DetectDrag();

        Door selectedDoor = InputHandler.Instance.DetectDoorTap();

        if (selectedDoor != null)
        {
            foreach (KeyValuePair<Door, bool> door in unlockedDoors)
            {
                if (selectedDoor == door.Key)
                {
                    if (door.Value)
                    {
                        selectedDoor.EnterGrade();
                    }
                    else
                    {
                        //Let the user know that the door they selected is locked somehow
                        //Probs some animation or smth
                        print("This door is locked");
                    }
                }
            }
        }
    }

    public void UnlockNextGrade()
    {
        foreach (Door door in doors)
        {
            if (!unlockedDoors[door])
            {
                unlockedDoors[door] = true;

                PlayerPrefs.SetInt("GradesUnlocked", PlayerPrefs.GetInt("GradesUnlocked") + 1);

                return;
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
