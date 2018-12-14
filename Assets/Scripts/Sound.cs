using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour {

    public float SFXVolume;
    public float MusicVolume;
    public float SpeechVolume;

    public void SetSFXVolume(float volume)
    {
        SFXVolume = volume;
    }
    public void SetMusicVolume(float volume)
    {
        MusicVolume = volume;
    }
    public void SetSpeechVolume(float volume)
    {
        SpeechVolume = volume;
    }
}
