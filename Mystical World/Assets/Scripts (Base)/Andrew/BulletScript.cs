using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    
    public float Damage;
   
    public void takedamage(float damage)
    {
        Damage = damage;
    }
    public void damage(float hp)
    {
        hp -= Damage;
    }
}
