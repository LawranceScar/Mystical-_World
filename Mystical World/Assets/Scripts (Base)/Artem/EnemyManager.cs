using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public bool WantToFollowTarget = false;

    [SerializeField] private List<NAVMeshEnemyMovement> Enemies;

    private float SideOfTrigerZone = 10f;
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private float MinDistance = 3.0f;
    

    private float WaitingTime = 20;
    private float AttackingTime = 0;
    private GameObject Attacker;

    void Start()
    {

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
                if((TargetLocation - PlayerTransform.position).magnitude > MinDistance && Enemy.CalculatePath(TargetLocation, new NavMeshPath()))
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
            
            if(Enemies[i].IsTargetReached() || Attacker == Enemies[i].gameObject)
            {
                if (Enemies[i] && Enemies[i].EnemyAgent)
                Enemies[i].Move(SetTargetPosition(Enemies[i].EnemyAgent, Attacker == Enemies[i].gameObject));
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
}
