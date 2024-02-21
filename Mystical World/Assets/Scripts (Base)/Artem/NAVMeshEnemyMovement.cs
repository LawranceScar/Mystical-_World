using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NAVMeshEnemyMovement : MonoBehaviour
{
    public bool WantToFollow = false;

    private NavMeshAgent EnemyAgent;

    private float SideOfTrigerZone;
    Vector3 RamdomLocation;
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private float MinDistance = 3.0f;
    NavMeshPath Path;

    List<GameObject > Enemies;

    float WaitingTime = 2;
    float AttackingTime = 0;
    List<float> WaitingDifference;

    void Start()
    {
        EnemyAgent = GetComponent<NavMeshAgent>();
        Path = new NavMeshPath();

        Enemies.Add(gameObject);
        WaitingTime *= Enemies.Count;
        AttackingTime = Time.time;
        Debug.Log(Enemies.Count + " = Enemies.Count");
    }

    private void Update()
    {
        if (WantToFollow)
        {
            ComingToTargetPosition();
        }
    }

    Vector3 SetTargetPosition()
    {
        if (Time.time > AttackingTime)
        {
            do
            {
                float RandomX = Random.RandomRange(0.0f, SideOfTrigerZone) - SideOfTrigerZone / 2;
                float RandomZ = Random.RandomRange(0.0f, SideOfTrigerZone) - SideOfTrigerZone / 2;
                RamdomLocation = new Vector3(RandomX, PlayerTransform.position.y, RandomZ);
            } while ((RamdomLocation - PlayerTransform.position).magnitude < MinDistance || !EnemyAgent.CalculatePath(RamdomLocation, Path));
        }
        else
        {
            do
            {
                float RandomX = Random.RandomRange(0.0f, SideOfTrigerZone) - SideOfTrigerZone / 2;
                float RandomZ = Random.RandomRange(0.0f, SideOfTrigerZone) - SideOfTrigerZone / 2;
                RamdomLocation = new Vector3(RandomX, PlayerTransform.position.y, RandomZ);
            } while ((RamdomLocation - PlayerTransform.position).magnitude > MinDistance || !EnemyAgent.CalculatePath(RamdomLocation, Path));
        }

        return RamdomLocation + PlayerTransform.position;
    }

    void ComingToTargetPosition()
    {
        if(Time.time > AttackingTime)
        {
            Move(SetTargetPosition());
            AttackingTime = Time.time + WaitingTime;
        }
        else
        {
            Move(SetTargetPosition());
        }
    }

    void Move(Vector3 TargetPosition)
    {
        EnemyAgent.SetDestination(TargetPosition);
    }

    public void SetTimer()
    {
        for(int i = 0; i < Enemies.Count; i++)
        {
            WaitingDifference.Add(i);

            if (Enemies[i] == gameObject)
            {
                WaitingTime -= WaitingDifference[i] * 2;
            }
        }
        AttackingTime = Time.time + WaitingTime;
    }


}
