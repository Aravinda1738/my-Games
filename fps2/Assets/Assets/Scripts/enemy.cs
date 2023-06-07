using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    GameObject player;
    NavMeshAgent nav;
    Animator ani;
    public int maxHP, damage, atkType;
    public float dist, Ehealth, rot, eLevel, random, outofdist;
    bool isDead;
    public AudioSource run, walk;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        random = Random.Range(0, 2);
        ani.SetBool("attack", false);
        maxHP = 100;
        Ehealth = maxHP;
        ani.SetFloat("attackType", random);
        random = Random.Range(0, 2);
        ani.SetFloat("deathType", random);
        ani.SetFloat("runType", random);
        outofdist = dist * 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        // rot = player.transform.rotation.y - transform.rotation.y;


        float playerDist = Vector3.Distance(player.transform.position, transform.position);

        if (playerDist < 2) //attacks range
        {
            ani.SetBool("attack", true);
            ani.SetBool("run", false);
            ani.SetBool("idle", false);
            if (!isDead)
            {
                nav.enabled = true;
            }
        }
        if (playerDist > dist && playerDist < outofdist) //witin range but out of attack range
        {
            ani.SetBool("attack", false);
            ani.SetBool("run", true);
            ani.SetBool("idle", false);
            if (!isDead)
            {
                nav.enabled = true;
            }
        }
        if (playerDist > outofdist)//out of range
        {
            ani.SetBool("idle", true);
            ani.SetBool("run", false);
            if (!isDead)
            {
                nav.enabled = false;
            }
        }


        if (Ehealth < 1)//death
        {
            isDead = true;
            Destroy(gameObject, 5f);
        }
        else
        {
         if (nav.enabled) { 
            
            nav.SetDestination(player.transform.position);
            }
            transform.LookAt(player.transform);
            // ani.SetBool("dead", false );
        }


    }

    public void takeHit(int damage)
    {
        Ehealth -= damage;

        if (Ehealth <= 0)
        {
            ani.SetBool("dead", true);
            nav.enabled = false;
        }
    }
}
