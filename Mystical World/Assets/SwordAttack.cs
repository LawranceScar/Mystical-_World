using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Animator sword;
   
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            sword.SetTrigger("Triger");
        }
    }
}
