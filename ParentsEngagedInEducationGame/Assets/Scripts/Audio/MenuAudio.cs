using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuAudio : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.SetMusicVolume();
        AudioManager.Instance.SetSFXVolume();
        if (!AudioManager.Instance.IsPlaying("Menu"))
        {
            AudioManager.Instance.Play("Menu");
            AudioManager.Instance.Loop("Menu");
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
    public static void StartSound()
    {
        AudioManager.Instance.Play("Bells");
        AudioManager.Instance.Stop("Menu");
    }

}
