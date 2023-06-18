using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbudLaser : MonoBehaviour
{
    [SerializeField] public Transform laserhand;
    [SerializeField] public Camera Camera;
    [SerializeField] public GameObject TopLaser;
    ShootLaser myshootlaser;
    float range = 20f;
    bool IsLaser;
    public static bool workLaser;
    void Start()
    {
        myshootlaser = GetComponent<ShootLaser>();
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKey(KeyCode.E) && hit.transform.tag == "Laser" && IsLaser == false)
        {
            GetPistol(hit.transform);
            TopLaser = hit.transform.gameObject;
            IsLaser = true;
        }
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKey(KeyCode.E) && hit.transform.tag == "Laser" && IsLaser == true)
        {
            DropPistol(TopLaser.transform);
            GetPistol(hit.transform);
            TopLaser = hit.transform.gameObject;
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
