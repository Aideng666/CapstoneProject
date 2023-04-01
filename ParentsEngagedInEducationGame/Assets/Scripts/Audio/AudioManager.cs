using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    //[SerializeField] Toggle muteToggle;

    //float musicSlider;
    //float sfxSlider;

    float[] savedVolumes;
    public static AudioManager Instance { get; set; }

    //public static AudioManager _instance;

    //public static AudioManager Instance {
    //    get
    //    {
    //        if (_instance = null)
    //        {
    //            _instance = GameObject.FindObjectOfType<AudioManager>();

    //            DontDestroyOnLoad(_instance.gameObject);
    //        }
    //        return _instance; 
    //    }        
    // }

    // Start is called before the first frame update
    void Awake()
    {
        //Manage the singleton
        
        /*if (_instance == null)
        //{
        //    _instance = this;
        //    DontDestroyOnLoad(this);
        //}
        //else
        //{
        //    if (this != _instance)
        //        Destroy(this.gameObject);
        //}
        */

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

        //if (PlayerPrefs.GetFloat("MusicVolume") == 0)
        //{
        //    musicSlider.value = 0.5f;
        //}

        //if (PlayerPrefs.GetFloat("SFXVolume") == 0)
        //{
        //    sfxSlider.value = 0.7f;
        //}

        //if (PlayerPrefs.GetInt("Mute") == 0)
        //{
        //    muteToggle.isOn = false;
        //}
        //else
        //{
        //    muteToggle.isOn = true;
        //}

        savedVolumes = new float[sounds.Length];
        musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
        sfxSlider.onValueChanged.AddListener(delegate { SetSFXVolume(); });
        //muteToggle.onValueChanged.AddListener(delegate { ToggleMute(); });
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
        for (int i = 2; i < sounds.Length; i++)
        {
            sounds[i].source.volume = sfxSlider.value;
        }

        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);

       
        //dirtyTen   = true;

    }

    public float GetSFXVolume()
    {
        return sfxSlider.value;
    }

    //public void ToggleMute()
    //{

    //    //dirtyTen = true;

    //    if (muteToggle.isOn)
    //    {
    //        for (int i = 0; i < sounds.Length; i++)
    //        {
    //            savedVolumes[i] = sounds[i].source.volume;
    //            sounds[i].source.mute = true;
    //        }

    //        PlayerPrefs.SetInt("Mute", 1);
    //    }
    //    else
    //    {
    //        for (int i = 0; i < sounds.Length; i++)
    //        {
    //            sounds[i].source.mute = false; //savedVolumes[i];
    //        }

    //        PlayerPrefs.SetInt("Mute", 0);
    //    }
    //}

    //public bool isMute()
    //{
    //    return muteToggle.isOn;
    //}

    public void Reset()
    {
        sfxSlider.value=0.7f;
        musicSlider.value=0.5f;
        SetMusicVolume();
        SetSFXVolume();
    }
}
