using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sworddamage : MonoBehaviour
{
    public  float damage = 30;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("E"))
        {
            Takedamage edmg = other.gameObject.GetComponent<Takedamage>();

            edmg.hp = edmg.hp - damage;
        }
    }


}
