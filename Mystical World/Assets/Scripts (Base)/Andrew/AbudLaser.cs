using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbudLaser : MonoBehaviour
{
    [SerializeField] public Transform laserhand;
    [SerializeField] public Camera Camera;
    [SerializeField] public GameObject TopLaser;
    public static Camera Shootcamera;
    ShootLaser myshootlaser;
    float range = 20f;
    bool IsLaser;
    public static bool workLaser;
    void Start()
    {
        Shootcamera = Camera;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKey(KeyCode.E) && hit.transform.tag == "Laser" && IsLaser == false)
        {
            TopLaser = hit.transform.gameObject;
            GetPistol(hit.transform);
            IsLaser = true;
        }
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKey(KeyCode.E) && hit.transform.tag == "Laser" && IsLaser == true)
        {
            DropPistol(TopLaser.transform);
            TopLaser = hit.transform.gameObject;
            GetPistol(hit.transform);
        }
           myshootlaser = TopLaser.GetComponent<ShootLaser>();
            if(myshootlaser != null)
            {

                myshootlaser.ShootLazer();
            }
           
        if (Input.GetKeyDown(KeyCode.K) && workLaser == false)
        {
            ShootLaser.mylinerenderer.enabled = true;
            workLaser = true;
        }
        else if (Input.GetKeyDown(KeyCode.K) && workLaser == true)
        {
            ShootLaser.mylinerenderer.enabled = false;
            workLaser = false;
        }
       
    }
    public void GetPistol(Transform pistol)
    {
        pistol.SetParent(laserhand);
        pistol.localPosition = Vector3.zero;
        pistol.localRotation = Quaternion.Euler(0, 0, 0);
    }
    public void DropPistol(Transform pistol)
    {
        pistol.SetParent(null);
    }
}
