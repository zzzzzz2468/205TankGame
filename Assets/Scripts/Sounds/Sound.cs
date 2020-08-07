using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    //The audio mixer
    public AudioMixer masterMixer;

    //Sound FX levels
    public void SetSFXLevel(float sfxLvl)
    {
        masterMixer.SetFloat("sfxVol", sfxLvl);
    }

    //Music levels
    public void SetMusicLevel(float musicLvl)
    {
        masterMixer.SetFloat("musicVol", musicLvl);
    }
}