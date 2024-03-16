using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NAVMeshEnemyMovement : MonoBehaviour
{
    public NavMeshAgent EnemyAgent;
    Vector3 TargetPosition = Vector3.zero;

    void Start()
    {
        EnemyAgent = GetComponent<NavMeshAgent>();  
        TargetPosition = gameObject.transform.position;
    }

    public void Move(Vector3 NewTargetPosition)
    {
        EnemyAgent.SetDestination(NewTargetPosition);
        Debug.DrawLine(gameObject.transform.position, NewTargetPosition, Color.red, 2.0f);
        TargetPosition = NewTargetPosition;
    }

    public bool IsTargetReached()
    {
        return (gameObject.transform.position - TargetPosition).magnitude < 2f; 
    }

    
    


}
