using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingAway : MonoBehaviour
{
    [SerializeField] private float Force = 1000.0f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        if (rb != null && other.gameObject.CompareTag("Enemy") && Input.GetKeyDown(KeyCode.N))
        {
            rb.AddForce(-other.transform.forward * Force); // Додати сили для відштовхування
        }
    }
    
        
    
}
