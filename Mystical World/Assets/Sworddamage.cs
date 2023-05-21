using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Sworddamage : MonoBehaviour
{
    public float damage = 30;

    private void OnTriggerEnter(Collider other)
    {
        DamagableGameObject(other.gameObject);
        Debug.Log("Gitler");
    }

    private void DamagableGameObject(GameObject DamagableObject)
    {
        IDamagable IDamagableObject = DamagableObject.GetComponent<IDamagable>();
        if (IDamagableObject != null)
        {
            IDamagableObject.TakerDamage(damage); //ReceiveRealDamage
        }
    }


}
