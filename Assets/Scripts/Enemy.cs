using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public double EnemyHealthPoints = 50;
    bool FightDone;
    bool Attack;
    public string type;
    int i = 0;
    GameObject hand;
  
    // Use this for initialization
    void Start () {
        hand = GameObject.FindGameObjectWithTag("handoferika");
	}
	
	// Update is called once per frame
	void Update () {
        if(type == "close_range")
            this.gameObject.GetComponent<Animator>().SetFloat("Forward",this.gameObject.GetComponent<NavMeshAgent>().remainingDistance);
        else
            this.gameObject.GetComponent<Animator>().SetFloat("Forward", this.gameObject.GetComponent<NavMeshAgent>().remainingDistance-19);
    }

    private void OnCollisionStay(Collision other)
    {
        
        // if enemy hand hit Kratos
        if (other.gameObject.CompareTag("Player"))
        {
            if(i ==0)
                Debug.Log("remaining distane" + this.gameObject.GetComponent<NavMeshAgent>().remainingDistance);

            if (i % 250 == 0)
            {
                double KratosHealthPoints = other.gameObject.GetComponent<KratusControl>().KratosHealthPoints;
                if (type == "close_range")
                    this.gameObject.GetComponent<Animator>().SetTrigger("attack");
                
                print("attack");

                if (!FightDone)
                {
                    KratosHealthPoints -= 10;
                    other.gameObject.GetComponent<Animator>().avatar = other.gameObject.GetComponent<KratusControl>().HitReactionAvatar;
                    other.gameObject.GetComponent<Animator>().CrossFadeInFixedTime("Hit Reaction", 0.05f);
                    other.gameObject.GetComponent<KratusControl>().ReturnToDefaultAvatar();
                }
                if (KratosHealthPoints <= 0)
                {
                    //GameOver
                    other.gameObject.GetComponent<KratusControl>().GameOver = true;
                    other.gameObject.GetComponent<Animator>().avatar = other.gameObject.GetComponent<KratusControl>().DyingAvatar;
                    other.gameObject.GetComponent<Animator>().CrossFadeInFixedTime("Dying", 0.05f);

                    FightDone = true;
                }

                other.gameObject.GetComponent<KratusControl>().KratosHealthPoints = KratosHealthPoints;
            }
            i++;
        }

      
       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (i == 0)
                Debug.Log("remaining distane" + this.gameObject.GetComponent<NavMeshAgent>().remainingDistance);

            if (i % 250 == 0)
            {
                double KratosHealthPoints = other.gameObject.GetComponent<KratusControl>().KratosHealthPoints;
                if (type == "long_range")
                {
                    this.gameObject.GetComponent<Animator>().SetTrigger("shoot");
                    hand.GetComponent<Erika>().enabled = true;


                    if (!FightDone)
                    {
                        KratosHealthPoints -= 10;
                        other.gameObject.GetComponent<Animator>().avatar = other.gameObject.GetComponent<KratusControl>().HitReactionAvatar;
                        other.gameObject.GetComponent<Animator>().CrossFadeInFixedTime("Hit Reaction", 0.05f);
                        other.gameObject.GetComponent<KratusControl>().ReturnToDefaultAvatar();
                    }
                    if (KratosHealthPoints <= 0)
                    {
                        //GameOver
                        other.gameObject.GetComponent<KratusControl>().GameOver = true;
                        other.gameObject.GetComponent<Animator>().avatar = other.gameObject.GetComponent<KratusControl>().DyingAvatar;
                        other.gameObject.GetComponent<Animator>().CrossFadeInFixedTime("Dying", 0.05f);

                        FightDone = true;
                    }

                    other.gameObject.GetComponent<KratusControl>().KratosHealthPoints = KratosHealthPoints;

                }
            }
            i++;
        }
    }
}
