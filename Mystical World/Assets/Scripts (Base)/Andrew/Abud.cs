using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abud : MonoBehaviour
{
    public Transform Sword;
    float range = 20;
    public Camera Camera;
    public bool IsSword = false;
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
       
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKey(KeyCode.E) && hit.transform.tag == "Sword" && IsSword == false)
        {
            TopSword = hit.transform.gameObject;
            GiveSword(hit.transform);
            IsSword = true;
            Debug.Log(TopSword.name);
        }
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKey(KeyCode.E) && hit.transform.tag == "Sword" && IsSword == true)
        {
            Drop(TopSword.transform);
            TopSword = null;
            TopSword = hit.transform.gameObject;
            GiveSword(hit.transform);
            Debug.Log(TopSword.name);
        }
    }
    public void GiveSword(Transform newSword)
    {
        newSword.SetParent(Sword);
        newSword.localPosition = Vector3.zero;
        newSword.localRotation = Quaternion.Euler(0, 0, 0);
        
    }
    public void Drop(Transform newSword)
    {
        Debug.Log("ppss");
        newSword.SetParent(null);
    }
}
