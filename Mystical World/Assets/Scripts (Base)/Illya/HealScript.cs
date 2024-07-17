using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class HealScript : MonoBehaviour
{


    public float HealAmount;
    public float TimerWhenHeal = 1f;

    public float DefaultTimer = 1f;


    private void Start()
    {
        DefaultTimer = TimerWhenHeal;
    }

    public void NormalReceiveDamage(GameObject HealableObject)
    {
        IHealable IHealableObject = HealableObject.GetComponent<IHealable>();
        if (IHealableObject != null)
        {
            IHealableObject.Heal(HealAmount); //ReceiveRealDamage
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TimerWhenHeal -= Time.deltaTime;
            if (TimerWhenHeal <= 0)
            {
                NormalReceiveDamage(other.gameObject);
                TimerWhenHeal = DefaultTimer;
            }
        }
    }
}
