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
    public bool aimEnd;
    public Animator ani;
    float aniMovSpeed=0;
 [SerializeField] [Range(0f, 30f)] float lerpTime;
    //  public CinemachineBrain cineBrain;

    /* public float damage = 10f;
      float range = 999f;
     public Camera aimCamera;

     public LayerMask mask = new LayerMask();*/

    // Start is called before the first frame update
    void Start()
    {
        aimEnd = false;
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
        if (move.magnitude >= 0.1f) //movement
        {
          

            float ang = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;
            float finalAng = Mathf.SmoothDampAngle(transform.eulerAngles.y, ang, ref tempAng, angSmooth);
            transform.rotation = Quaternion.Euler(0f, finalAng, 0f);
            movDir = Quaternion.Euler(0f, finalAng, 0f) * Vector3.forward;
            cc.Move(movDir.normalized * speed * Time.deltaTime);
            ani.SetBool("run", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                aniMovSpeed = Mathf.Lerp(aniMovSpeed,2f,lerpTime*Time.deltaTime);
            }
            else
            {
              aniMovSpeed = Mathf.Lerp(aniMovSpeed, 1f, lerpTime * Time.deltaTime);
                    
            }
            ani.SetFloat("mov",aniMovSpeed);
        }
        else
        {
            ani.SetBool("run", false);
                
        }

        if (Input.GetKeyDown(KeyCode.Escape)) //escape
        {
           Cursor.lockState = CursorLockMode.None;
        }
        
        if (Input.GetKey(KeyCode.Mouse1))//aim
        {
            aimView.Priority = 14;

            ac.aim();
            rig.weight = 1f;
            ani.SetBool("aim", true);
            mark.SetActive(true);
        }
        else
        {
           
            aimView.Priority = 10;
            rig.weight = 0f;
            mark.SetActive(false);
            
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            aimEnd = false;
            ani.SetBool("aim", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            ani.SetTrigger("fire");
        }

        if (Input.GetMouseButtonUp(0))
        {
            ani.ResetTrigger("fire");
        }

    }
}
