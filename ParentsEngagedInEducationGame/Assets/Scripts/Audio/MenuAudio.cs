using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MenuAudio : MonoBehaviour
{

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    // Start is called before the first frame update
    void Awake()
    {
        if (!AudioManager.Instance.IsPlaying("Menu") && !AudioManager.Instance.IsPlaying("Menu"))
        {
            AudioManager.Instance.Play("Menu");
            AudioManager.Instance.Loop("Menu");
        }
        musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
        sfxSlider.onValueChanged.AddListener(delegate { SetSFXVolume(); });
    }

    public void SetMusicVolume()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    public float GetMusicVolume()
    {
        return musicSlider.value;
    }

    public void SetSFXVolume()
    {
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }

    public float GetSFXVolume()
    {
        return sfxSlider.value;
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
