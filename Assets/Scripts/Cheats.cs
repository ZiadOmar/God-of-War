using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour {

    public KratusControl Kratos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
   

        if (Input.GetKeyDown(KeyCode.F1)) //Finish wave Cheaaat
            Kratos.enemyAttackers = 4;

        if (Input.GetKeyDown(KeyCode.F2)) //Kill Enemy Cheaaat
            Kratos.XPIncAndCheckForLevelUp();
    }
}
