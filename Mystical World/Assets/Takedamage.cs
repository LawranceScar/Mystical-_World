using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Takedamage : MonoBehaviour
{
    public float hp = 50;
    void Start()
    {
        
    }

   
    void Update()
    {
       if(hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletScript Myb = collision.gameObject.GetComponent<BulletScript>();
            hp = hp - Myb.Damage;
        }
    }
}
