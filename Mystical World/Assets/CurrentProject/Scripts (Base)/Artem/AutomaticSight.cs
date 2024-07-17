using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticSight : MonoBehaviour
{

    [SerializeField] private GameObject Cube;

    [SerializeField] private float Radius = 2.0f;

    [SerializeField] private Movement Move;

    private Vector3 LastPos;
    private float Speed;
    private float MaxSpeed = 1;
    [SerializeField] private float ComingToEnemySpeed = 10f;

    private GameObject CurrentEnemy;

    private bool IsInWay = false;

    [SerializeField] private int Damage = 20;

    [SerializeField] private Animator PlayerAnimator;

    private float AttackTimer = 0f;
    [SerializeField] private float StartOfAttackWindow = 0.5f;
    [SerializeField] private float EndOfAttackWindow = 2f;
    [SerializeField] private List<string> AttackTrigers = new List<string>();
    private int AttackIndex = 0;
    private int MaxAttackIndex = 0;
    private bool CanAttack = true   ;
    private bool IsAttacking = false;

    private void Start()
    {
        LastPos = gameObject.transform.position;
        PlayerAnimator = gameObject.GetComponent<Animator>();
        AttackIndex = 0;
        MaxAttackIndex = AttackTrigers.Count - 1;
    }

    private void Update()
    {
        Speed = (gameObject.transform.position - LastPos).magnitude / Time.deltaTime;
        //MaxSpeed = Speed > MaxSpeed ? Speed : MaxSpeed;
        LastPos = gameObject.transform.position;

        FindingEnemyUsingOverlapsphere();
        
        PlayerAnimator.SetFloat("Speed", Speed / 20);
        Debug.Log("Speed =" + Speed);
        Debug.Log("MaxSpeed =" + MaxSpeed);

        if (CanAttack && Input.GetKeyDown(KeyCode.Mouse0))
        {
            PlayerAnimator.SetTrigger(AttackTrigers[AttackIndex]);
            AttackTimer = Time.time + StartOfAttackWindow;
            CanAttack = false;
            IsAttacking = true;
            AttackIndex = AttackIndex < MaxAttackIndex ? AttackIndex + 1 : 0;
        }

        if (IsAttacking && AttackTimer < Time.time)
        {
            CanAttack = true;
        }
        
        if (IsAttacking && AttackTimer + EndOfAttackWindow < Time.time)
        {
            AttackIndex = 0;
            IsAttacking = false;
            CanAttack = true;
        }

        Debug.Log($"Index{AttackIndex}");
    }

    public void TakeDamage()
    {
        BreakAttack();
    }

    private void BreakAttack()
    {
        if(IsAttacking)
        {
            IsAttacking = false;
            AttackIndex = 0;
            CanAttack = false;
        }
    }

    float FindAngleBetweenPlayerForwardAndEnemy(GameObject Enemy)
    {
        return Vector3.Angle(gameObject.transform.forward, Enemy.gameObject.transform.position - gameObject.transform.position);
    }

    int FindIndexOfMinAngle(List<float> Angles)
    {
        int MinAngle = 0;
        for (int i = 0; i < Angles.Count; i++)
        {
            if(Angles[i] < Angles[MinAngle])
            {
                MinAngle = i;
            }
        }
        return MinAngle;
    }

    void FindingEnemyUsingOverlapsphere()
    {
        if (Speed != 0.0f)
        {
            List<Collider> Enemies = new List<Collider>();
            List<float> Angles = new List<float>();
            Dictionary<Collider, float> EnemiesAndAngles = new Dictionary<Collider, float>();

            Collider[] ObjectsInOverlapSphere = Physics.OverlapSphere(gameObject.transform.position, Radius);

            for (int i = 0; i < ObjectsInOverlapSphere.Length; i++)
            {
                if (ObjectsInOverlapSphere[i].CompareTag("Enemy"))
                {
                    Enemies.Add(ObjectsInOverlapSphere[i]);
                }
            }

            for (int i = 0; i < Enemies.Count; i++)
            {
                Angles.Add(FindAngleBetweenPlayerForwardAndEnemy(Enemies[i].gameObject));
            }

            if (Enemies.Count > 0 && Input.GetKeyDown(KeyCode.Mouse0) && !IsInWay) IsInWay = true;

            if (IsInWay)
            {
                CurrentEnemy = Enemies[FindIndexOfMinAngle(Angles)].gameObject;
                Cube.transform.position = CurrentEnemy.transform.position + new Vector3(0.0f, 2.0f, 0.0f);
                Move.MoveTowards(CurrentEnemy.transform.position, ComingToEnemySpeed);
                if (Move.IsTargetReached(CurrentEnemy.transform.position + new Vector3(0.0f, 0.0f, 2.0f)))
                {
                    Enemies[FindIndexOfMinAngle(Angles)].gameObject.GetComponent<EnemyHealthSystem>().TakerDamage(Damage);
                    IsInWay = false;
                }
            }
        }
    }

    public GameObject GetCurrentEnemy()
    {
        return CurrentEnemy;
    }
}
