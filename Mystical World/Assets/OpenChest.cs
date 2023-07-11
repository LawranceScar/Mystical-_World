using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    public Transform Camera;
    public float range = 100f;
    void Start()
    {

    }


    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range) && Input.GetKey(KeyCode.F) && hit.transform.CompareTag("Chest"))
        {
            Debug.Log(hit.transform.name);
            Che cche = hit.transform.GetComponent<Che>();
            cche.SpawnWeapon(Random.Range(0, 4));
        }
        Debug.Log(hit.transform.name);
    }
}
