using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float CurrentDamageAmount; // �� ������

    public void SetCurrentDamage(float damage) // ����� �������� CurrentDamageAmount
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
        // Debug.Log(CurrentDamageAmount); === �������� ������� ������ 
        if (!other.gameObject.CompareTag("Player"))
        {
            NormalReceiveDamage(other.gameObject);
        }
    }
}
