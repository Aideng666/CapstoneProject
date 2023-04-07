using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    public static AudioManager Instance { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        //Initializes instance of the class
        Instance = this;
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.outputAudioMixerGroup = s.group;
        }

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        //sets the initial value on the music and sound effect slider to the Player Prefab saved sound settings
        musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
        sfxSlider.onValueChanged.AddListener(delegate { SetSFXVolume(); });
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Pause();
    }

    public void UnPause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.UnPause();
    }

    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        return s.source.isPlaying;
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    public void Loop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.loop = true;
    }

    public void StopLoop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.loop = false;
    }

    public void SetMusicVolume()
    {
        //The first 2 sounds in the audiomanager gameobject are the music tracks
        sounds[0].source.volume = musicSlider.value;
        sounds[1].source.volume = musicSlider.value;

        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    public float GetMusicVolume()
    {
        return musicSlider.value;
    }

    public void SetSFXVolume()
    {
        //The first 2 sounds in the audiomanager gameobject are the music tracks
        
        //The rest of the sounds in the list are sound effects
        //This sets the volume for the sound effects
        for (int i = 2; i < sounds.Length; i++)
        {
            sounds[i].source.volume = sfxSlider.value;
        }

        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);

    }

    public float GetSFXVolume()
    {
        return sfxSlider.value;
    }


    //Reset the volume settings to a preset default value
    public void Reset()
    {
        sfxSlider.value=0.7f;
        musicSlider.value=0.5f;
        SetMusicVolume();
        SetSFXVolume();
    }
}
