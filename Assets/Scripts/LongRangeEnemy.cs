using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LongRangeEnemy : MonoBehaviour
{
    public double EnemyHealthPoints = 50;
    public string type;
    public GameObject Kratos;

    // Fire Man
    public GameObject firePrefab;
    GameObject FireHand;

    // Timer
    float timer = 0.0f;
    int seconds;

    public bool FireManDead;

    //Sound
    public Sound SoundManager;

    // Use this for initialization
    void Start()
    {
        FireHand = GameObject.FindGameObjectWithTag("FireHand");
        this.GetComponents<AudioSource>()[2].outputAudioMixerGroup.audioMixer.SetFloat("VoiceOverVol", SoundManager.SpeechVolume); //Voice Over
    }

    // Update is called once per frame
    void Update()
    { 
        // 3 Seconds Time
        timer += Time.deltaTime;
        seconds = System.Convert.ToInt32(timer % 60);
        if (seconds == 3)
        {
            timer = 0.0f;
            Debug.Log("3 seconds passed");

            if (type == "long_range" && !FireManDead)
            {
                this.gameObject.GetComponent<Animator>().SetTrigger("shoot");
                shootfire();
            }
        }
    this.transform.LookAt(Kratos.transform);        
    }
   
    public void shootfire()
    {
        GameObject fire = Instantiate(firePrefab, FireHand.transform);
        float step = 2f * Time.deltaTime;
        fire.transform.position = Vector3.MoveTowards(this.transform.position, Kratos.transform.position, step);
        fire.transform.LookAt(Kratos.transform);

        StartCoroutine(Wait(fire));
    }

    IEnumerator Wait(GameObject fire)
    {
        yield return new WaitForSecondsRealtime(5f);
        Destroy(fire);
    }

}

