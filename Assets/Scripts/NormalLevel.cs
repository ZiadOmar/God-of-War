using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalLevel : MonoBehaviour {

    public GameObject[] Wave1Enemies = new GameObject[4];
   // GameObject[] Wave2Enemies = new GameObject[2];
    //GameObject[] Wave3Enemies = new GameObject[2];

    public GameObject kratos;
 
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (kratos.GetComponent<KratusControl>().enemyAttackers < 4)
        {
            if (kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy)
            {
                GameObject fire = GameObject.FindGameObjectWithTag("fire");
                fire.transform.position = Wave1Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].GetComponent< UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().transform.position;
                Wave1Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].SetActive(true);
                fire.GetComponent<ParticleSystem>().Play();
                kratos.GetComponentInChildren<WeaponAttack>().instNextEnemy = false;


            }
            Wave1Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].GetComponent<UnityStandardAssets.Characters.ThirdPerson.AICharacterControl>().target = kratos.transform;
        }
        


    }
}
