using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalLevel : MonoBehaviour {

    public GameObject kratos;

    // Waves
    public GameObject Wave1Level;
    public GameObject Wave2Level;
    public GameObject Wave3Level;
    public bool Wave1;
    public bool Wave2;
    public bool Wave3;
    public GameObject[] Wave1Enemies = new GameObject[4];
    public GameObject[] Wave2Enemies = new GameObject[4];
    public GameObject[] Wave3Enemies = new GameObject[4];


    //Obstacle Rooms
    public GameObject ObstacleRoom1;
    public GameObject ObstacleRoom2;
    public GameObject ObstacleRoom3;
    public GameObject ObstacleRoom4;

    public GameObject ObstacleRoom1StartPosition;
    public GameObject[] WaveRoomsEnd = new GameObject[3];

    // Use this for initialization
    public void Start () {

        ObstacleRoom1.SetActive(true);
        kratos.transform.position = ObstacleRoom1StartPosition.transform.position;

        ObstacleRoom2.SetActive(false);
        ObstacleRoom3.SetActive(false);
        ObstacleRoom4.SetActive(false);

        Wave1Level.SetActive(false);
        Wave2Level.SetActive(false);
        Wave3Level.SetActive(false);
        Wave1 = false;
        Wave2 = false;
        Wave3 = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (kratos.GetComponent<KratusControl>().enemyAttackers < 4)
        {
            if (Wave1)
                Wave1Room();

            else if (Wave2)
                Wave2Room();

            else if (Wave3)
                Wave3Room();

        }


        if (kratos.GetComponent<KratusControl>().enemyAttackers == 5)
        {
            if (Wave1)
            {
                Wave1 = false;
                //Wave1Level.SetActive(false);
                WaveRoomsEnd[0].SetActive(false);
                ObstacleRoom2.SetActive(true);
                kratos.GetComponent<KratusControl>().enemyAttackers = 0;
            }

            else if (Wave2)
            {
                Wave2 = false;
                //Wave2Level.SetActive(false);
                WaveRoomsEnd[1].SetActive(false);
                ObstacleRoom3.SetActive(true);
                kratos.GetComponent<KratusControl>().enemyAttackers = 0;
            }

            else if (Wave3)
            {
                Wave3 = false;
                // Wave3Level.SetActive(false);
                WaveRoomsEnd[2].SetActive(false);
                ObstacleRoom4.SetActive(true);
                kratos.GetComponent<KratusControl>().enemyAttackers = 0;
            }
        }
    }

    void Wave1Room()
    {
        if (kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy)
        {
            GameObject fire = GameObject.FindGameObjectWithTag("fire");
            if (kratos.GetComponent<KratusControl>().enemyAttackers == 0 || kratos.GetComponent<KratusControl>().enemyAttackers == 2)
            {
                Vector3 EnemyPos = Wave1Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().transform.position;
                fire.transform.position = new Vector3(EnemyPos.x, 1.22f, EnemyPos.z + 2f);
                Wave1Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = kratos.transform;
            }
            else
            {
                Vector3 EnemyPos = Wave1Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].transform.position;
                fire.transform.position = new Vector3(EnemyPos.x, 1.22f, EnemyPos.z + 2f);
            }
            Wave1Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].SetActive(true);
            fire.GetComponent<ParticleSystem>().Play();
            kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy = false;
        }
      
    }

    void Wave2Room()
    {
        if (kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy)
        {
            GameObject fire = GameObject.FindGameObjectWithTag("fire");
            if (kratos.GetComponent<KratusControl>().enemyAttackers == 0 || kratos.GetComponent<KratusControl>().enemyAttackers == 2)
            {
                Vector3 EnemyPos = Wave2Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().transform.position;
                fire.transform.position = new Vector3(EnemyPos.x, -26.61f, EnemyPos.z + 2f);
                Wave2Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = kratos.transform;
            }
            else
            {
                Vector3 EnemyPos = Wave2Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].transform.position;
                fire.transform.position = new Vector3(EnemyPos.x, -26.61f, EnemyPos.z + 2f);
            }
            Wave2Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].SetActive(true);
            fire.GetComponent<ParticleSystem>().Play();
            kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy = false;
        }

    }


    void Wave3Room()
    {
        if (kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy)
        {
            GameObject fire = GameObject.FindGameObjectWithTag("fire");
            if (kratos.GetComponent<KratusControl>().enemyAttackers == 0 || kratos.GetComponent<KratusControl>().enemyAttackers == 2)
            {
                Vector3 EnemyPos = Wave3Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().transform.position;
                fire.transform.position = new Vector3(EnemyPos.x, -26.61f, EnemyPos.z + 2f);
                Wave3Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = kratos.transform;
            }
            else
            {
                Vector3 EnemyPos = Wave3Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].transform.position;
                fire.transform.position = new Vector3(EnemyPos.x, -26.61f, EnemyPos.z + 2f);
            }
            Wave3Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].SetActive(true);
            fire.GetComponent<ParticleSystem>().Play();
            kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy = false;
        }

    }
}
