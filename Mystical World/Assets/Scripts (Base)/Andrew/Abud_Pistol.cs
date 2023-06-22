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
        Rigidbody rbpistol = pistol.GetComponent<Rigidbody>();
        rbpistol.isKinematic = true;
        pistol.SetParent(hand);
        pistol.localPosition = Vector3.zero;
        pistol.localRotation = Quaternion.Euler(-90, 0, 0);
    }
    public void DropPistol(Transform pistol)
    {
        pistol.SetParent(null);
        Rigidbody rbpistol = pistol.GetComponent<Rigidbody>();
        rbpistol.isKinematic = false;
    }
}
