using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradAudio : MonoBehaviour
{
    [SerializeField] AudioSource click;
    [SerializeField] AudioSource grad;

    private void Start()
    {
        click.volume = PlayerPrefs.GetFloat("SFXVolume");
        grad.volume = PlayerPrefs.GetFloat("MusicVolume");
        grad.Play();
    }
    public void pressed()
    {
        click.Play();
    }

}