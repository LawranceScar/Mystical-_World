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

        if (hp <= 0)
        {
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletScript Myb = collision.gameObject.GetComponent<BulletScript>();
            hp = hp - Myb.Damage;

        }
        if (collision.gameObject.CompareTag("Sword"))
        {

            Sworddamage myg = collision.gameObject.GetComponent<Sworddamage>();
            hp = hp - myg.damage;
        }
    }
}
