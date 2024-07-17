using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public bool WantToFollowTarget = false;

    [SerializeField] public List<NAVMeshEnemyMovement> Enemies;
    [SerializeField] public List<EnemyHealthSystem> EnemiesHealth;
    [SerializeField] public AllLiferSystems PlayerHealth = new AllLiferSystems();

    private float SideOfTrigerZone = 20f;
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private float MinDistance = 3.0f;

    private float WaitingTime = 20;
    private float AttackingTime = 0;
    private GameObject Attacker;

    private void Start()
    {
        Enemies = new List<NAVMeshEnemyMovement>(); 
        EnemiesHealth = new List<EnemyHealthSystem>();
    }

    void Update()
    {
        if (WantToFollowTarget)
        {
            
            if (AttackingTime <= Time.time)
            {
                ChoosingAttackingEnemy();
                AttackingTime = Time.time + WaitingTime;
            }
            SetingTargetPositionsForEnemy();
        }
    }

    Vector3 SetTargetPosition(NavMeshAgent Enemy, bool WantToAttack)
    {
        Vector3 TargetLocation = PlayerTransform.position;

        if (!WantToAttack)
        {
            for (int i = 0; i < 200; i++)
            {
                if((TargetLocation - PlayerTransform.position).magnitude > MinDistance && Enemy.CalculatePath(TargetLocation, new NavMeshPath()) && (Enemies[i].gameObject.transform.position - TargetLocation).magnitude <= ((TargetLocation - PlayerTransform.position).magnitude))
                {
                    break;
                }
                float RandomX = Random.Range(0.0f, SideOfTrigerZone) - SideOfTrigerZone / 2;
                float RandomZ = Random.Range(0.0f, SideOfTrigerZone) - SideOfTrigerZone / 2;
                TargetLocation = PlayerTransform.position + new Vector3(RandomX, 0.0f, RandomZ);
            }
        }
        

        return TargetLocation;
    }
    private void SetEnemies()
    {
        AttackingTime = Time.time + WaitingTime;
        WantToFollowTarget = true;
        ChoosingAttackingEnemy();
    }

    private void SetingTargetPositionsForEnemy()
    {
        for (int i = 0; i < Enemies.Count; i++)
        {
            

            if(Enemies[i].IsTargetReached() || (Attacker == Enemies[i].gameObject && !Enemies[i].IsTargetReached()))
            {
                Enemies[i].Move(SetTargetPosition(Enemies[i].gameObject.GetComponent<NavMeshAgent>(), Attacker == Enemies[i].gameObject));
            }
            else if (Enemies[i].gameObject == Attacker && Enemies[i].IsTargetReached())
            {
                Enemies[i].Stop();
                Enemies[i].AttackEnemy();
            }
        }
        Attacker = null;
    }

    private void ChoosingAttackingEnemy()
    {
        int Index = Random.Range(0, Enemies.Count);
        Attacker = Enemies[Index].gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.root.CompareTag("Player"))
        {
            WantToFollowTarget = true;
            SetEnemies();
        }
    }

    public void AddEnemy(GameObject NewEnemy)
    {
        Enemies.Add(NewEnemy.GetComponent<NAVMeshEnemyMovement>());
        EnemiesHealth.Add(NewEnemy.GetComponent<EnemyHealthSystem>());
    }
    
}
