 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawners : MonoBehaviour
{

    public GameObject SpawnFx;
    public GameObject enemyPrefab;    
    // In seconds
    [SerializeField] private float interval = 1f;
    private float timer = 0f;
    //GameObject[] rootEnemy;
    //parent layer parallax
    private GameObject parentLayer;

    public int MaxAmountEnemies = 5;
    private int DeleteAmount = 1;

    // Start is called before the first frame update
    void Start()
    {
        //rootEnemy = GameObject.FindGameObjectsWithTag("Enemy_root");        
        //if (rootEnemy != null) {
        //    foreach (var enemy in rootEnemy) {
        //        Destroy(enemy, 1f);
        //    }            
        //};
        //get parent layer
        parentLayer = GameObject.Find("Move BackGround Layer_1");

    }

    // Update is called once per frame
    void Update()
    {
        if (MaxAmountEnemies > 0)
        {
        timer += Time.deltaTime;

            if (timer >= interval)
            {
                timer = 0f;
                if (enemyPrefab != null)
                {
                    if (parentLayer != null)
                    {
                        MaxAmountEnemies = MaxAmountEnemies - DeleteAmount;
                        var enemy = Instantiate(enemyPrefab, transform.position, transform.rotation, parentLayer.transform);
                        var spawn_fx = Instantiate(SpawnFx, new Vector3(transform.position.x - 0.4f, transform.position.y - 0.3f, 1), transform.rotation);
                        spawn_fx.transform.SetParent(enemy.transform);
                        Destroy(spawn_fx, 2f);
                        
                    }
                    else
                    {
                        MaxAmountEnemies = MaxAmountEnemies - DeleteAmount;
                        var enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
                        var spawn_fx = Instantiate(SpawnFx, new Vector3(transform.position.x - 0.4f, transform.position.y - 0.3f, 1), transform.rotation);
                        spawn_fx.transform.SetParent(enemy.transform);
                        Destroy(spawn_fx, 2f);
                    }

                }
            }
        }
        Debug.Log(MaxAmountEnemies);
        
    }


}
