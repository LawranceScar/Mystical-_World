using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBoss : MonoBehaviour
{
    [SerializeField] Transform Taget;
    private Rigidbody RBOfBoss;
    private float BossSpeed = 5000;
    public bool CanMove = false;
    private bool CanAttack = false;
    void Start()
    {
        RBOfBoss = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (CanMove)
        {
            this.transform.rotation = Quaternion.LookRotation(Taget.position - this.transform.position);
            RBOfBoss.AddForce(this.transform.forward.normalized * BossSpeed, ForceMode.Force);
        }
        if (CanAttack)
        {

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CanAttack = true;
        }
    }
}
