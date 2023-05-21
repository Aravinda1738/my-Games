using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hero : MonoBehaviour
{
    private float InputX;
    private float InputZ;
    Vector3 moveAndRotation;
    [SerializeField] float rotationSpeed = .2f;
    float magSpeed;
    private Animator anim;
    private Camera cam;
    private CharacterController cc;
    public static float movementSpeed = 7;

    public static int attackCount,hitvalue=40;

    public GameObject feet;
    public int jumpCount = 2;
    public float jumpForce = 4;
    //public Joystick joystick;

    public Transform atkPT,atkPT2;
    public float atkRange=.5f;
    public LayerMask enemyLayers;


   
    Vector3 jump;
    //[SerializeField] float jumpSpeed = 8.0F;
    [SerializeField] float gravity = 9;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        cam = Camera.main;
        cc = GetComponent<CharacterController>();
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        InputMagitude();
        attack();
        jump.y -= gravity * Time.deltaTime;
        cc.Move(jump * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            jumpCount -= 1;
            jump.y = jumpForce;
        }

    }


    void InputMagitude()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");
        //InputX = joystick.Horizontal;
        //InputZ = joystick.Vertical;
        magSpeed = new Vector3(InputX, InputZ).magnitude;

        if (magSpeed > .1)
        {
            PlayerMovementAndRotation();
            anim.SetBool("isMove", true);
            anim.SetFloat("xpos", -1);
            anim.SetFloat("ypos", 0);

        }
        else
        {
            anim.SetBool("isMove", false);
        //    anim.SetFloat("xpos", 0);
        //    anim.SetFloat("ypos", 0);
        }


    }
    void PlayerMovementAndRotation()
    {

        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        moveAndRotation = forward * InputZ + right * InputX;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveAndRotation), rotationSpeed);
        cc.Move(moveAndRotation * Time.deltaTime * movementSpeed);
    }
    void attack()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Collider[] hitEnemy = Physics.OverlapSphere(atkPT2.transform.position, atkRange, enemyLayers);
            attackCount += 1;
            foreach (Collider enemy in hitEnemy)
            {
                enemy.GetComponent<enemy>().takeHit(hitvalue);
                Debug.Log("hittttttttttttttttt");
            }



            movementSpeed = .5f;

        }
        if (attackCount == 1)
        {
            StartCoroutine(comb0());
           

        }
        else
        {
            
            anim.SetBool("Attack 1", false);
        }

        if (attackCount == 2)
        {
           
            
            StartCoroutine(comb());
           
        }
        else
        {
           
            anim.SetBool("Attack 2", false);
        }
        if (attackCount == 3)
        {
            
            StartCoroutine(comb2());
          
        }
        else
        {
           
             anim.SetBool("Attack 3", false);
        }
        if (attackCount == 0)
        {

            anim.SetBool("Attack 1", false);
            anim.SetBool("Attack 2", false);
            anim.SetBool("Attack 3", false);
        }
        if (attackCount > 3)
        {
            attackCount = 0;
        }


           

       
    }

    private void OnDrawGizmosSelected()
    {
        if (atkPT2 == null)
            return;

        Gizmos.DrawWireSphere(atkPT2.transform.position, atkRange);
    }









    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "s")
        {
            jumpCount = 2;
        }
    }


    private IEnumerator comb0()
    {

        anim.SetBool("Attack 1", true);
        yield return new WaitForSeconds(1.1f);
        anim.SetBool("Attack 1", false );
        StopCoroutine(comb0());
    }


    private IEnumerator comb()
    {
        StopCoroutine(comb0());
        yield return new WaitForSeconds(1.1f);
        anim.SetBool("Attack 1", false);
        anim.SetBool("Attack 2", true);
        StopCoroutine(comb());
    }

    private IEnumerator comb2()
    {
        StopCoroutine(comb());
        yield return new WaitForSeconds(2.1f);
        anim.SetBool("Attack 2", false );
        anim.SetBool("Attack 1", false);
        anim.SetBool("Attack 3", true);
        StopCoroutine(comb2());
    }


   


}
