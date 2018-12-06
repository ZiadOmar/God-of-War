using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erika : MonoBehaviour {
    public Transform erika;
    int c = 0;
    Vector3 forward ;
    float speed = 5;
    public GameObject newparent;
    GameObject kratos;
    public GameObject arrow;
    // Use this for initialization
    void Start () {
        forward = erika.forward;
        kratos = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        
	}
    public void shootarrow()
    {
        
        if (c > 130)
        {
            GameObject Inarrow = Instantiate(arrow, transform);
            Inarrow.transform.parent = transform.parent;
            float step = speed * Time.deltaTime;
            Inarrow.transform.position = Vector3.MoveTowards(transform.position, kratos.transform.position, step);
            Inarrow.transform.LookAt(kratos.transform);
            Inarrow.transform.parent = newparent.transform;
        }
        Debug.Log(c);
        c++;
    }
}
