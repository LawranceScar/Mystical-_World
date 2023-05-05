using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriegerForBoss : MonoBehaviour
{
    [SerializeField] private StartBoss Boss;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Boss.CanMove = true;
        }
    }
}
