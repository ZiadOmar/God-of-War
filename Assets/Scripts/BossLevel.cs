using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLevel : MonoBehaviour {

    public double BossHealthPoints = 200;

    public bool[] BossAttacks = new bool[3];
    float timer = 0.0f;
    int seconds;

    // Boss being Attacked
    public int WeakPoint1=0;
    public int WeakPoint2 =0;
    public int WeakPoint3 =0;
    // Use this for initialization
    void Start ()
   {
		
   }
	
   // Update is called once per frame
   void Update ()
   {
      // 5 Seconds Time
      timer += Time.deltaTime;
      seconds = System.Convert.ToInt32(timer % 60);
        if (seconds == 5)
        {
            timer = 0.0f; 
            Debug.Log("5 seconds passed");

            for(int attackIndex = 0; attackIndex < 3; attackIndex++)
            {
                BossAttacks[attackIndex] = false;
            }
            // Choose Attack Randomly
            int RandomAttack = (int)Random.Range(1.0f, 4.0f);
            Debug.Log("Attack Chosen:" + RandomAttack);
            BossAttacks[RandomAttack-1] = true; 
        
        }
   }
}
