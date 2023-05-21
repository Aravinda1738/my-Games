using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waitAndDo : MonoBehaviour
{
    private float timee;

    private bool start,end;

    public waitAndDo(float t)
    {
        this.Timee = t;
        
    }

    public float Timee { get => timee; set => timee = value; }
    public bool Start { get => start; set => start = value; }
    public bool End
    {
        get => end;
    }
    private void FixedUpdate()
    {
       

        if (Start)
        {
            
            Timee -= Time.deltaTime;

            if (Timee <= 0)
            {
                end = true;
            }
        }
        
    }
}
