using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeSword : MonoBehaviour
{
    public Transform Sword;
    float range = 3;
    public GameObject Camera;
    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKeyDown(KeyCode.E) && hit.transform == gameObject.CompareTag("Sword"))
        {
            GiveSword(hit.transform);
        }
    }

    public void GiveSword(Transform newSword)
    {
        newSword.SetParent(Sword);
        newSword.localPosition = Vector3.zero;
        newSword.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
