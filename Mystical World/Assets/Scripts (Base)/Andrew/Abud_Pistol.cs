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
    void Start()
    {
        ShootCamera = Camera;
    }
    

    void Update()
    {
       
        RaycastHit hit;
        if(Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKey(KeyCode.E) && hit.transform.tag == "Pistol" && IsPistol == false)
        {
            Debug.Log(hit.transform.name);
            GetPistol(hit.transform);
            TopPistol = hit.transform.gameObject;
            IsPistol = true;
           
        }
        if(Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKey(KeyCode.E) && hit.transform.tag == "Pistol" && IsPistol == true)
        {
            DropPistol(TopPistol.transform);
            GetPistol(hit.transform);
            TopPistol = hit.transform.gameObject;
        }
        Shoot ShootRef = TopPistol.GetComponent<Shoot>();
        //if(Input.GetAxis("Fire1") == 1)
        //{
        //    Debug.Log("Oh");
         //   if (ShootRef != null)
             //   {
             //           ShootRef.ShootBullet();
               // }
        //}
    }
    public void GetPistol(Transform pistol)
    {
        pistol.SetParent(hand);
        pistol.localPosition = Vector3.zero;
        pistol.localRotation = Quaternion.Euler(0, 0, 0);
    }
    public void DropPistol(Transform pistol)
    {
        pistol.SetParent(null);
    }
}
