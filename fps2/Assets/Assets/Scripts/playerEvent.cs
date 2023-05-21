using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void normalspeed()
    {
        Hero.movementSpeed = 7;
    }

    public void attack ()
    {
        Hero.attackCount = 0;
    }
}
