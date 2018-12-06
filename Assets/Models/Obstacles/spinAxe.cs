using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinAxe : MonoBehaviour {
    float x = -20;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (x < -20)
        {
            x -= 10000;
            transform.Rotate(0, 0, x);

        }
        if (x > -150)
        {
            x+=10000f;
            transform.Rotate(0, 0, x);

        }
    }
}
