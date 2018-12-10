using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour {

    public bool FightDone;
	// Use this for initialization
	void Start () {
    
	}
	
	// Update is called once per frame
	void Update () {
        
	}


    private void OnCollisionEnter(Collision other)
    {

        // if Boss hit Kratos
      if (other.gameObject.CompareTag("Player"))
      {
        double KratosHealthPoints = other.gameObject.GetComponent<KratusControl>().KratosHealthPoints;

            if (!FightDone && !other.gameObject.GetComponent<KratusControl>().blocking)
            {
                KratosHealthPoints -= 10;
                other.gameObject.GetComponent<Animator>().avatar = other.gameObject.GetComponent<KratusControl>().HitReactionAvatar;
                other.gameObject.GetComponent<Animator>().CrossFadeInFixedTime("Hit Reaction", 0.05f);
                other.gameObject.GetComponents<AudioSource>()[2].Play();
            }
           
            if (KratosHealthPoints <= 0)
            {
                //GameOver
                other.gameObject.GetComponent<KratusControl>().GameOver = true;
                other.gameObject.GetComponent<Animator>().avatar = other.gameObject.GetComponent<KratusControl>().DyingAvatar;
                other.gameObject.GetComponent<Animator>().CrossFadeInFixedTime("Dying", 0.05f);
                other.gameObject.GetComponents<AudioSource>()[1].Play();
                FightDone = true;
                this.gameObject.GetComponentInParent<BossLevel>().gameObject.SetActive(false);
            }
            else
            {
                other.gameObject.GetComponent<KratusControl>().ReturnToDefaultAvatar();
            }

            other.gameObject.GetComponent<KratusControl>().KratosHealthPoints = KratosHealthPoints;
           
      }
    }
}
