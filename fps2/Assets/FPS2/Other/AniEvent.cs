using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniEvent : MonoBehaviour
{
    public Gun gun;
    public GameObject blood;
    public GameObject aimPoint;public float count;
    public AudioSource burst;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void aimEnd()
    {
        aimPoint.SetActive(true);
        if (count > 2)
        {
          burst.Stop();   

        }
    }

    public void onBlood()
    {
       
        burst.Play();
        if (gun.enemyLocated)
        {
            Debug.Log("enemy");
          blood.SetActive(true);
            
        }
    }
    public void offBlood()
    {
        blood.SetActive(false);
       
    }

}
