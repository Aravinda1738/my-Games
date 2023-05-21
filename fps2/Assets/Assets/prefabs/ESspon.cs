using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ESspon : MonoBehaviour
{
    public GameObject enemy;
    Vector3 sp;
    float a, b;
    public float SponInterval;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Espon", 10, SponInterval);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       a = Random.Range(130, 300);
      b = Random.Range(200, 400);
         sp = new Vector3(a, 10.2f, b);
        
    }

    public void Espon()
    {
        
        Instantiate(enemy,sp,Quaternion.identity);
       
    }
}
