using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class PoisonedMist : MonoBehaviour
{
    public float DelayTime = 0.5f;
    public float DefaultDelay = 0.5f;
    public float KillDamage = 10f;

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            DelayTime -= Time.deltaTime;
            if (DelayTime <= 0)
            {
                NormalReceiveDamage(other.gameObject);
                DelayTime = DefaultDelay;
            }
        }
    }


    public void NormalReceiveDamage(GameObject DamagableObject)
    {
        IDamagable IDamagableObject = DamagableObject.GetComponent<IDamagable>();
        if (IDamagableObject != null)
        {
            IDamagableObject.TakerDamage(KillDamage); //ReceiveRealDamage
        }
    }
}
