using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage=10f;
    public float range=999f;
    public Camera cam;
    public LayerMask mask=new LayerMask();
    public GameObject aimPoint;

    // Update is called once per frame
    void Update()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);


        
            
            if (Physics.Raycast(ray, out RaycastHit hit, range, mask))
            {
                Debug.Log(hit.transform.position + "  " + hit.collider.name);

                aimPoint.transform.position = hit.point;
            }
       

        


    }
}
