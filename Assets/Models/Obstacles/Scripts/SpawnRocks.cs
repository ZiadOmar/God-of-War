using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRocks : MonoBehaviour {
    public GameObject rocks;
    float r;
    public int c =0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(c> 50){
            r = Random.Range(-20, 0);
            Instantiate(rocks, new Vector3(Random.Range(-10.0f, 10.0f), transform.position.y, transform.position.z + r), transform.rotation,transform.parent);
            c = 0;
        }
        c++;
    }

}
