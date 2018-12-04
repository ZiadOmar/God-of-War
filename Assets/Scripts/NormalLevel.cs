using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalLevel : MonoBehaviour {

    public UnityStandardAssets.Characters.ThirdPerson.AICharacterControl[] Wave1Enemies = new UnityStandardAssets.Characters.ThirdPerson.AICharacterControl[2];
    GameObject[] Wave2Enemies = new GameObject[2];
    GameObject[] Wave3Enemies = new GameObject[2];

    public GameObject kratos;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Wave1Enemies[kratos.GetComponent<KratusControl>().enemyAttackers].target = kratos.transform;
        


    }
}
