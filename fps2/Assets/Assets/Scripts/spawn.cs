using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject enemy;
    public float distance;
    GameObject player;
    bool isTrue=false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance<10&&!isTrue)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            isTrue = true;
        }
    }


}
