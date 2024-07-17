using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class ScriptTester : MonoBehaviour
{

    public float DamageGet = 1f;
    public float Timerf = 1f;

    private float DefaultTimer;
    // Start is called before the first frame update
    void Start()
    {
        DefaultTimer = Timerf;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Timerf -= Time.deltaTime;

        if (Timerf <= 0)
        {
            NormalReceiveDamage(other.gameObject);
            Timerf = DefaultTimer;
        }
    }

    public void NormalReceiveDamage(GameObject DamagableObject)
    {
        IDamagable IDamagableObject = DamagableObject.GetComponent<IDamagable>();
        if (IDamagableObject != null)
        {
            IDamagableObject.TakerDamage(DamageGet); //ReceiveRealDamage
        }
    }
}
