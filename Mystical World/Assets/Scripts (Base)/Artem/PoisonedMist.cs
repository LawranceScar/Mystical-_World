using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonedMist : MonoBehaviour
{
    private float DelayTime = 0.5f;
    private float DamageTime = 0.0f;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Time.time >= DamageTime)
        {
            DamageTime = Time.time + DelayTime;
                                                    //тут треба віднімати 10 відсотків
        }
    }
}
