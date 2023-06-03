using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float CurrentDamageAmount; // Не чіпати

    public void SetCurrentDamage(float damage) // Заміна значення CurrentDamageAmount
    {
        CurrentDamageAmount = damage;
    }

   

    public void NormalReceiveDamage(GameObject DamagableObject)
    {
        IDamagable IDamagableObject = DamagableObject.GetComponent<IDamagable>();
        if (IDamagableObject != null)
        {
            IDamagableObject.TakerDamage(CurrentDamageAmount); //ReceiveRealDamage
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        // Debug.Log(CurrentDamageAmount); === Перевірка кількості дамагу 
        if (!other.gameObject.CompareTag("Player"))
        {
            NormalReceiveDamage(other.gameObject);
        }
    }
}
