using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : Singleton<SaveManager>
{
    //Variables needed to save
    public float musicVol;
    public float fxVol;

    //sliders for sound
    public Slider music;
    public Slider fx;

    //checks if stats exists and loads them
    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume") && PlayerPrefs.HasKey("FXVolume"))
        {
            Load();
            music.value = musicVol;
            fx.value = fxVol;
        }
    }

    //saves the volume stats
    public void Save()
    {
        musicVol = music.value;
        fxVol = fx.value;

        PlayerPrefs.SetFloat("MusicVolume", musicVol);
        PlayerPrefs.SetFloat("FXVolume", fxVol);
        PlayerPrefs.Save();
    }

    //loads the volume stats
    public void Load()
    {
        fxVol = PlayerPrefs.GetFloat("FXVolume");
        musicVol = PlayerPrefs.GetFloat("MusicVolume");
    }

    //saves on close
    private void OnApplicationQuit()
    {
        Save();
    }
}