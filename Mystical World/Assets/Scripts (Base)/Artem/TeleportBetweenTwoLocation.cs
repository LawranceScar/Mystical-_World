using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBetweenTwoLocation : MonoBehaviour
{
    [SerializeField] private Transform FinishPosition;
    static private bool CanTeleport = true;
    static private float LimitTime = 0.0f;
    static private float StopTime = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (!CanTeleport && Time.time > LimitTime)
        {
            CanTeleport = true;
        }
        if (other.gameObject.CompareTag("Player") && CanTeleport)
        {
            other.gameObject.transform.position = FinishPosition.position;
            CanTeleport = false;
            LimitTime = Time.time + StopTime;
        }
    }
}
