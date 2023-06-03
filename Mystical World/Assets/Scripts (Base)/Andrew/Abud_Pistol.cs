using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abud_Pistol : MonoBehaviour
{
    
    public Transform hand;
    float range = 20;
    public GameObject Camera;
    public static GameObject ShootCamera;
    private bool IsPistol;
    public GameObject TopPistol;
    Shoot ShootRef;
    void Start()
    {
        
        ShootCamera = Camera;
    }
    

    void Update()
    {
       
        RaycastHit hit;

          if(Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKey(KeyCode.E) && hit.transform.tag == "Pistol")
          {
              if (IsPistol)
              {
                  DropPistol(TopPistol.transform);

              }
              TopPistol = hit.transform.gameObject;
              GetPistol(hit.transform);
              IsPistol = true;

          } 

        Shoot();

       /* if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKeyDown(KeyCode.E) && IsPistol == false && hit.transform.tag == "Pistol")
        {
            Debug.Log("Debil");
            TopPistol = hit.transform.gameObject;
            GetPistol(hit.transform);
            IsPistol = true;

        }
        if (IsPistol == true && Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKeyDown(KeyCode.E) && hit.transform.tag == "Pistol")
        {
            Debug.Log("Debil1");
            DropPistol(TopPistol.transform);
            TopPistol = hit.transform.gameObject;
            GetPistol(hit.transform);

        } */
    }


    private void Shoot()
    {
        ShootRef = TopPistol.GetComponent<Shoot>();
        if (Input.GetAxis("Fire1") == 1)
        {
            // Debug.Log(ShootRef);
            if (ShootRef != null)
            {
                ShootRef.ShootBullet();
            }
        }
    }
    public void GetPistol(Transform pistol)
    {
        pistol.SetParent(hand);
        pistol.localPosition = Vector3.zero;
        pistol.localRotation = Quaternion.Euler(-90, 0, 0);
    }
    public void DropPistol(Transform pistol)
    {
        pistol.SetParent(null);
    }
}
