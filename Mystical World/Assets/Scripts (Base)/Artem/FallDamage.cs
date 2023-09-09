using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDamage : MonoBehaviour
{
    private Rigidbody rb;
    private float Distance = 10;

    private float RealVelocity = 0f;

    public float MaxVelocity = -45f;

    [SerializeField] public GameObject Player;

    void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        RealVelocity = rb.velocity.y;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (RealVelocity <= MaxVelocity)
            {
                Distance = -RealVelocity;
                NormalReceiveDamage(Player);
            }
        }
    }

    public void NormalReceiveDamage(GameObject DamagableObject)
    {
        IDamagable IDamagableObject = DamagableObject.GetComponent<IDamagable>();
        if (IDamagableObject != null)
        {
            IDamagableObject.TakerDamage(Distance); //ReceiveRealDamage
        }
    }

}
