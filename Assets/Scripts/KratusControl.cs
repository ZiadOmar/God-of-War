using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KratusControl : MonoBehaviour {

    //Kratus Info
    public double KratosHealthPoints = 100;
    public double MaxHealthPoints = 100;
    public int KratosRageLevel = 0;
    public int KratosCurrentLevel = 1; 
    public int KratosXP=0;
    public int KratosSkillPoints=0;

    public double KratosDamagePoints = 0;
    double KratosLightAttackDamage =10;
    double KratosHeavyAttackDamage = 30;

    //Attacks
    public Avatar DefaultAvatar;
    public Avatar HitReactionAvatar;

    public bool lightAttack = false;
    public Avatar LightAttackAvatar;

    public bool heavyAttack = false;
    public Avatar HeavyAttackAvatar;

    public bool rage = false;
    public Avatar RageAvatar;

    public bool blocking = false;
    public Avatar BlockingAvatar;

    // GameScreen
    public bool GameScreenOn;

    //Weapons
    public GameObject Axe;
    public GameObject Sword;

    //Normal Level
    public GameObject NormalLevel;
    public int enemyAttackers = 0;

    //Boss Level
    public GameObject BossLevel;
    public GameObject Boss;
    public bool BossDefeated;

    public bool GameOver;
    public Avatar DyingAvatar;

    // Use this for initialization
    void Start()
    {
        Sword.SetActive(true);
        Axe.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (GameScreenOn)
        {
        if (Input.GetMouseButtonDown(0))
            LightAttackActivated();

        if (Input.GetMouseButtonDown(1))
            HeavyAttackActivated();

        if (Input.GetKeyDown(KeyCode.R) && KratosRageLevel == 10)
            RageActivated();

        if (Input.GetKey(KeyCode.LeftControl))
            BlockingActivated();
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            blocking = false;
            if (!blocking)
                StartCoroutine("WaitAWhile");
        }

    
 }

    //Enemy Killed  >>>>   XPIncAndCheckForLevelUp();

    public void XPIncAndCheckForLevelUp()
    {
        KratosXP += 50;

        int KratosLevel = KratosCurrentLevel;

        if (KratosXP >= 500 && KratosXP < 1000)
            KratosCurrentLevel = 2;
        else if (KratosXP >= 1000 && KratosXP < 2000)
            KratosCurrentLevel = 3;
        else if (KratosXP >= 2000 && KratosXP < 4000)
            KratosCurrentLevel = 4;
        else if (KratosXP >= 4000 && KratosXP < 8000)
            KratosCurrentLevel = 5;
        else if (KratosXP >= 8000 && KratosXP < 16000)
            KratosCurrentLevel = 6;


        if (KratosLevel != KratosCurrentLevel)
            KratosSkillPoints++;
    }

    private void OnTriggerEnter(Collider other)
    {   
        //Health Chest
        if (other.gameObject.CompareTag("HealthChest"))
        {
            KratosHealthPoints = MaxHealthPoints;
        }
    }


    private void LightAttackActivated()
    {
        lightAttack = true;
        Sword.SetActive(true);
        Axe.SetActive(false);
        this.GetComponent<Animator>().avatar = LightAttackAvatar;
        this.GetComponent<Animator>().CrossFadeInFixedTime("LightAttack", 0.05f);

        Debug.Log("lightAttack");
        KratosDamagePoints = KratosLightAttackDamage;

        StartCoroutine("WaitAWhile");
    }

    private void HeavyAttackActivated()
    {
        heavyAttack = true;
        Sword.SetActive(false);
        Axe.SetActive(true);
        this.GetComponent<Animator>().avatar = HeavyAttackAvatar;
        this.GetComponent<Animator>().CrossFadeInFixedTime("HeavyAttack", 0.05f);
  
        Debug.Log("heavyAttack");
        KratosDamagePoints = KratosHeavyAttackDamage;

        StartCoroutine("WaitAWhile");
    }

    private void RageActivated()
    {
        rage = true;
        this.GetComponent<Animator>().avatar = RageAvatar;
        this.GetComponent<Animator>().CrossFadeInFixedTime("Rage", 0.05f);

        Debug.Log("Rageeeee");
        KratosRageLevel = 0;

        StartCoroutine("WaitAWhile");
    }

    private void BlockingActivated() 
    {
        blocking = true;
        //Sword.SetActive(false);
        //Axe.SetActive(false);
        this.GetComponent<Animator>().avatar = BlockingAvatar;
        this.GetComponent<Animator>().CrossFadeInFixedTime("Blocking", 0.05f);

        Debug.Log("blocking");
       
    }


    public void UpgradeAttack()
    {
        if(KratosSkillPoints != 0)
        {
            KratosSkillPoints--;
            KratosLightAttackDamage += (KratosLightAttackDamage * 0.1);
            KratosHeavyAttackDamage += (KratosHeavyAttackDamage * 0.1);
        }

        Debug.Log("KratosLightAttackDamage: " + KratosLightAttackDamage);
        Debug.Log("KratosHeavyAttackDamage: " + KratosHeavyAttackDamage);

    }

    public void UpgradeHealth()
    {
        if (KratosSkillPoints != 0)
        {
            KratosSkillPoints--;
            KratosHealthPoints += (KratosHealthPoints * 0.1);
            MaxHealthPoints += (MaxHealthPoints * 0.1);
        }

    }
     
    public void UpgradeMovement() // ##########
    {
        if (KratosSkillPoints != 0)
        {
            KratosSkillPoints--;
            //this.GetComponent<Invector.CharacterController.vThirdPersonMotor>().speed *= 10;
            // Invector speed inc #######
            //this.GetComponent<Rigidbody>().velocity *= 2;
     
        }  

    }

    //void DoorOpen()
    //{
    //    Door.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MasterVol", 20f);
    //    Door.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("DoorVol", -20f);
    //    Door.GetComponent<AudioSource>().Play();
    //    StartCoroutine("WaitAWhile");
    //}
    public void ReturnToDefaultAvatar()
    {
        StartCoroutine("WaitAWhile");
    }

    IEnumerator WaitAWhile()
    {
        yield return new WaitForSecondsRealtime(2f);
        this.GetComponent<Animator>().avatar = DefaultAvatar;
        lightAttack = false;
        heavyAttack = false;
    }








}



