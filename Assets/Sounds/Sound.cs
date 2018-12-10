using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour {
    
    public AudioMixer audioMixer;
    //Kratos
    //public AudioSource collect;
    //public AudioSource KHit;
    //public AudioSource KDeath;
    //public AudioSource Rage;
    //public AudioSource KWalking;
    //Enemy
    //public AudioSource EWalking;
    //public AudioSource EDeath;
    //public AudioSource EHit;
    //public AudioSource VoiceOver;
    //Menu and pause
    public AudioSource Menu;
    //Normal level
    public AudioSource NL;
    //Boss level
    public AudioSource BL;


    public AudioSource kratos;
    public AudioSource enemy;
    public AudioSource boss;

 

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("WalkingVol",volume);  
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MenuVol", volume);
    }
    public void SetSpeechVolume(float volume)
    {
        audioMixer.SetFloat("VoiceOverVol", volume);
    }


    void sth()
    {
        
// DOL BTOO3 KRATOS

        //when 3and healthchest 
        //kratos.GetComponents<AudioSource>()[0].Play();

        //when HIT
        //kratos.GetComponents<AudioSource>()[2].Play();

        //when Walking
        //kratos.GetComponents<AudioSource>()[4].Play();

        //when Death
        //kratos.GetComponents<AudioSource>()[1].Play();

        //when Rage
        //kratos.GetComponents<AudioSource>()[3].Play();


// DOL BTOO3 ENEMY AND BOSS

        //when walking 
        enemy.GetComponents<AudioSource>()[3].Play();

        //when Death
        enemy.GetComponents<AudioSource>()[1].Play();

        //when Hit 
        enemy.GetComponents<AudioSource>()[2].Play();

        //when VoiceOver
        enemy.GetComponents<AudioSource>()[0].Play();

        // lma enemy ymoot
        enemy.GetComponents<AudioSource>()[0].Stop();


        //when walking 
        boss.GetComponents<AudioSource>()[2].Play();

        //when Death
        boss.GetComponents<AudioSource>()[0].Play();

        //when Hit 
        boss.GetComponents<AudioSource>()[1].Play();

        //when VoiceOver
        boss.GetComponents<AudioSource>()[3].Play();

        // lma enemy ymoot
        boss.GetComponents<AudioSource>()[3].Stop();


// MENU AND PAUSE
        Menu = GetComponent<AudioSource>();
        NL = GetComponent<AudioSource>();

        Menu.Play();
        //when clicking start 
        Menu.Stop();
        NL.Play();

// IF in Normal Level
        //when pause
        Menu.Play();
        NL.Pause();

        //when Resume
        NL.Play();
        Menu.Stop();


// From Normal to Boss level

        NL.Stop();
        BL.Play();



// IF in Boss Level

        //when pause
        Menu.Play();
        BL.Pause();

        //when Resume
        BL.Play();
        Menu.Stop();



    }


}
