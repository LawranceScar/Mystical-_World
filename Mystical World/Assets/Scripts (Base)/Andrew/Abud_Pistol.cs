using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abud_Pistol : MonoBehaviour
{
    
    public Transform hand;
    float range = 5;
    public static Camera Camera;
    private bool IsPistol;
    private GameObject TopPistol;
    public GameObject Pistol;
    private Rigidbody rb;
    void Start()
    {
        Camera = GetComponent<Camera>();
    }
    

    void Update()
    {
        
        RaycastHit hit;
        if(Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKey(KeyCode.E) && hit.transform.tag == "Pistol" && IsPistol == false)
        {
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
        if(ChangeSlots.WeaponS == true)
        {
            TopPistol.transform.GetComponent<Shoot>().ShootBullet();
        }
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
