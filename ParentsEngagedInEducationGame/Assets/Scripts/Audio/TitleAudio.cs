using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAudio : MonoBehaviour
{
    [SerializeField] AudioSource start;

    private void Start()
    {
        start.volume = PlayerPrefs.GetFloat("SFXVolume");
    }
    public void pressed()
    {
        start.Play();
    }
}

