using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        if (!AudioManager.Instance.IsPlaying("Question") && GameManager.Instance.currentGamestate==GameStates.Classroom)
        {
            AudioManager.Instance.Play("Question");
            AudioManager.Instance.Loop("Question");
        }
        else
        {
            AudioManager.Instance.Play("Hallway");
            AudioManager.Instance.Loop("Hallway");
        }


    }
    public void BackSound()
    {

    }

    public void DoorSound()
    {

    }

    public void CorrectSfx()
    {

    }

    public void Wrong()
    {

    }
    public void GradSfx()
    {

    }

}
