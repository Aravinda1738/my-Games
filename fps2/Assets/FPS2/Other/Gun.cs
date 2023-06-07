using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 999f;
    public Camera cam;
    public LayerMask mask = new LayerMask();
    public GameObject aimPoint;
    public bool debug, enemyLocated;
    public RaycastHit hit;
    
    // Update is called once per frame
    void Update()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);



        /* if (Input.GetMouseButtonUp(1))
         {
             aimPoint.SetActive(false);
         }*/


        if (Physics.Raycast(ray, out hit, range, mask))
        {
            if (debug)
            {
                Debug.Log(hit.transform.position + " " + hit.collider.name + enemyLocated);

            }

            aimPoint.transform.position = hit.point;
            if (hit.collider.tag.Equals("enemy"))
            {
                enemyLocated = true;
                
            }
            else
            {
                enemyLocated = false;
            }

        }






    }
}
