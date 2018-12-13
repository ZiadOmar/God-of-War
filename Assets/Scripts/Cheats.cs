using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour {

    public KratusControl Kratos;
    public NormalLevel NormalLevel;
    public BossLevel BossLevel;

    public GameObject BossLevelParent;
    int i = 1;
    // Use this for initialization
    void Start () {
        i = 1;
	}

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown(KeyCode.Alpha1)) //Fill Health
        {
            Kratos.KratosHealthPoints = Kratos.MaxHealthPoints;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) //Fill XP
        {
            Kratos.KratosXP = Kratos.KratosMaxLevelXP;
            Kratos.KratosCurrentLevel++;
            Kratos.KratosMaxLevelXP *= 2;
            Kratos.KratosSkillPoints++;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3)) //Add Skill Points
        {
            Kratos.KratosSkillPoints++;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4)) //Fill Rage
        {
            Kratos.KratosRageLevel = 10;
        }

        if (Input.GetKeyDown(KeyCode.F1)) //Finish Obstacle Room 1
        {
            NormalLevel.Wave1Level.SetActive(true);
            NormalLevel.Wave1 = true;
            Kratos.transform.position = NormalLevel.Wave1LevelStartPosition.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.F2)) //Finish Wave1
        {
            foreach (GameObject Enemy in NormalLevel.Wave1Enemies)
            {
                Enemy.SetActive(false);
            }
            NormalLevel.Wave1 = false;
            NormalLevel.WaveRoomsEnd[0].SetActive(false);
            NormalLevel.ObstacleRoom2.SetActive(true);
            Kratos.GetComponent<KratusControl>().enemyAttackers = 0;
            Kratos.transform.position = NormalLevel.ObstacleRoom2StartPosition.transform.position;

            Kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy = true;

            Kratos.GetComponent<Invector.CharacterController.vThirdPersonController>().jumpHeight = 12;
        }



        if (Input.GetKeyDown(KeyCode.F3)) //Finish Obstacle Room 2
        {
            NormalLevel.Wave2Level.SetActive(true);
            NormalLevel.Wave2 = true;
            Kratos.transform.position = NormalLevel.Wave2LevelStartPosition.transform.position;
            Kratos.GetComponent<Invector.CharacterController.vThirdPersonController>().jumpHeight = 5;
        }

        if (Input.GetKeyDown(KeyCode.F4)) //Finish Wave2
        {
            foreach (GameObject Enemy in NormalLevel.Wave2Enemies)
            {
                Enemy.SetActive(false);
            }
            NormalLevel.Wave2 = false;
            NormalLevel.WaveRoomsEnd[1].SetActive(false);
            NormalLevel.ObstacleRoom3.SetActive(true);
            Kratos.GetComponent<KratusControl>().enemyAttackers = 0;
            Kratos.transform.position = NormalLevel.ObstacleRoom3StartPosition.transform.position;

            Kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy = true;
        }


        if (Input.GetKeyDown(KeyCode.F5)) //Finish Obstacle Room 3
        {
            NormalLevel.Wave3Level.SetActive(true);
            NormalLevel.Wave3 = true;
            Kratos.transform.position = NormalLevel.Wave3LevelStartPosition.transform.position;
        }

        if (Input.GetKeyDown(KeyCode.F6)) //Finish Wave3
        {
            foreach (GameObject Enemy in NormalLevel.Wave3Enemies)
            {
                Enemy.SetActive(false);
            }
            NormalLevel.Wave3 = false;
            NormalLevel.WaveRoomsEnd[2].SetActive(false);
            NormalLevel.ObstacleRoom4.SetActive(true);
            Kratos.GetComponent<KratusControl>().enemyAttackers = 0;
            Kratos.transform.position = NormalLevel.ObstacleRoom4StartPosition.transform.position;

            Kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy = true;
        }

        if (Input.GetKeyDown(KeyCode.F7)) //Finish Obstacle Room 4
        {
            BossLevelParent.SetActive(true);
            NormalLevel.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("NormalLevelVol", -80f); //Normal Level
            BossLevelParent.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("BossLevelVol", BossLevel.SoundManager.MusicVolume); //Boss Level
            Kratos.transform.position = BossLevel.BossLevelStartPosition.transform.position;
            NormalLevel.NormalLevelON = false;
            Kratos.GetComponent<Invector.CharacterController.vThirdPersonController>().jumpHeight = 5;
        }

        if (Input.GetKeyDown(KeyCode.F8)) //Kill Running Enemy
        {
            if (NormalLevel.Wave1)
            {
                NormalLevel.Wave1Enemies[Kratos.enemyAttackers].GetComponent<Enemy>().EnemyHealthPoints = 0;
                NormalLevel.Wave1Enemies[Kratos.enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().m_MoveSpeedMultiplier = 0;
                NormalLevel.Wave1Enemies[Kratos.enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = null;
                NormalLevel.Wave1Enemies[Kratos.enemyAttackers].GetComponent<Animator>().SetTrigger("Dying");

                NormalLevel.Wave1Enemies[Kratos.enemyAttackers].GetComponents<AudioSource>()[0].Play(); // Death Sound
                NormalLevel.Wave1Enemies[Kratos.enemyAttackers].GetComponents<AudioSource>()[2].enabled = false; //Walking
                NormalLevel.Wave1Enemies[Kratos.enemyAttackers].GetComponents<AudioSource>()[3].enabled = false; //Voice Over

                Kratos.XPIncAndCheckForLevelUp();
                Kratos.enemyAttackers++;
                Kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy = true;
            }
            else if (NormalLevel.Wave2)
            {
                NormalLevel.Wave2Enemies[Kratos.enemyAttackers].GetComponent<Enemy>().EnemyHealthPoints = 0;
                NormalLevel.Wave2Enemies[Kratos.enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().m_MoveSpeedMultiplier = 0;
                NormalLevel.Wave2Enemies[Kratos.enemyAttackers].GetComponent<Animator>().SetTrigger("Dying");
                NormalLevel.Wave2Enemies[Kratos.enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = null;
                NormalLevel.Wave2Enemies[Kratos.enemyAttackers].GetComponents<AudioSource>()[0].Play(); // Death Sound
                NormalLevel.Wave2Enemies[Kratos.enemyAttackers].GetComponents<AudioSource>()[2].enabled = false; //Walking
                NormalLevel.Wave2Enemies[Kratos.enemyAttackers].GetComponents<AudioSource>()[3].enabled = false; //Voice Over

                Kratos.XPIncAndCheckForLevelUp();
                Kratos.enemyAttackers++;
                Kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy = true;
            }

            else if (NormalLevel.Wave3)
            {
                NormalLevel.Wave3Enemies[Kratos.enemyAttackers].GetComponent<Enemy>().EnemyHealthPoints = 0;
                NormalLevel.Wave3Enemies[Kratos.enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().m_MoveSpeedMultiplier = 0;
                NormalLevel.Wave3Enemies[Kratos.enemyAttackers].GetComponent<Animator>().SetTrigger("Dying");
                NormalLevel.Wave3Enemies[Kratos.enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = null;
                NormalLevel.Wave3Enemies[Kratos.enemyAttackers].GetComponents<AudioSource>()[0].Play(); // Death Sound
                NormalLevel.Wave3Enemies[Kratos.enemyAttackers].GetComponents<AudioSource>()[2].enabled = false; //Walking
                NormalLevel.Wave3Enemies[Kratos.enemyAttackers].GetComponents<AudioSource>()[3].enabled = false; //Voice Over

                Kratos.XPIncAndCheckForLevelUp();
                Kratos.enemyAttackers++;
                Kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy = true;
            }
        }


        if (Input.GetKeyDown(KeyCode.F9)) //Kill Fire Enemy
        {
            if (NormalLevel.Wave1)
            {
                NormalLevel.Wave1Enemies[Kratos.enemyAttackers].GetComponent<LongRangeEnemy>().EnemyHealthPoints = 0;
                NormalLevel.Wave1Enemies[Kratos.enemyAttackers].GetComponent<Animator>().SetTrigger("Dying");
                NormalLevel.Wave1Enemies[Kratos.enemyAttackers].GetComponent<LongRangeEnemy>().FireManDead = true;
                NormalLevel.Wave1Enemies[Kratos.enemyAttackers].GetComponents<AudioSource>()[0].Play(); // Death Sound
                NormalLevel.Wave1Enemies[Kratos.enemyAttackers].GetComponents<AudioSource>()[2].enabled = false; //Voice Over

                Kratos.XPIncAndCheckForLevelUp();
                Kratos.enemyAttackers++;
                Kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy = true;
            }
            else if (NormalLevel.Wave2)
            {
                NormalLevel.Wave2Enemies[Kratos.enemyAttackers].GetComponent<LongRangeEnemy>().EnemyHealthPoints = 0;
                NormalLevel.Wave2Enemies[Kratos.enemyAttackers].GetComponent<Animator>().SetTrigger("Dying");
                NormalLevel.Wave2Enemies[Kratos.enemyAttackers].GetComponent<LongRangeEnemy>().FireManDead = true;
                NormalLevel.Wave2Enemies[Kratos.enemyAttackers].GetComponents<AudioSource>()[0].Play(); // Death Sound
                NormalLevel.Wave2Enemies[Kratos.enemyAttackers].GetComponents<AudioSource>()[2].enabled = false; //Voice Over

                Kratos.XPIncAndCheckForLevelUp();
                Kratos.enemyAttackers++;
                Kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy = true;
            }

            else if (NormalLevel.Wave3)
            {
                NormalLevel.Wave3Enemies[Kratos.enemyAttackers].GetComponent<LongRangeEnemy>().EnemyHealthPoints = 0;
                NormalLevel.Wave3Enemies[Kratos.enemyAttackers].GetComponent<Animator>().SetTrigger("Dying");
                NormalLevel.Wave3Enemies[Kratos.enemyAttackers].GetComponent<LongRangeEnemy>().FireManDead = true;
                NormalLevel.Wave3Enemies[Kratos.enemyAttackers].GetComponents<AudioSource>()[0].Play(); // Death Sound
                NormalLevel.Wave3Enemies[Kratos.enemyAttackers].GetComponents<AudioSource>()[2].enabled = false; //Voice Over

                Kratos.XPIncAndCheckForLevelUp();
                Kratos.enemyAttackers++;
                Kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.F10)) //Finish Normal Level
        {
            foreach (GameObject Enemy in NormalLevel.Wave1Enemies)
            {
                Enemy.SetActive(false);
            }

            foreach (GameObject Enemy in NormalLevel.Wave2Enemies)
            {
                Enemy.SetActive(false);
            }

            foreach (GameObject Enemy in NormalLevel.Wave3Enemies)
            {
                Enemy.SetActive(false);
            }
            NormalLevel.Wave1 = false;
            NormalLevel.Wave2 = false;
            NormalLevel.Wave3 = false;
            NormalLevel.WaveRoomsEnd[0].SetActive(false);
            NormalLevel.WaveRoomsEnd[1].SetActive(false);
            NormalLevel.WaveRoomsEnd[2].SetActive(false);

            NormalLevel.ObstacleRoom1.SetActive(true);
            NormalLevel.ObstacleRoom2.SetActive(true);
            NormalLevel.ObstacleRoom3.SetActive(true);
            NormalLevel.ObstacleRoom4.SetActive(true);

            Kratos.GetComponent<KratusControl>().enemyAttackers = 0;
            NormalLevel.NormalLevelON = false;
            BossLevelParent.SetActive(true);
            NormalLevel.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("NormalLevelVol", -80f); //Normal Level
            BossLevelParent.GetComponent<AudioSource>().outputAudioMixerGroup.audioMixer.SetFloat("BossLevelVol", BossLevel.SoundManager.MusicVolume); //Boss Level
            Kratos.transform.position = BossLevel.BossLevelStartPosition.transform.position;
            Kratos.GetComponent<Invector.CharacterController.vThirdPersonController>().jumpHeight = 5;
        }

            if (Input.GetKeyDown(KeyCode.F11)) //Kill Boss Components
        {
            if (BossLevel.WeakPoint1 != 3 && i==1)
            {
                BossLevel.WeakPoint1 = 3;
                BossLevel.HeadAttack.GetComponent<BoxCollider>().enabled = false;
                Kratos.GetComponentInChildren<WeaponAttack>().BossStunned();
                i++;
            }

            else if (BossLevel.WeakPoint2 != 3 && i == 2)
            {
                BossLevel.WeakPoint2 = 3;
                BossLevel.HandAttack.GetComponent<BoxCollider>().enabled = false;
                Kratos.GetComponentInChildren<WeaponAttack>().BossStunned();
                i++;
            }

            else if (BossLevel.WeakPoint3 != 3 && i == 3)
            {
                BossLevel.WeakPoint3 = 3;
                BossLevel.LegAttack.GetComponent<BoxCollider>().enabled = false;
                Kratos.GetComponentInChildren<WeaponAttack>().BossStunned();
                i++;
            }
        }

        if (Input.GetKeyDown(KeyCode.F12)) //Kill Boss
        {
            BossLevel.BossHealthPoints = 0;
            BossLevel.gameObject.GetComponent<Animator>().SetTrigger("Dying");
            BossLevel.gameObject.GetComponents<AudioSource>()[0].Play(); // Death Sound
            BossLevel.gameObject.GetComponents<AudioSource>()[2].outputAudioMixerGroup.audioMixer.SetFloat("EnemyWalkVol", -80f); //Walking
            BossLevel.gameObject.GetComponents<AudioSource>()[3].outputAudioMixerGroup.audioMixer.SetFloat("VoiceOverVol", -80f); //Voice Over
            BossLevel.gameObject.GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = null;
            //Credits Roll
            Kratos.BossIsDefeated();
        }
    }
}
