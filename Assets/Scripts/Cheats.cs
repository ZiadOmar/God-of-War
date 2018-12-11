using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour {

    public KratusControl Kratos;
    public NormalLevel NormalLevel;
    public BossLevel BossLevel;

    public GameObject BossLevelParent;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


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
        }



        if (Input.GetKeyDown(KeyCode.F3)) //Finish Obstacle Room 2
        {
            NormalLevel.Wave2Level.SetActive(true);
            NormalLevel.Wave2 = true;
            Kratos.transform.position = NormalLevel.Wave2LevelStartPosition.transform.position;
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
        }

        //if (Input.GetKeyDown(KeyCode.F3)) //Kill Enemy
        //    Kratos.XPIncAndCheckForLevelUp();


    }
}
