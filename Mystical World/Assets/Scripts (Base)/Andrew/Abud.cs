using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abud : MonoBehaviour
{
    public Transform Sword;
    float range = 20;
    public Camera Camera;
    public bool IsSword;
    public GameObject TopSword;
    public GameObject SSword;
    public Rigidbody rb;
    public bool What = ChangeSlots.WeaponF;
    void Start()
    {
    }

    void Update()
    {
        RaycastHit hit;
       
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKey(KeyCode.E) && hit.transform.tag == "Sword")
        {
            GiveSword(hit.transform);
            TopSword = hit.transform.gameObject;
            
        }
        if ( Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKey(KeyCode.E) && hit.transform.tag == "Sword")
        {

            Drop(TopSword.transform);
            GiveSword(hit.transform);
            SSword = hit.transform.gameObject;
            TopSword = hit.transform.gameObject;

        }
        Debug.Log(hit.transform.name);
    }
    public void GiveSword(Transform newSword)
    {
        newSword.SetParent(Sword);
        newSword.localPosition = Vector3.zero;
        newSword.localRotation = Quaternion.Euler(0, 0, 0);
        
    }
    public void Drop(Transform newSword)
    {
        newSword.SetParent(null);
    }
}
