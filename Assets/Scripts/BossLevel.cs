using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossLevel : MonoBehaviour {

    public ProgressBar HealthPb;
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

    public GameObject HeadAttack;
    public GameObject LegAttack;
    public GameObject HandAttack;

    public GameObject HeadHelmet;
    public GameObject LegShield;
    public GameObject HandShield;

    public GameObject fire;
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

        this.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().m_AnimSpeedMultiplier = 1;
        this.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().m_MoveSpeedMultiplier = 1;
        this.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = Kratos.transform;

        HeadAttack.GetComponent<BoxCollider>().enabled = true;
        HandAttack.GetComponent<BoxCollider>().enabled = true;
        LegAttack.GetComponent<BoxCollider>().enabled = false;

        HeadHelmet.SetActive(true);
        LegShield.SetActive(true);
        HandShield.SetActive(true);

        BossHealthPoints = 200;
        BossMaxHealthPoints = 200;

        BossAttacksNotAllowed = new bool[3];
        timer = 0.0f;
    
         WeakPoint1 = 0;
         WeakPoint2 = 0;
         WeakPoint3 = 0;

        fire.transform.position = new Vector3(this.transform.position.x, -26.61f, this.transform.position.z + 2f);
        fire.GetComponent<ParticleSystem>().Play();
    }
	
   // Update is called once per frame
   void Update ()
   {
        HealthPb.Title = "Boss Health: ";
        HealthPb.BarValue = (int)BossHealthPoints;
        HealthPb.MaxValue = (int)BossMaxHealthPoints;

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
            {
                BossAttacksNotAllowed[0] = true;
                HeadAttack.GetComponent<BoxCollider>().enabled = false;
                HeadHelmet.SetActive(false);
            }

            else if (WeakPoint2 == 3 && RandomAttack == 1)
            {
                BossAttacksNotAllowed[1] = true;
                HandAttack.GetComponent<BoxCollider>().enabled = false;
                HandShield.SetActive(false);

            }
            else if (WeakPoint3 == 3 && RandomAttack == 2)
            {
               BossAttacksNotAllowed[2] = true;
               LegAttack.GetComponent<BoxCollider>().enabled = false;
               LegShield.SetActive(false);
            }

            switch (RandomAttack)
                {
                    case 0:
                    if (!BossAttacksNotAllowed[0])
                    {
                        HeadAttack.GetComponent<BoxCollider>().enabled = true;
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
                        HandAttack.GetComponent<BoxCollider>().enabled = true;
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
                        if (remainingDistance < 2)
                            LegAttack.GetComponent<BoxCollider>().enabled = true;
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

            //HeadAttack.GetComponent<BoxCollider>().enabled = false;
            //HandAttack.GetComponent<BoxCollider>().enabled = false;
            LegAttack.GetComponent<BoxCollider>().enabled = false;

            Debug.Log("Attack Chosen:" + RandomAttack);
        
        }



    }
}
