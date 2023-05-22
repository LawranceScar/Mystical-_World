 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpawnerInterface;
using System.Linq;
using System;
using Unity.Collections;

public class EnemySpawners : MonoBehaviour
{

    public bool IsEnemySpawn = true;
    [HideInInspector] public bool IsOnTriggerStay = false;
    [HideInInspector] public bool IsOnTriggerEnter = false;


    public GameObject SpawnFx;
    public GameObject enemyPrefab;

    public GameObject[] Clones;

    // In seconds
    [SerializeField] private float interval = 1f;
    private float timer = 0f;

    [SerializeField] private float IsEnemyTimer = 30f;
    private float SaveEnemyTimer;
    //GameObject[] rootEnemy;
    //parent layer parallax
    private GameObject parentLayer;

    public int MaxAmountEnemies = 5;
    [ReadOnly] public int CurrentAmountSpawnEnemy;
    private int SaveAmountEnemies;
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
        SaveAmountEnemies = MaxAmountEnemies;
        SaveEnemyTimer = IsEnemyTimer;
        parentLayer = GameObject.Find("Move BackGround Layer_1");

    }

    // Update is called once per frame
    void Update()
    {
        if (IsEnemySpawn == true)
        {
            if (MaxAmountEnemies > 0)
            {
                SpawnEnemy();
            }
            else
            {
                if (IsOnTriggerStay == false)
                {
                    IsEnemySpawn = false;
                }
            } 
                
        }
        else
        {
            RenewFunc();
        }
        Debug.Log(MaxAmountEnemies);

    }

    private void SpawnEnemy()
    {
        IsEnemyTimer = SaveEnemyTimer;
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            timer = 0f;
            if (enemyPrefab != null)
            {
                MaxAmountEnemies = MaxAmountEnemies - DeleteAmount;
                var enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
                Clones = Clones.Append(enemy).ToArray();
                Clones.Count();
                CurrentAmountSpawnEnemy = Clones.Length;
                if (SpawnFx != null)
                {
                    var spawn_fx = Instantiate(SpawnFx, new Vector3(transform.position.x - 0.4f, transform.position.y - 0.3f, 1), transform.rotation);
                    spawn_fx.transform.SetParent(enemy.transform);
                    Destroy(spawn_fx, 2f);
                }

            }
        }
    }

    private void RenewFunc()
    {
        if (IsOnTriggerStay == false)
        {
            if (Clones.Length != 0)
            {
                IsEnemyTimer -= Time.deltaTime;
                if (IsEnemyTimer <= 0)
                {
                    foreach (GameObject Game in Clones)
                    {
                        Destroy(Game);
                        Array.Clear(Clones, 0, 0);
                        CurrentAmountSpawnEnemy = 0;
                    }
                    MaxAmountEnemies = SaveAmountEnemies;
                    IsEnemyTimer = 0;
                }
            }
        }
    }


}
