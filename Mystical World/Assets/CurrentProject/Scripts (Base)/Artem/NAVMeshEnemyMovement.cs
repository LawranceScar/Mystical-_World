using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NAVMeshEnemyMovement : MonoBehaviour
{
    private NavMeshAgent EnemyAgent;
    Vector3 TargetPosition = Vector3.zero;
    float Speed = 0;
    public float MaxSpeed = 0;
    Vector3 LastPosition = Vector3.zero;
    public int Damage = 20;

    private Animator EnemyAnimator;

    private bool CanAttack = true;

    void Start()
    {
        EnemyAgent = GetComponent<NavMeshAgent>();  
        TargetPosition = gameObject.transform.position;
        LastPosition = gameObject.transform.position;
        EnemyAnimator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        Speed = (gameObject.transform.position - LastPosition).magnitude / Time.deltaTime;
        if (Speed > MaxSpeed) MaxSpeed = Speed;
        LastPosition = gameObject.transform.position;

        EnemyAnimator.SetFloat("Speed", Speed / MaxSpeed);
    }

    public void Move(Vector3 NewTargetPosition)
    {
        EnemyAgent.SetDestination(NewTargetPosition);
        Debug.DrawLine(gameObject.transform.position, NewTargetPosition, Color.red, 2.0f);
        TargetPosition = NewTargetPosition;
    }

    public bool IsTargetReached()
    {
        return (gameObject.transform.position - TargetPosition).magnitude < 3f; 
    }

    public void Stop()
    {
        EnemyAgent.Stop();
    }

    public void AttackEnemy()
    {
        if (CanAttack)
        {

            CanAttack = false;
        }
    }

    public void DealDamageToPlayer()
    {

        CanAttack = true;
    }
}
