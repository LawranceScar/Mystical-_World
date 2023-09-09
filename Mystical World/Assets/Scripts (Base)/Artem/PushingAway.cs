using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingAway : MonoBehaviour
{
    [SerializeField] private float Force = 600.0f;
    private Rigidbody OtherRB;
    [SerializeField] private float DelayTime = 2.0f;
    private float NextTime = 0.0f;

    void FixedUpdate()
    {

    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.N) && Time.time > NextTime)
        {
            OtherRB = other.gameObject.GetComponent<Rigidbody>();
            if (OtherRB != null)
            {
                Debug.Log(other.gameObject.name);
                if(OtherRB.isKinematic)
                    OtherRB.isKinematic = false;
                OtherRB.AddForce((other.transform.position - this.transform.position).normalized * Force, ForceMode.Impulse); // Додати сили для відштовхування
                NextTime = Time.time + DelayTime;
            }
        }
    }
}
