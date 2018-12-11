using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossLevel : MonoBehaviour {

    public double BossHealthPoints = 200;
    public double BossMaxHealthPoints = 200;

    private bool[] BossAttacksNotAllowed = new bool[3];
    float timer = 0.0f;
    int seconds;

    float animTimer;
    int animSeconds;

    // Boss being Attacked
    public int WeakPoint1=0;
    public int WeakPoint2 =0;
    public int WeakPoint3 =0;

    private float remainingDistance;
    private int RandomAttack;

    private bool attack;

    public GameObject BossLevelStartPosition;
    public GameObject Kratos;


    //Sound
    public Sound SoundManager;

    // Use this for initialization
    public void Start ()
    {
        this.gameObject.transform.parent.gameObject.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("BossLevelVol", SoundManager.MusicVolume); //Boss Level

        Kratos.transform.position = BossLevelStartPosition.transform.position;
        this.gameObject.GetComponent<Animator>().SetFloat("Forward", this.gameObject.GetComponent<NavMeshAgent>().remainingDistance);
        this.GetComponents<AudioSource>()[2].outputAudioMixerGroup.audioMixer.SetFloat("EnemyWalkVol", SoundManager.SFXVolume); //Walking
        this.GetComponents<AudioSource>()[3].outputAudioMixerGroup.audioMixer.SetFloat("VoiceOverVol", SoundManager.SpeechVolume); //Voice Over
    }
	
   // Update is called once per frame
   void Update ()
   {

        this.gameObject.GetComponent<Animator>().SetFloat("Forward", this.gameObject.GetComponent<NavMeshAgent>().remainingDistance);
        remainingDistance = this.gameObject.GetComponent<NavMeshAgent>().remainingDistance;

        // 5 Seconds Time
        timer += Time.deltaTime;
        seconds = System.Convert.ToInt32(timer % 60);
        if (seconds == 5)
        {
            timer = 0.0f;
            attack = true;
            Debug.Log("5 seconds passed");
       
            // Choose Attack Randomly
            RandomAttack = (int)Random.Range(0.0f, 3.0f);

            if (WeakPoint1 == 3 && RandomAttack == 0)
                BossAttacksNotAllowed[0] = true;

            else if (WeakPoint2 == 3 && RandomAttack == 1)
                BossAttacksNotAllowed[1] = true;

            else if (WeakPoint3 == 3 && RandomAttack == 2)
                BossAttacksNotAllowed[2] = true;


            switch (RandomAttack)
                {
                    case 0:
                    if (!BossAttacksNotAllowed[0])
                    {
                        this.gameObject.GetComponent<Animator>().SetBool("Head attack", true);
                        this.gameObject.GetComponent<Animator>().SetBool("Hand attack", false);
                        this.gameObject.GetComponent<Animator>().SetBool("Leg attack", false);
                        attack = false;
                    }
                        break;
                    case 1:
                    if (!BossAttacksNotAllowed[1])
                    {
                        this.gameObject.GetComponent<Animator>().SetBool("Head attack", false);
                        this.gameObject.GetComponent<Animator>().SetBool("Hand attack", true);
                        this.gameObject.GetComponent<Animator>().SetBool("Leg attack", false);
                        attack = false;
                    }
                    break;
                    case 2:
                    if (!BossAttacksNotAllowed[2])
                    {
                        this.gameObject.GetComponent<Animator>().SetBool("Head attack", false);
                        this.gameObject.GetComponent<Animator>().SetBool("Hand attack", false);
                        this.gameObject.GetComponent<Animator>().SetBool("Leg attack", true);
                        attack = false;
                    }
                    break;

                    default: break;
                }



            }

        animTimer += Time.deltaTime;
        animSeconds = System.Convert.ToInt32(timer % 60);

        if (animSeconds == 2)
        {
            animSeconds = 0;
            this.gameObject.GetComponent<Animator>().SetBool("Head attack", false);
            this.gameObject.GetComponent<Animator>().SetBool("Hand attack", false);
            this.gameObject.GetComponent<Animator>().SetBool("Leg attack", false);


            Debug.Log("Attack Chosen:" + RandomAttack);
        
        }



    }
}
