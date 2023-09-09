using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingAway : MonoBehaviour
{
    Rigidbody OtherRB;
    [SerializeField] private float Force = 2000.0f;
    [SerializeField] private float DelayTimeEnemy = 10.0f;
    [SerializeField] private float DelayToAction = 2.0f;
    private float NextTime = 0.0f;

    void FixedUpdate()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.N) && Time.time > NextTime)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                OtherRB = other.GetComponent<Rigidbody>();
                if (OtherRB != null)
                {
                    PushEnemy(other.gameObject);
                    OtherRB.AddForce((other.transform.position - this.transform.position).normalized * Force, ForceMode.Impulse); // Додати сили для відштовхування
                    NextTime = Time.time + DelayToAction;
                }
            }
        }
    }


    public void PushEnemy(GameObject PushableObject)
    {
        IRigidable IPushableObject = PushableObject.GetComponent<IRigidable>();
        if (IPushableObject != null)
        {
            IPushableObject.RigidBodyChange(DelayTimeEnemy); //ReceiveRealDamage
        }
    }
}
