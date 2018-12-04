using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public double EnemyHealthPoints = 50;
    bool die;
    bool Attack;
   

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
	}

    private void OnCollisionEnter(Collision other)
    {
        
        // if enemy hand hit Kratos
        if (other.gameObject.CompareTag("Player"))
        {
            double KratosHealthPoints = other.gameObject.GetComponent<KratusControl>().KratosHealthPoints;

            if (KratosHealthPoints <= 0)
            { 
                //GameOver
            }
            else
                KratosHealthPoints -= 10;

            other.gameObject.GetComponent<KratusControl>().KratosHealthPoints = KratosHealthPoints;
        }
    }
}
