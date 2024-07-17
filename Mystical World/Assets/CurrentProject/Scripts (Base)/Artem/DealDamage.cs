using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    private AutomaticSight AutomaticSightComponent;
    [SerializeField] private int Damage = 10;

    private void Start()
    {
        AutomaticSightComponent = GetComponent<AutomaticSight>();
    }
    public void DealDamageToEnemy()
    {
        GameObject CurrentEnemy = AutomaticSightComponent.GetCurrentEnemy();
        if(CurrentEnemy == null)
        {
            return;
        }

        EnemyHealthSystem enemyHealthSystem = CurrentEnemy.GetComponent<EnemyHealthSystem>();
        if (enemyHealthSystem)
        {
            enemyHealthSystem.TakerDamage(Damage);
            Debug.Log("Hitting Enemy");
        }
    }
}
