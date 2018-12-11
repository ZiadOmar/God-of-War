using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public double EnemyHealthPoints = 50;
    bool FightDone;
    bool Attack;
    public string type;
    int i = 0;

    //Sound
    public Sound SoundManager;

    // Use this for initialization
    void Start () {
        this.GetComponents<AudioSource>()[2].outputAudioMixerGroup.audioMixer.SetFloat("EnemyWalkVol", SoundManager.SFXVolume); //Walking
        this.GetComponents<AudioSource>()[3].outputAudioMixerGroup.audioMixer.SetFloat("VoiceOverVol", SoundManager.SpeechVolume); //Voice Over

    }

    // Update is called once per frame
    void Update()
    {
        if (type == "close_range")
            this.gameObject.GetComponent<Animator>().SetFloat("Forward", this.gameObject.GetComponent<NavMeshAgent>().remainingDistance);
   
    }
    private void OnCollisionStay(Collision other)
    {
        // if enemy hand hit Kratos
        if (other.gameObject.CompareTag("Player"))
        {
            if(i ==0)
                Debug.Log("remaining distane" + this.gameObject.GetComponent<NavMeshAgent>().remainingDistance);

            if (i % 250 == 0)
            {
                double KratosHealthPoints = other.gameObject.GetComponent<KratusControl>().KratosHealthPoints;
                if (type == "close_range")
                    this.gameObject.GetComponent<Animator>().SetTrigger("attack");
                
                print("attack");
      
                if (!FightDone && !other.gameObject.GetComponent<KratusControl>().blocking)
                {
                    KratosHealthPoints -= 10;
                    other.gameObject.GetComponent<Animator>().avatar = other.gameObject.GetComponent<KratusControl>().HitReactionAvatar;
                    other.gameObject.GetComponent<Animator>().CrossFadeInFixedTime("Hit Reaction", 0.05f);
                    other.gameObject.GetComponents<AudioSource>()[2].Play();
                    other.gameObject.GetComponent<KratusControl>().ReturnToDefaultAvatar();
                }
                if (KratosHealthPoints <= 0)
                {
                    //GameOver
                    other.gameObject.GetComponent<KratusControl>().GameOver = true;
                    other.gameObject.GetComponent<Animator>().avatar = other.gameObject.GetComponent<KratusControl>().DyingAvatar;
                    other.gameObject.GetComponent<Animator>().CrossFadeInFixedTime("Dying", 0.05f);
                    other.gameObject.GetComponents<AudioSource>()[4].outputAudioMixerGroup.audioMixer.SetFloat("WalkingVOl", -80f); //Walking
                    other.gameObject.GetComponents<AudioSource>()[1].Play();
                    FightDone = true;
                }

                other.gameObject.GetComponent<KratusControl>().KratosHealthPoints = KratosHealthPoints;
            }
            i++;
        } 
    }
}
