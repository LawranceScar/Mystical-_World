using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private bool IsEnemySpawned = false;
    [SerializeField] private int EnemiesCount = 5;
    [SerializeField] private EnemyManager Manager;
    [SerializeField] private GameObject PrefabEnemy;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !IsEnemySpawned)
        {
            IsEnemySpawned = true;
            for (int i = 0; i < EnemiesCount; i++)
            {
                GameObject NewEnemy = Instantiate(PrefabEnemy, Manager.gameObject.transform.position, Quaternion.identity);
                Manager.AddEnemy(NewEnemy);
            }
        }
    }
}