using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using Cinemachine;

public class Movement : MonoBehaviour
{
    public CharacterController cc;
    public float speed,tempAng,angSmooth;
    public GameObject body,cam,mark;
    public CinemachineVirtualCamera aimView;
    Vector3 movDir;
   public Transform t,aimT;
    public AimCam ac;
    public Rig rig;
    public bool aim;
  //  public CinemachineBrain cineBrain;

    /* public float damage = 10f;
      float range = 999f;
     public Camera aimCamera;

     public LayerMask mask = new LayerMask();*/
  
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

  


    // Update is called once per frame
    void Update()
    {
        
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x,0f,z).normalized;


       /* Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

      
        

        if (Physics.Raycast(ray, out RaycastHit hit, range, mask))
        {
            Debug.Log(hit.transform.position + "  " + hit.collider.name);

            aimT.position = hit.point;
        }
*/

        if (Input.GetKeyDown(KeyCode.Escape))
        {
           Cursor.lockState = CursorLockMode.None;
        }
        
        if (Input.GetKey(KeyCode.Mouse1))
        {
            aimView.Priority = 14;

            ac.aim();
            rig.weight = 1f;
            aim = true;
            mark.SetActive(true);
        }
        else
        {
            aim = false;
            aimView.Priority = 10;
            rig.weight = 0f;
            mark.SetActive(false);
            if (move.magnitude >= 0.1f)
            {
                float ang = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
                float finalAng = Mathf.SmoothDampAngle(transform.eulerAngles.y, ang, ref tempAng, angSmooth);
                movDir = Quaternion.Euler(0, finalAng, 0) * Vector3.forward;
                transform.rotation = Quaternion.Euler(0, finalAng, 0);
                cc.Move(movDir * speed * Time.deltaTime);
            }
        }
        
       


    }
}
