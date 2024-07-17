using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingAway : MonoBehaviour
{
    [HideInInspector] public List<Rigidbody> rigidOther;

    [Header("Force Settings")]
    [SerializeField] private float Force = 200.0f;

    [Header("Enemy Awake Time")]
    [SerializeField] private float DelayTimeEnemy = 10.0f;

    [Header("Delay")]
    [SerializeField] private float DelayToAction = 2.0f;
    [SerializeField] private float MaxDelayAction = 2.0f;



    private bool IsActivated = false;
    private bool IsFirstTime = false;

    void FixedUpdate()
    {

    }

    private void Start()
    {
      //  IsFirstTime = true;
    }

    private void Update()
    {
        ActivatePush();
    }

    private void ActivatePush()
    {
        if (IsActivated)
        {
            DelayToAction -= Time.deltaTime;
        }

        if (DelayToAction <= 0)
        {
            IsActivated = false;
            DelayToAction = MaxDelayAction;
        }

        if (Input.GetKey(KeyCode.N) && !IsActivated)
        {

            foreach (Rigidbody newRB in rigidOther)
            {
                PushEnemy(newRB.gameObject);
                newRB.AddForce((newRB.transform.position - this.transform.position).normalized * Force, ForceMode.Impulse); // Apply force to all rigidbodies in the list
            }
            IsActivated = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody OtherRB = other.GetComponent<Rigidbody>();
            if (OtherRB != null && !rigidOther.Contains(OtherRB)) 
            {
                rigidOther.Add(OtherRB);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Rigidbody OtherRB = other.GetComponent<Rigidbody>();
            if (OtherRB != null)
            {
                if (rigidOther.Contains(OtherRB))
                {
                    rigidOther.Remove(OtherRB);
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
