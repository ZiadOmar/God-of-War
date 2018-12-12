using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour {

    public KratusControl Kratos;
    public bool instNextEnemy;
    public GameObject Boss;

  

    // Use this for initialization
    void Start () {
        instNextEnemy = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision other)
    {
        //Debug.Log("hit");

        // if Sword hit a Running enemy
        if (other.gameObject.CompareTag("RunningEnemy") && (Kratos.lightAttack || Kratos.heavyAttack))
        {
            //Debug.Log("hittttttttt");
            double enemyHealthPoints = other.gameObject.GetComponent<Enemy>().EnemyHealthPoints;
            if (Kratos.rage)
            {
                enemyHealthPoints -= Kratos.KratosDamagePoints * 2;
                Kratos.rage = false;
            }
            else
            {
                enemyHealthPoints -= Kratos.KratosDamagePoints;
            }

            other.gameObject.GetComponents<AudioSource>()[1].Play(); // Hit Sound
            other.gameObject.GetComponent<Animator>().SetTrigger("Hit Reaction");

            if (enemyHealthPoints <= 0)
            {
                //Destroy(other.gameObject); // Animation Dying
                other.gameObject.GetComponent<Animator>().SetTrigger("Dying");
                other.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().m_MoveSpeedMultiplier = 0;
                other.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = null;
                other.gameObject.GetComponents<AudioSource>()[0].Play(); // Death Sound
                other.gameObject.GetComponents<AudioSource>()[2].enabled = false; //Walking
                other.gameObject.GetComponents<AudioSource>()[3].enabled = false; //Voice Over
                Kratos.XPIncAndCheckForLevelUp();
                Kratos.enemyAttackers++;
                instNextEnemy = true;
            }

            Kratos.KratosRageLevel++;
            other.gameObject.GetComponent<Enemy>().EnemyHealthPoints = enemyHealthPoints;
            Kratos.lightAttack = false;
            Kratos.heavyAttack = false;
        }

        // if Sword hit the fire enemy
        if (other.gameObject.CompareTag("FireEnemy") && (Kratos.lightAttack || Kratos.heavyAttack))
        {
            //Debug.Log("hittttttttt");
            double enemyHealthPoints = other.gameObject.GetComponent<LongRangeEnemy>().EnemyHealthPoints;
            if (Kratos.rage)
            {
                enemyHealthPoints -= Kratos.KratosDamagePoints * 2;
                Kratos.rage = false;
            }
            else
            {
                enemyHealthPoints -= Kratos.KratosDamagePoints;
            }
            other.gameObject.GetComponents<AudioSource>()[1].Play(); // Hit Sound
            other.gameObject.GetComponent<Animator>().SetTrigger("Hit Reaction");

            if (enemyHealthPoints <= 0)
            {
                // Animation Dying
                other.gameObject.GetComponent<Animator>().SetTrigger("Dying");
                other.gameObject.GetComponent<LongRangeEnemy>().FireManDead = true;
                other.gameObject.GetComponents<AudioSource>()[0].Play(); // Death Sound
                other.gameObject.GetComponents<AudioSource>()[2].enabled = false; //Voice Over                Kratos.XPIncAndCheckForLevelUp();
                Kratos.enemyAttackers++;
                instNextEnemy = true;
            }

            Kratos.KratosRageLevel++;
            other.gameObject.GetComponent<LongRangeEnemy>().EnemyHealthPoints = enemyHealthPoints;
            Kratos.lightAttack = false;
            Kratos.heavyAttack = false;
        }

        // if kratos hit the Boss (Not a weak Point)
        if (other.gameObject.CompareTag("Boss") && (Kratos.lightAttack || Kratos.heavyAttack))
        {
            double BossHealthPoints = Boss.GetComponent<BossLevel>().BossHealthPoints;
            double BossMaxHealthPoints = Boss.GetComponent<BossLevel>().BossMaxHealthPoints;
            if (Kratos.rage)
            {
                BossHealthPoints -= (BossMaxHealthPoints * 0.05) * 2;
                Kratos.rage = false;
            }
            else
            {
                BossHealthPoints -= (BossMaxHealthPoints * 0.05);
            }
            Boss.GetComponents<AudioSource>()[1].Play(); // Hit Sound
            Boss.GetComponent<Animator>().SetTrigger("Hit Reaction");

            if (BossHealthPoints <= 0)
            {
                //Destroy(Boss); //Animation Dying
                Boss.GetComponent<Animator>().SetTrigger("Dying");
                Boss.GetComponents<AudioSource>()[0].Play(); // Death Sound
                Boss.GetComponents<AudioSource>()[2].outputAudioMixerGroup.audioMixer.SetFloat("EnemyWalkVol", -80f); //Walking
                Boss.GetComponents<AudioSource>()[3].outputAudioMixerGroup.audioMixer.SetFloat("VoiceOverVol", -80f); //Voice Over
                Boss.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = null;
                //Credits Roll
                Kratos.BossIsDefeated();
            }

            Kratos.KratosRageLevel++;
            Boss.GetComponent<BossLevel>().BossHealthPoints = BossHealthPoints;
            Kratos.lightAttack = false;
            Kratos.heavyAttack = false;

        }

        // if kratos hit the Boss (weak Point 1)
        if (other.gameObject.CompareTag("BossWeakPoint1") && (Kratos.lightAttack || Kratos.heavyAttack))
        {
            int WeakPoint1 = Boss.GetComponent<BossLevel>().WeakPoint1;
            double BossHealthPoints = Boss.GetComponent<BossLevel>().BossHealthPoints;
            double BossMaxHealthPoints = Boss.GetComponent<BossLevel>().BossMaxHealthPoints;
            if (Kratos.rage)
            {
                BossHealthPoints -= ((BossMaxHealthPoints * 0.2) * 2);
                Kratos.rage = false;
            }
            else
            {
                BossHealthPoints -= (BossMaxHealthPoints * 0.2);
            }

            WeakPoint1++;
            if (WeakPoint1 == 3)
            {
                //Destroy(other.gameObject);
                //Stunning
                BossStunned();
            }
            Boss.GetComponents<AudioSource>()[1].Play(); // Hit Sound
            Boss.GetComponent<Animator>().SetTrigger("Hit Reaction");

            if (BossHealthPoints <= 0)
            {
                //Destroy(Boss); //Animation Dying
                Boss.GetComponent<Animator>().SetTrigger("Dying");
                Boss.GetComponents<AudioSource>()[0].Play(); // Death Sound
                Boss.GetComponents<AudioSource>()[2].outputAudioMixerGroup.audioMixer.SetFloat("EnemyWalkVol", -80f); //Walking
                Boss.GetComponents<AudioSource>()[3].outputAudioMixerGroup.audioMixer.SetFloat("VoiceOverVol", -80f); //Voice Over
                Boss.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = null;
                //Credits Roll
                Kratos.BossIsDefeated();
            }

            Kratos.KratosRageLevel++;
            Boss.GetComponent<BossLevel>().BossHealthPoints = BossHealthPoints;
            Boss.GetComponent<BossLevel>().WeakPoint1 = WeakPoint1;
            Kratos.lightAttack = false;
            Kratos.heavyAttack = false;

        }

        // if kratos hit the Boss (weak Point 2)
        if (other.gameObject.CompareTag("BossWeakPoint2") && (Kratos.lightAttack || Kratos.heavyAttack))
        {
            int WeakPoint2 = Boss.GetComponent<BossLevel>().WeakPoint2;
            double BossHealthPoints = Boss.GetComponent<BossLevel>().BossHealthPoints;
            double BossMaxHealthPoints = Boss.GetComponent<BossLevel>().BossMaxHealthPoints;
            if (Kratos.rage)
            {
                BossHealthPoints -= ((BossMaxHealthPoints * 0.2) * 2);
                Kratos.rage = false;
            }
            else
            {
                BossHealthPoints -= (BossMaxHealthPoints * 0.2);
            }

            WeakPoint2++;
            if (WeakPoint2 == 3)
            {
                //Destroy(other.gameObject);
                //Stunning
                BossStunned();
            }

            Boss.GetComponents<AudioSource>()[1].Play(); // Hit Sound
            Boss.GetComponent<Animator>().SetTrigger("Hit Reaction");

            if (BossHealthPoints <= 0)
            {
                //Destroy(Boss); //Animation Dying
                Boss.GetComponent<Animator>().SetTrigger("Dying");
                Boss.GetComponents<AudioSource>()[0].Play(); // Death Sound
                Boss.GetComponents<AudioSource>()[2].outputAudioMixerGroup.audioMixer.SetFloat("EnemyWalkVol", -80f); //Walking
                Boss.GetComponents<AudioSource>()[3].outputAudioMixerGroup.audioMixer.SetFloat("VoiceOverVol", -80f); //Voice Over
                Boss.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = null;
                //Credits Roll
                Kratos.BossIsDefeated();
            }


            Kratos.KratosRageLevel++;
            Boss.GetComponent<BossLevel>().BossHealthPoints = BossHealthPoints;
            Boss.GetComponent<BossLevel>().WeakPoint2 = WeakPoint2;
            Kratos.lightAttack = false;
            Kratos.heavyAttack = false;

        }

        // if kratos hit the Boss (weak Point 3)
        if (other.gameObject.CompareTag("BossWeakPoint3") && (Kratos.lightAttack || Kratos.heavyAttack))
        {
            int WeakPoint3 = Boss.GetComponent<BossLevel>().WeakPoint3;
            double BossHealthPoints = Boss.GetComponent<BossLevel>().BossHealthPoints;
            double BossMaxHealthPoints = Boss.GetComponent<BossLevel>().BossMaxHealthPoints;
            if (Kratos.rage)
            {
                BossHealthPoints -= ((BossMaxHealthPoints * 0.2) * 2);
                Kratos.rage = false;
            }
            else
            {
                BossHealthPoints -= (BossMaxHealthPoints * 0.2);
            }

            WeakPoint3++;
            if (WeakPoint3 == 3)
            {
                //Destroy(other.gameObject);
                //Stunning
                BossStunned();
            }

            Boss.GetComponents<AudioSource>()[1].Play(); // Hit Sound
            Boss.GetComponent<Animator>().SetTrigger("Hit Reaction");

            if (BossHealthPoints <= 0)
            {
                //Destroy(Boss); //Animation Dying
                Boss.GetComponent<Animator>().SetTrigger("Dying");
                Boss.GetComponents<AudioSource>()[0].Play(); // Death Sound
                Boss.GetComponents<AudioSource>()[2].outputAudioMixerGroup.audioMixer.SetFloat("EnemyWalkVol", -80f); //Walking
                Boss.GetComponents<AudioSource>()[3].outputAudioMixerGroup.audioMixer.SetFloat("VoiceOverVol",-80f); //Voice Over
                Boss.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = null;
                //Credits Roll
                Kratos.BossIsDefeated();
            }

            Kratos.KratosRageLevel++;
            Boss.GetComponent<BossLevel>().BossHealthPoints = BossHealthPoints;
            Boss.GetComponent<BossLevel>().WeakPoint3 = WeakPoint3;
            Kratos.lightAttack = false;
            Kratos.heavyAttack = false;
        }
    }

    private void BossStunned()
    {
        Boss.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().m_AnimSpeedMultiplier = 0;
        Boss.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().m_MoveSpeedMultiplier = 0;

        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(5f);
        Boss.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().m_AnimSpeedMultiplier = 1;
        Boss.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().m_MoveSpeedMultiplier = 1;
    }
}
