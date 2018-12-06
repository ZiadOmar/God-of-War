using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossLevel : MonoBehaviour {

    public double BossHealthPoints = 200;

    public bool[] BossAttacks = new bool[3];
    float timer = 0.0f;
    int seconds;

    float animTimer;
    int animSeconds;

    // Boss being Attacked
    public int WeakPoint1=0;
    public int WeakPoint2 =0;
    public int WeakPoint3 =0;

    private float remainingDistance;
    private int RandomAttack;

    private bool attack;
    // Use this for initialization
    void Start ()
   {
		
   }
	
   // Update is called once per frame
   void Update ()
   {

        this.gameObject.GetComponent<Animator>().SetFloat("Forward", this.gameObject.GetComponent<NavMeshAgent>().remainingDistance);
        remainingDistance = this.gameObject.GetComponent<NavMeshAgent>().remainingDistance;
        // 5 Seconds Time
        timer += Time.deltaTime;
      seconds = System.Convert.ToInt32(timer % 60);
        if (seconds == 5)
        {
            timer = 0.0f;
            attack = true;
            Debug.Log("5 seconds passed");

            for(int attackIndex = 0; attackIndex < 3; attackIndex++)
            {
                BossAttacks[attackIndex] = false;
            }
            // Choose Attack Randomly
            RandomAttack = (int)Random.Range(0.0f, 3.0f);


 
                switch (RandomAttack)
                {
                    case 0:
                        this.gameObject.GetComponent<Animator>().SetBool("Head attack", true);
                        this.gameObject.GetComponent<Animator>().SetBool("Hand attack", false);
                        this.gameObject.GetComponent<Animator>().SetBool("Leg attack", false);
                        attack = false;
                        break;
                    case 1:
                        this.gameObject.GetComponent<Animator>().SetBool("Head attack", false);
                        this.gameObject.GetComponent<Animator>().SetBool("Hand attack", true);
                        this.gameObject.GetComponent<Animator>().SetBool("Leg attack", false);
                        attack = false; break;
                    case 2:
                        this.gameObject.GetComponent<Animator>().SetBool("Head attack", false);
                        this.gameObject.GetComponent<Animator>().SetBool("Hand attack", false);
                        this.gameObject.GetComponent<Animator>().SetBool("Leg attack", true);
                        attack = false; break;

                    default: break;
                }



            }

        animTimer += Time.deltaTime;
        animSeconds = System.Convert.ToInt32(timer % 60);

        if (animSeconds == 2)
        {
            animSeconds = 0;
            this.gameObject.GetComponent<Animator>().SetBool("Head attack", false);
            this.gameObject.GetComponent<Animator>().SetBool("Hand attack", false);
            this.gameObject.GetComponent<Animator>().SetBool("Leg attack", false);


            //this.gameObject.GetComponent<Animator>().SetBool("Head attack", false);
            //this.gameObject.GetComponent<Animator>().SetBool("Hand attack", false);
            //this.gameObject.GetComponent<Animator>().SetBool("Leg attack", false);

            Debug.Log("Attack Chosen:" + RandomAttack);
            //BossAttacks[RandomAttack-1] = true; 
        
        }



    }
}
