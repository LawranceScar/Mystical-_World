using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpawnerInterface;

public class TriggerSpawn : MonoBehaviour
{

    [SerializeField] public EnemySpawners spawner;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spawner.IsEnemySpawn = true;
            spawner.IsOnTriggerEnter = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spawner.IsOnTriggerStay = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            spawner.IsEnemySpawn = false;
            spawner.IsOnTriggerStay = false;
        }
    }
}
