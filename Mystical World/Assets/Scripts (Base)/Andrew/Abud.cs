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
        CheckSwordGive();
    }


    private void CheckSwordGive()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKeyDown(KeyCode.E) && IsSword == false && hit.transform.tag == "Sword")
        {
            Debug.Log("Big W");
            TopSword = hit.transform.gameObject;
            GiveSword(hit.transform);
            IsSword = true;

        }
        if (IsSword == true && Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKeyDown(KeyCode.E) && hit.transform.tag == "Sword")
        {
            Drop(TopSword.transform);
            TopSword = hit.transform.gameObject;
            GiveSword(hit.transform);

        }

        Debug.Log(hit.transform.name);
        Debug.Log(TopSword.transform.name);


        /*  if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKey(KeyCode.E) && hit.transform.tag == "Sword")
          {
              if (IsSword)
              {
                  Drop(TopSword.transform);
              }
              else
              {
                  GiveSword(hit.transform);
                  TopSword = hit.transform.gameObject;
                  IsSword = true;
              }
          } */
    }
    public void GiveSword(Transform newSword)
    {
        Rigidbody rbSword = newSword.GetComponent<Rigidbody>();
        rbSword.isKinematic = true;
        newSword.SetParent(Sword);
        newSword.localPosition = Vector3.zero;
        newSword.localRotation = Quaternion.Euler(0, 0, 0);
        BoxCollider swordcolider = newSword.GetComponent<BoxCollider>();
        swordcolider.isTrigger = true;
        
    }
    public void Drop(Transform newSword)
    {
        newSword.SetParent(null);
        Rigidbody rbSword = newSword.GetComponent<Rigidbody>();
        rbSword.isKinematic = false;
        BoxCollider swordcolider = newSword.GetComponent<BoxCollider>();
        swordcolider.isTrigger = false;
    }
}
