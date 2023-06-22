using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abud_Axe : MonoBehaviour
{
    public Transform Axe;
    float range = 20;
    public Camera Camera;
    public bool IsAxe;
    public GameObject TopAxe;
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
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKeyDown(KeyCode.E) && IsAxe == false && hit.transform.tag == "Axe")
        {
            TopAxe = hit.transform.gameObject;
            GiveSword(hit.transform);
            IsAxe = true;

        }
        if (IsAxe == true && Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKeyDown(KeyCode.E) && hit.transform.tag == "Axe")
        {
            Drop(TopAxe.transform);
            TopAxe = hit.transform.gameObject;
            GiveSword(hit.transform);

        }

        Debug.Log(hit.transform.name);
        Debug.Log(TopAxe.transform.name);


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
        Rigidbody rbpistol = newSword.GetComponent<Rigidbody>();
        rbpistol.isKinematic = true;
        newSword.SetParent(Axe);
        newSword.localPosition = Vector3.zero;
        newSword.localRotation = Quaternion.Euler(0, -180, 0);

    }
    public void Drop(Transform newSword)
    {
        Rigidbody rbpistol = newSword.GetComponent<Rigidbody>();
        rbpistol.isKinematic = true;
        newSword.SetParent(null);
    }
}
