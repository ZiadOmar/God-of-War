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
    public bool lightAttack = false;
    public bool heavyAttack = false;

    public bool rage = false;
    public bool blocking = false;


    public bool GameScreenOn;

    //Normal Level
    public int enemyAttackers =0;

    //Boss Level
    public GameObject Boss;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("V= " + this.GetComponent<Rigidbody>().velocity);
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

    
    }

    //Enemy Killed  >>>>   XPIncAndCheckForLevelUp();

    void XPIncAndCheckForLevelUp()
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
    private void OnCollisionStay(Collision other)
    {   
        // if kratos hit an enemy
        if (other.gameObject.CompareTag("Enemy") && (lightAttack || heavyAttack))
        {
            double enemyHealthPoints = other.gameObject.GetComponent<Enemy>().EnemyHealthPoints;
            if (rage)
            {
                enemyHealthPoints -= KratosDamagePoints*2;
                rage = false;
            }
            else
            {
                enemyHealthPoints -= KratosDamagePoints;
            }


            if (enemyHealthPoints <= 0)
            {
                Destroy(other.gameObject); // Animation Dying
                XPIncAndCheckForLevelUp();
                enemyAttackers++;
            }
            
            KratosRageLevel++;
            other.gameObject.GetComponent<Enemy>().EnemyHealthPoints = enemyHealthPoints;
            lightAttack = false;
            heavyAttack = false;

        }

        // if kratos hit the Boss (Not a weak Point)
        if (other.gameObject.CompareTag("Boss") && (lightAttack || heavyAttack))
        {
            double BossHealthPoints = Boss.GetComponent<BossLevel>().BossHealthPoints;
            if (rage)
            {
                BossHealthPoints -= (BossHealthPoints * 0.05)*2;
                rage = false;
            }
            else
            {
                BossHealthPoints -= (BossHealthPoints * 0.05);
            }


            if (BossHealthPoints <= 0)
            {
                Destroy(Boss); //Animation Dying
                //Credits Roll
            }

            KratosRageLevel++;
            Boss.GetComponent<BossLevel>().BossHealthPoints = BossHealthPoints;
            lightAttack = false;
            heavyAttack = false;

        }

        // if kratos hit the Boss (weak Point 1)
        if (other.gameObject.CompareTag("BossWeakPoint1") && (lightAttack || heavyAttack))
        {
            int WeakPoint1 = Boss.GetComponent<BossLevel>().WeakPoint1; 
            double BossHealthPoints = Boss.GetComponent<BossLevel>().BossHealthPoints;
            if (rage)
            {
                BossHealthPoints -= ((BossHealthPoints * 0.2) * 2);
                rage = false;
            }
            else
            {
                BossHealthPoints -= (BossHealthPoints * 0.2);
            }

            WeakPoint1++;
            if (WeakPoint1 == 3)
            {
                Destroy(other.gameObject);
                // Stunning
            }

            if (BossHealthPoints <= 0)
            {
                Destroy(Boss); //Animation Dying
                //Credits Roll
            }

            KratosRageLevel++;
            other.gameObject.GetComponent<BossLevel>().BossHealthPoints = BossHealthPoints;
            lightAttack = false;
            heavyAttack = false;

        }

        // if kratos hit the Boss (weak Point 2)
        if (other.gameObject.CompareTag("BossWeakPoint2") && (lightAttack || heavyAttack))
        {
            int WeakPoint2 = Boss.GetComponent<BossLevel>().WeakPoint2;
            double BossHealthPoints = Boss.GetComponent<BossLevel>().BossHealthPoints;
            if (rage)
            {
                BossHealthPoints -= ((BossHealthPoints * 0.2) * 2);
                rage = false;
            }
            else
            {
                BossHealthPoints -= (BossHealthPoints * 0.2);
            }

            WeakPoint2++;
            if (WeakPoint2 == 3)
            {
                Destroy(other.gameObject);
                // Stunning
            }

            if (BossHealthPoints <= 0)
            {
                Destroy(Boss); //Animation Dying
                //Credits Roll
            }

            KratosRageLevel++;
            Boss.GetComponent<BossLevel>().BossHealthPoints = BossHealthPoints;
            lightAttack = false;
            heavyAttack = false;

        }

        // if kratos hit the Boss (weak Point 3)
        if (other.gameObject.CompareTag("BossWeakPoint3") && (lightAttack || heavyAttack))
        {
            int WeakPoint3 = Boss.GetComponent<BossLevel>().WeakPoint3;
            double BossHealthPoints = Boss.GetComponent<BossLevel>().BossHealthPoints;
            if (rage)
            {
                BossHealthPoints -= ((BossHealthPoints * 0.2) * 2);
                rage = false;
            }
            else
            {
                BossHealthPoints -= (BossHealthPoints * 0.2);
            }

            WeakPoint3++;
            if (WeakPoint3 == 3)
            {
                Destroy(other.gameObject);
                // Remove this attack
                // Stunning
            }

            if (BossHealthPoints <= 0)
            {
                Destroy(Boss); //Animation Dying
                //Credits Roll
            }

            KratosRageLevel++;
            Boss.GetComponent<BossLevel>().BossHealthPoints = BossHealthPoints;
            lightAttack = false;
            heavyAttack = false;
        }
    }

    private void LightAttackActivated()
    {
        lightAttack = true;
        Debug.Log("lightAttack");
        KratosDamagePoints = KratosLightAttackDamage;      
    }

    private void HeavyAttackActivated()
    {
        heavyAttack = true;
        Debug.Log("heavyAttack");
        KratosDamagePoints = KratosHeavyAttackDamage;
    }

    private void RageActivated()
    {
        rage = true;
        Debug.Log("Rageeeee");
        KratosRageLevel = 0;
    }

    private void BlockingActivated()  // ##########
    {
        blocking = true;
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

    //IEnumerator WaitAWhile()
    //{
    //    yield return new WaitForSecondsRealtime(2f);
    //    Door.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("MasterVol", -80f);
    //    Door.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("DoorVol", -80f);
    //}








}



