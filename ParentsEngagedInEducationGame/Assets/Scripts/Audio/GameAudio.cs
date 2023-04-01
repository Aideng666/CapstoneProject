using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.SetMusicVolume();
        AudioManager.Instance.SetSFXVolume();
        //if (!AudioManager.Instance.IsPlaying("Hallway") && (!AudioManager.Instance.IsPlaying("Question")))
        {
            AudioManager.Instance.Play("Hallway");
            AudioManager.Instance.Loop("Hallway");
        }
        //else
        //{
        //    AudioManager.Instance.Play("Question");
        //    AudioManager.Instance.Loop("Question");
        //}


    }
    public void ClickSound()
    {
        AudioManager.Instance.Play("Click");

    }
    public void BackSound()
    {
        AudioManager.Instance.Play("Cancel");

    }

    public void DoorSound()
    {
        AudioManager.Instance.Play("Click");

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
