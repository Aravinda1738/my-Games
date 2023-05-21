using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zom : MonoBehaviour
{
    public Player player;
    public NavMeshAgent agent;
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.run)
        {
            ani.SetBool("run", true);
         agent.SetDestination(player.transform.position);
        // transform.LookAt(player.transform);

        }
    }
}
