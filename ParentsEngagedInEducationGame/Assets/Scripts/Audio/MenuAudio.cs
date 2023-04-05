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

    //public void SetMusicVolume()
    //{

    //    PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);

    //    AudioManager.Instance.sounds[0].source.volume = PlayerPrefs.GetFloat("MusicVolume");

    //}

    //public float GetMusicVolume()
    //{
    //    return musicSlider.value;
    //}

    //public void SetSFXVolume()
    //{
    //    PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);

    //    for (int i = 1; i < AudioManager.Instance.sounds.Length; i++)
    //    {
    //        AudioManager.Instance.sounds[i].source.volume = PlayerPrefs.GetFloat("SFXVolume");
    //    }

    //}

    //public float GetSFXVolume()
    //{
    //    return sfxSlider.value;
    //}
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
        //AudioManager.Instance.Play("Bells");
        AudioManager.Instance.Stop("Menu");
    }

}
