using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossCollider : MonoBehaviour
{
    [SerializeField] StartBoss Boss;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Boss.NeedBack = true;
            Boss.CanMove = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Boss.NeedBack = false;
            Boss.CanMove = true;
            Boss.DidAttack = false;
        }
    }
    
}
