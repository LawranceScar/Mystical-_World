using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    private Rigidbody rb;
    private float Distance;
    [SerializeField] private GameObject Player;

    void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (rb.velocity.y > 20)
            {
                Distance = rb.velocity.y / 2;
                                                    //HP -= Distance
            }
        }
    }

}
