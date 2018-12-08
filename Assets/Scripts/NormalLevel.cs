using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalLevel : MonoBehaviour {

    public GameObject[] Wave1Enemies = new GameObject[4];
    public GameObject[] Wave2Enemies = new GameObject[4];
    public GameObject[] Wave3Enemies = new GameObject[4];


    public GameObject kratos;

    // Wave Obstacle Rooms Bool
    public bool Wave1;
    public bool Wave2;
    public bool Wave3;

    // Wave Obstacle Rooms Bool
    public GameObject Wave1ObstacleRoom;
    public GameObject Wave2ObstacleRoom;
    public GameObject Wave3ObstacleRoom;

    // Use this for initialization
    void Start () {
        Wave1 = true;
        Wave1ObstacleRoom.SetActive(true);

        Wave2 = false;
        Wave2ObstacleRoom.SetActive(false);

        Wave3 = false;
        Wave3ObstacleRoom.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (kratos.GetComponent<KratusControl>().enemyAttackers < 4)
        {
            if (Wave1)
                Wave1Room();

            if (Wave2)
                Wave2Room();

            if (Wave3)
                Wave3Room();

        }


        if (kratos.GetComponent<KratusControl>().enemyAttackers == 4)
        {
            if (Wave1)
            {
                Wave1 = false;
                Wave1ObstacleRoom.SetActive(false);
                Wave2 = true;
                Wave2ObstacleRoom.SetActive(true);
                Wave3 = false;
                kratos.GetComponent<KratusControl>().enemyAttackers = 0;
            }

            else if (Wave2)
            {
                Wave1 = false;
                Wave2 = false;
                Wave2ObstacleRoom.SetActive(false);
                Wave3 = true;
                Wave3ObstacleRoom.SetActive(true);
                kratos.GetComponent<KratusControl>().enemyAttackers = 0;
            }

            else if (Wave3)
            {
                Wave1 = false;
                Wave2 = false;
                Wave3 = false;
                Wave3ObstacleRoom.SetActive(false);
                kratos.GetComponent<KratusControl>().enemyAttackers = 0;

                kratos.GetComponent<KratusControl>().BossLevel.SetActive(true);
                kratos.GetComponent<KratusControl>().NormalLevel.SetActive(false);
            }
        }
    }

    void Wave1Room()
    {
        if (kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy)
        {
            GameObject fire = GameObject.FindGameObjectWithTag("fire");
            fire.transform.position = Wave1Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().transform.position;
            Wave1Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].SetActive(true);
            fire.GetComponent<ParticleSystem>().Play();
            kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy = false;
        }
        Wave1Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = kratos.transform;
    }

    void Wave2Room()
    {
        if (kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy)
        {
            GameObject fire = GameObject.FindGameObjectWithTag("fire");
            fire.transform.position = Wave2Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().transform.position;
            Wave2Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].SetActive(true);
            fire.GetComponent<ParticleSystem>().Play();
            kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy = false;
        }
        Wave2Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = kratos.transform;   
    }


    void Wave3Room()
    {
        if (kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy)
        {
            GameObject fire = GameObject.FindGameObjectWithTag("fire");
            fire.transform.position = Wave3Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().transform.position;
            Wave3Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].SetActive(true);
            fire.GetComponent<ParticleSystem>().Play();
            kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy = false;
        }
        Wave3Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = kratos.transform;
    }
}
