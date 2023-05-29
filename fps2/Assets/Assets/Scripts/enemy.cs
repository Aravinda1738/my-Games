using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    GameObject player;
    NavMeshAgent nav;
     Animator ani;
    public int maxHP, damage,atkType;
    public float dist,Ehealth,rot,eLevel;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        nav = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
        atkType = Random.Range(0, 2);
        ani.SetBool("attack", false);
        maxHP = 100;
        Ehealth = maxHP;
        ani.SetFloat("attackType",atkType );
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
       // rot = player.transform.rotation.y - transform.rotation.y;

        transform.LookAt(player.transform);
       

        if(Vector3.Distance(player.transform.position,transform.position) < dist)
        {
            ani.SetBool("attack",true);
            ani.SetBool("run", false );
            
        }
        else
        {
            ani.SetBool("attack", false );
            ani.SetBool("run", true);
        }

        if (Ehealth < 1)
        {
            ani.SetBool("dead", true);
        }
        else
        {
            nav.SetDestination(player.transform.position);
            ani.SetBool("dead", false );
        }


    }

    public void takeHit(int damage)
    {
        Ehealth -= damage;

        if (Ehealth <= 0)
        {
            ani.SetBool("dead", true);

        }
    }
}
