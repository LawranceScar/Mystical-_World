using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] public int HP = 100;
    [SerializeField] private int MaxHP;

    [SerializeField] private Animator EnemyAnimator;

    private void Start()
    {
        MaxHP = HP;
    }
    private void Update()
    {
        if (HP <= 0)
        {
            Death();
        }
    }

    public void TakerDamage(int Damage)
    {
        HP -= Damage;
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
