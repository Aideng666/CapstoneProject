using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAudio : MonoBehaviour
{
    [SerializeField] AudioSource start;

    private void Start()
    {
        //set the volume of the initial start button
        start.volume = PlayerPrefs.GetFloat("SFXVolume");
    }
    //play the start sound
    public void pressed()
    {
        start.Play();
    }
}

