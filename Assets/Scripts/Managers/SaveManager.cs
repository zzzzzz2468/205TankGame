using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : Singleton<SaveManager>
{
    //Variables needed to save
    public float musicVol;
    public float fxVol;

    public float numToSave;
    public Text textTemp;

    private void Start()
    {
        //Load();
        if (PlayerPrefs.HasKey("MusicVolume"))
            Load();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("Number To Save", numToSave);
        PlayerPrefs.SetFloat("MusicVolume", musicVol);
        PlayerPrefs.SetFloat("FXVolume", fxVol);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        numToSave = PlayerPrefs.GetFloat("Number To Save");
    }

    private void Update()
    {
        textTemp.text = numToSave.ToString();
    }

    private void OnApplicationQuit()
    {
        Save();
    }
}