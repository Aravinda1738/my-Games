using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mp : MonoBehaviour
{
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ani.SetBool("attack", true);
          
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + .1f);
            ani.SetBool("attack", false );
            ani.SetBool("run", true);
        }
        else
        {
            ani.SetBool("run", false);
        }
         if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - .1f);
            ani.SetBool("attack", false );
            ani.SetBool("run", true);
        }
        else
        {
            ani.SetBool("run", false);
        }

    }
}
