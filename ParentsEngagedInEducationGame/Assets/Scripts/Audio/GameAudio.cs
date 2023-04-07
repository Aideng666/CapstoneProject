using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Set the initial volumes to the Player Prefs
        AudioManager.Instance.SetMusicVolume();
        AudioManager.Instance.SetSFXVolume();
        {
            AudioManager.Instance.Play("Hallway");
            AudioManager.Instance.Loop("Hallway");
        }



    }
    public void ClickSound()
    {
        AudioManager.Instance.Play("Click");

    }
    public void BackSound()
    {
        AudioManager.Instance.Play("Cancel");

    }


 

}
