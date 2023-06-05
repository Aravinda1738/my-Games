using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AimCam : MonoBehaviour
{
    public float speed , xrot,a,b,x,y;
    public Transform body;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         x = Input.GetAxis("Mouse X") * speed * Time.deltaTime;
         y = Input.GetAxis("Mouse Y")* speed * Time.deltaTime;

      

    }



    public void aim() {

        xrot -= y;
        xrot = Mathf.Clamp(xrot, -40, 40);
        transform.localRotation = Quaternion.Euler(xrot, 0f, 0f);
        //  transform.rotation= new Quaternion(xrot,transform.rotation.y,transform.rotation.z,0);
        body.Rotate(Vector3.up * x);

    }
}
