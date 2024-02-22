using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggeringZoneForEnenies : MonoBehaviour
{
    NAVMeshEnemyMovement EnemyMovment = new NAVMeshEnemyMovement();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnemyMovment.WantToFollow = true;
            EnemyMovment.SetTimer();
        }
    }

}
