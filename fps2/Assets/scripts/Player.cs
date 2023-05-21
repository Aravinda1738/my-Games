using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    public bool run = false;
    public bool walk = false;
    public Rigidbody rb;
    public float speed,tt;
    public Light a, b, c,w,s,e;
    
    public CinemachineVirtualCamera cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (run)
        {
          tt -= Time.deltaTime;
            rb.velocity = transform.forward * speed;
            if (tt<=0)
            {
                cam.Priority = 11;
            }
        }

        if (walk)
        {
            rb.velocity = transform.forward * (speed/2);
        }
    }

    public void runn()
    {
        
        run = true;
        
    }
    public void walkk()
    {
        walk = true;
         
    }
    public void Swalkk()
    {
        walk = false;

    }
}
