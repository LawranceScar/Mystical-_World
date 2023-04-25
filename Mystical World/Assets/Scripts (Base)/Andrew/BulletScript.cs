using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void Update()
    {
        
    }
    public float Damage;
    private void OnCollisionEnter(Collision collision)
    {
       
    }
    public void takedamage(float damage)
    {
        Damage = damage;
    }
    public void damage(float hp)
    {
        hp -= Damage;
    }
}
