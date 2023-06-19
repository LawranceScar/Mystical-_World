using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public Animator axe;

    void Start()
    {

    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            axe.SetTrigger("Triger");
        }
    }
}
